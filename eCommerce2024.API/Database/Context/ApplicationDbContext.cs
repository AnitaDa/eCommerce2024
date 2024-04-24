using System;
using System.Collections.Generic;
using eCommerce2024.API.Database.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace eCommerce2024.API.Database.Context;

public partial class ApplicationDbContext : IdentityDbContext<CustomUser>
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Paymentmethod> Paymentmethods { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1,3306;user=root;password=test;database=ecommerce", ServerVersion.Parse("8.0.29-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");



        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customers");

            entity.HasIndex(e => e.UserId, "UserId");

            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.PostalCode).HasMaxLength(20);
            entity.Property(e => e.Street).HasMaxLength(255);
            entity.Property(e => e.UserId).HasMaxLength(100);

            entity.HasOne(d => d.User).WithMany(p => p.Customers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("customers_ibfk_1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.HasIndex(e => e.CustomerId, "CustomerId");

            entity.Property(e => e.TotalAmount).HasPrecision(10, 2);

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("orders_ibfk_1");
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PRIMARY");

            entity.ToTable("orderdetails");

            entity.HasIndex(e => e.OrderId, "OrderId");

            entity.HasIndex(e => e.ProductId, "ProductId");

            entity.Property(e => e.UnitPrice).HasPrecision(10, 2);

            entity.HasOne(d => d.Order).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("orderdetails_ibfk_1");

            entity.HasOne(d => d.Product).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("orderdetails_ibfk_2");
        });

        modelBuilder.Entity<Paymentmethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("PRIMARY");

            entity.ToTable("paymentmethods");

            entity.HasIndex(e => e.CustomerId, "CustomerId");

            entity.Property(e => e.CardNumber).HasMaxLength(20);
            entity.Property(e => e.Cvv).HasMaxLength(4);
            entity.Property(e => e.MethodType).HasMaxLength(100);

            entity.HasOne(d => d.Customer).WithMany(p => p.Paymentmethods)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("paymentmethods_ibfk_1");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.CategoryId, "CategoryId");

            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Price).HasPrecision(10, 2);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("products_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
