using eCommerce2024.API.Database.Models;
using Models.Product;

namespace eCommerce2024.API.Services.ProductService
{
    public interface IProductService : IBaseService<MProduct, UpdateProduct, InsertProduct>
    {
    }
}
