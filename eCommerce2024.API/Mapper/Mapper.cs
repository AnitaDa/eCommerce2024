using AutoMapper;
using eCommerce2024.API.Database.Models;
using Models.Product;

namespace eCommerce2024.API.Mapper
{
    public class Mapper:Profile
    {
        public Mapper() {
            CreateMap<Product, MProduct>();
        }
    }
}
