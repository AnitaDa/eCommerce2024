using Models.Order;

namespace eCommerce2024.API.Services.OrderService
{
    public interface IOrderService : IBaseService<MOrder, object, InsertOrder>
    {
        public List<MOrder> GetAllByCustomerId(int Id);
    }
}
