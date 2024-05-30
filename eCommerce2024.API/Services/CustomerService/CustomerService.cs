using AutoMapper;
using eCommerce2024.API.Database.Context;
using eCommerce2024.API.Database.Models;
using eCommerce2024.API.Services.BaseService;
using Models.Customer;

namespace eCommerce2024.API.Services.CustomerService
{
    public class CustomerService : BaseService<Customer, MCustomer, UpdateCustomer, InsertCustomer>, ICustomerService
    {
        public CustomerService(ApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
        {
        }
        public int? GetCustomerIdByUserId(string userId)
        {
            var customerId = _appDbContext?.Customers?.FirstOrDefault(x => x.UserId == userId)?.Id;
            return customerId > 0 ? customerId : null;
        }
    }
}
