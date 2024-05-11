using eCommerce2024.API.Database.Models;
using eCommerce2024.API.Services.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Product;

namespace eCommerce2024.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : BaseController<Product, MProduct, InsertProduct, UpdateProduct>
    {
        public ProductController(IProductService service) : base(service)
        {
        }
    }
}
