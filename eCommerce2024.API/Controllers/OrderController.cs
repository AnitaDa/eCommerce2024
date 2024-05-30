using eCommerce2024.API.Database.Models;
using eCommerce2024.API.Services.OrderService;
using Microsoft.AspNetCore.Mvc;
using Models.Order;

namespace eCommerce2024.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : BaseController<Order, MOrder, InsertOrder, object>
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService) : base(orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{Id}")]
        public List<MOrder> GetOrdersByCustomerId(int Id)
        {
            return _orderService.GetAllByCustomerId(Id);
        }
    }
}
