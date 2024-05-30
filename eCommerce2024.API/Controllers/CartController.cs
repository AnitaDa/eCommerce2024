using eCommerce2024.API.Models;
using eCommerce2024.API.Services.CartService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Cart;

namespace eCommerce2024.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : BaseController<Cart, MCart, InsertCart, UpdateCart>
    {
        public CartController(ICartService service) : base(service)
        {
        }
    }
}
