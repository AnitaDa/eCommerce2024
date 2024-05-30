using AutoMapper;
using eCommerce2024.API.Database.Models;
using eCommerce2024.API.Models;
using Models.Cart;
using Models.CartItem;
using Models.Color;
using Models.Customer;
using Models.Order;
using Models.OrderDetails;
using Models.Product;

namespace eCommerce2024.API.Mapper
{
    public class Mapper:Profile
    {
        public Mapper() {
            CreateMap<Product, MProduct>().ReverseMap();
            CreateMap<InsertProduct, Product>();
            CreateMap<UpdateProduct, Product>().ReverseMap();

            CreateMap<InsertCustomer, Customer>();
            CreateMap<Customer, MCustomer>();

            CreateMap<Order, MOrder>();
            CreateMap<InsertOrder, Order>();

            CreateMap<Color, MColor>();

            CreateMap<Orderdetail, MOrderDetails>();
            CreateMap<InsertOrderDetails, Orderdetail>();

            CreateMap<Cartitem, MCartItem>();
            CreateMap<InsertCartItem, Cartitem>();
           
            CreateMap<Cart, MCart>();
            CreateMap<UpdateCart, Cart>().ReverseMap();
            CreateMap<InsertCart, Cart>();

            CreateMap<UpdateCartItem, Cartitem>().ReverseMap();

        }
    }
}
