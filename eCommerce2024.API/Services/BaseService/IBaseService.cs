namespace eCommerce2024.API
{
    public interface IBaseService<TModel, TUpdate, TInsert>
    {
        public List<TModel> GetAll();
        public TModel GetById(int id);
        public TModel Update(int id, TUpdate update);
        public TModel Insert(TInsert insert);
        public bool Delete(int id);
    }
}