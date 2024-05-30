using AutoMapper;
using eCommerce2024.API.Database.Context;
using eCommerce2024.API.Database.Models;
using eCommerce2024.API.Models;
using eCommerce2024.API.Services.BaseService;
using Microsoft.EntityFrameworkCore;
using Models.Cart;

namespace eCommerce2024.API.Services.CartService
{
    public class CartService : BaseService<Cart, MCart, UpdateCart, InsertCart>, ICartService
    {
        public CartService(ApplicationDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext, mapper)
        {
        }
        public override MCart Insert(InsertCart insert)
        {
            try
            {
                var customer = _appDbContext.Customers.Find(insert.CustomerId);
                if (customer is not null)
                {
                    var cart = base.Insert(insert);
                    
                    var insertedCart = _appDbContext.Carts
                        .Include(x => x.Cartitems)
                        .ThenInclude(xi=>xi.Product)
                        .FirstOrDefault(x => x.Id.Equals(cart.Id));

                    return _mapper.Map<MCart>(insertedCart);
                }
                else
                {
                    throw new Exception($"Customer with CustomerId = {insert.CustomerId} does not exist!");
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public override MCart Update(int id, UpdateCart update)
        {
            return base.Update(id, update);
        }
    }
}
