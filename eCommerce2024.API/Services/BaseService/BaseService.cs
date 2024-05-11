
using AutoMapper;
using eCommerce2024.API.Database.Context;

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
            var list = _appDbContext.Set<TDb>().ToList();
            return _mapper.Map<List<TModel>>(list);
        }

        public virtual TModel GetById(int id)
        {
            var entity = _appDbContext.Set<TDb>().Find(id);
            return _mapper.Map<TModel>(entity);
        }

        public virtual TModel Insert(TInsert insert)
        {
            var mappedObj = _mapper.Map<TDb>(insert);
            var insertedObj = _appDbContext.Set<TDb>().Add(mappedObj);
            _appDbContext.SaveChanges();
            return _mapper.Map<TModel>(insertedObj);
        }

        public virtual TModel Update(int id, TUpdate update)
        {
            var entity = _appDbContext.Set<TDb>().Find(id);

            _mapper.Map(entity, update);
            _appDbContext.SaveChanges();
            return _mapper.Map<TModel>(entity);
        }

        public virtual bool Delete(int id)
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
        }
    }
}
