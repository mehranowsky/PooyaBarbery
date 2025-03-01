namespace ServiceLayer
{
    public interface IGenericService<T>:IDisposable
    {
        IEnumerable<T> GetAll();
        T GetEntity(int id);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Delete(int id);
        void Save();

    }
}
