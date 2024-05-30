using Models.Customer;

namespace eCommerce2024.API.Services.CustomerService
{
    public interface ICustomerService : IBaseService<MCustomer, UpdateCustomer, InsertCustomer>
    {
        public int? GetCustomerIdByUserId(string userId);
    }
}
