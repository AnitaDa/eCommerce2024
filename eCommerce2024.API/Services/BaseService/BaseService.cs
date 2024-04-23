
using AutoMapper;
using eCommerce2024.API.Database.Context;

namespace eCommerce2024.API.Services.BaseService
{
    public class BaseService<TDatabases, TModel, TUpdate, TInsert> : IBaseService<TModel, TUpdate, TInsert> where TDatabases : class
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly IMapper _mapper;
        public BaseService(
            ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _appDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public bool Delete(int id)
        {
            if(id > 0)
            {
                var entity = _appDbContext.Set<TDatabases>().Find(id);
                if (entity is not null)
                {
                    _appDbContext.Set<TDatabases>().Remove(entity);
                    _appDbContext.SaveChanges();
                }
                return true;
            }
            return false;
        }

        public List<TModel> GetAll()
        {
            var list = _appDbContext.Set<TDatabases>().ToList();
            return _mapper.Map<List<TModel>>(list);
        }

        public TModel GetById(int id)
        {
            var entity = _appDbContext.Set<TDatabases>().Find(id);
            return _mapper.Map<TModel>(entity);
        }

        public TModel Insert(TInsert insert)
        {
            var mappedObj = _mapper.Map<TDatabases>(insert);
            var insertedObj = _appDbContext.Set<TDatabases>().Add(mappedObj);
            _appDbContext.SaveChanges();
            return _mapper.Map<TModel>(insertedObj);
        }

        public TModel Update(int id, TUpdate update)
        {
            var entity = _appDbContext.Set<TDatabases>().Find(id);
            
                _mapper.Map(entity, update);
                _appDbContext.SaveChanges();
            return _mapper.Map<TModel>(entity); 
        }
    }
}
