using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eCommerce2024.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes ="Bearer")]
    public class BaseController<TDatabase, TModel, TInsert, TUpdate> : ControllerBase 
        where TDatabase : class
        where TModel : class
        where TInsert : class
        where TUpdate : class
    {
        private readonly IBaseService<TModel, TUpdate, TInsert> _baseService;

        public BaseController(IBaseService<TModel, TUpdate, TInsert> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public ActionResult<List<TModel>> GetAll() {
          
            try
            {
                return _baseService.GetAll();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public ActionResult<TModel> GetById(int Id)
        {
            try{
                return _baseService.GetById(Id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<TModel> Insert(TInsert insert)
        {
            try
            {
                var insertedObject = _baseService.Insert(insert);
                return insertedObject;
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public ActionResult<TModel> Update(int Id, TUpdate update)
        {
            try
            {
                return _baseService.Update(Id, update);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public ActionResult<bool> DeleteById(int Id) { 
            
            try
            {
                return _baseService.Delete(Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
