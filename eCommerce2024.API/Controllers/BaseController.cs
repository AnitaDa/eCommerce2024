using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce2024.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TDatabase, TModel, TInsert, TUpdate> : ControllerBase where TDatabase : class
    {
        private readonly IBaseService<TDatabase, TModel, TUpdate, TInsert> _baseService;
        public BaseController(IBaseService<TDatabase, TModel, TUpdate, TInsert> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public List<TModel> GetAll() {
          return _baseService.GetAll();
        }
        [HttpGet("{Id}")]
        public TModel GetById(int Id)
        {
            return _baseService.GetById(Id);
        }
        [HttpPost]
        public TModel Insert(TInsert insert)
        {
            return _baseService.Insert(insert);
        }
        [HttpPut("{Id}")]
        public TModel Update(int Id, TUpdate update)
        {
            return _baseService.Update(Id, update);
        }
        [HttpDelete("{Id}")]
        public bool DeleteById(int Id) { 
            return _baseService.Delete(Id);
        }
    }
}
