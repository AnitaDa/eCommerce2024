using AutoMapper;
using eCommerce2024.API.Database.Context;
using eCommerce2024.API.Database.Models;
using eCommerce2024.API.Services.BaseService;
using Models.Product;

namespace eCommerce2024.API.Services.ProductService
{
    public class ProductService : BaseService<Product, MProduct, UpdateProduct, InsertProduct>, IProductService
    {
        public ProductService(ApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
        {
        }
    }
}
 