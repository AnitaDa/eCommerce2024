using AutoMapper;
using eCommerce2024.API.Database.Context;
using eCommerce2024.API.Database.Models;
using eCommerce2024.API.Services.BaseService;
using eCommerce2024.API.Services.CustomerService;
using eCommerce2024.API.Services.UserService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Customer;
using Models.Order;
using Models.OrderDetails;
using System.Collections.Generic;
using System.Security.Claims;

namespace eCommerce2024.API.Services.OrderService
{
    public class OrderService : BaseService<Order, MOrder, object, InsertOrder>, IOrderService
    {
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        public OrderService(
            ApplicationDbContext applicationDbContext,
            IMapper mapper,
            IUserService userService,
            ICustomerService customerService) : base(applicationDbContext, mapper)
        {
            _userService = userService;
            _customerService = customerService;
        }
        public override List<MOrder> GetAll()
        {
            var query = _appDbContext.Orders.AsQueryable();
            query = query.Include(o => o.Customer);
            query = query.Include(o => o.Orderdetails).ThenInclude(oi=>oi.Product);
            //this should be optimized ==>EXPLORE
            query = query.Include(o => o.Orderdetails).ThenInclude(oi=>oi.Color);

            var orders = query.ToList();

            return _mapper.Map<List<MOrder>>(orders);
        }
        public override MOrder GetById(int id)
        {
            var order = _appDbContext.Orders.
                Include(o => o.Customer)
                .Include(o => o.Orderdetails)
                .ThenInclude(o => o.Product)
                .Where(o => o.Id == id)
                .FirstOrDefault();

            return _mapper.Map<MOrder>(order);
        }
        public List<MOrder> GetAllByCustomerId(int customerId)
        {
            var orders = _appDbContext.Orders
                .Include(o=>o.Orderdetails)
                .ThenInclude(o=>o.Product)
                .Where(o=>o.CustomerId == customerId)
                .ToList();

            return _mapper.Map<List<MOrder>>(orders);
        }
        public override MOrder Insert(InsertOrder insert)
        {
            var currentLoggedUser = _userService.GetCurrentLoggedUser();

            var order = new InsertOrder() {
            TotalAmount = insert.TotalAmount
            };

            //if user logged, then the customer will bi automaticaly set to order with already exist customer
            //if not, new customer will be created
            if(currentLoggedUser is not null)
            {
                //get customer by userId and set them
                var customerId = _customerService.GetCustomerIdByUserId(currentLoggedUser);
                order.CustomerId = customerId;
            }
            else
            {
                var anonymCustomerModel = new InsertCustomer
                {
                    FirstName = insert?.Customer?.FirstName,
                    LastName = insert?.Customer?.LastName,
                    Email = insert?.Customer?.Email,
                    Street = insert?.Customer?.Street,
                    City = insert?.Customer?.City,
                    Country = insert?.Customer?.Country,
                    PhoneNumber = insert?.Customer?.PhoneNumber,
                    PostalCode = insert?.Customer?.PostalCode
                };
                var newCustomer = _customerService.Insert(anonymCustomerModel);
                order.CustomerId = newCustomer.Id;
            }
            
            var insertedOrder = base.Insert(order);
            if(insertedOrder != null)
            {
                foreach(var item in insert.OrderDetails)
                {
                    var orDetials = new InsertOrderDetails
                    {
                        OrderId = insertedOrder.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    };
                    InsertOrderDetails(orDetials);
                }
            }
            var currentOrder = base.GetById(insertedOrder.Id);
            return _mapper.Map<MOrder>(currentOrder);
        }
        public MOrderDetails InsertOrderDetails(InsertOrderDetails insertDetails)
        {
            var mappedObj = _mapper.Map<Orderdetail>(insertDetails);
            var insertedObj = _appDbContext.Orderdetails.Add(mappedObj);
            _appDbContext.SaveChanges();
            return _mapper.Map<MOrderDetails>(mappedObj);
        }
    }
}
