
using AutoMapper;
using eCommerce2024.API.Database.Context;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce2024.API.Services.BaseService
{
    public class BaseService<TDb, TModel, TUpdate, TInsert> : IBaseService<TModel, TUpdate, TInsert> 
        where TDb : class 
        where TModel : class 
        where TUpdate : class 
        where TInsert : class
    {
        protected readonly ApplicationDbContext _appDbContext;
        protected readonly IMapper _mapper;
        public BaseService(
            ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _appDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public virtual List<TModel> GetAll()
        {
            try
            {
                var list = _appDbContext.Set<TDb>().ToList();
                return _mapper.Map<List<TModel>>(list);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual TModel GetById(int id)
        {
            try
            {
                var entity = _appDbContext.Set<TDb>().Find(id);
                if(entity is not null)
                    return _mapper.Map<TModel>(entity);
                    throw new Exception($"Object with ID = {id} does not exist!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public virtual TModel Insert(TInsert insert)
        {
            try
            {
                var mappedObj = _mapper.Map<TDb>(insert);
                _appDbContext.Set<TDb>().Add(mappedObj);
                _appDbContext.SaveChanges();
                return _mapper.Map<TModel>(mappedObj);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual TModel Update(int id, TUpdate update)
        {
            try
            {
                var entity = _appDbContext.Set<TDb>().Find(id);

                _mapper.Map(update, entity);
                _appDbContext.SaveChanges();
                return _mapper.Map<TModel>(entity);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual bool Delete(int id)
        {
            try
            {
                if (id > 0)
                {
                    var entity = _appDbContext.Set<TDb>().Find(id);
                    if (entity is not null)
                    {
                        _appDbContext.Set<TDb>().Remove(entity);
                        _appDbContext.SaveChanges();
                    }
                    return true;
                }
                return false;
            }catch(Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
