namespace ServiceLayer
{
    public interface IGenericService<T>:IDisposable
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetEntity(int id);
        Task<bool> Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        Task<bool> Delete(int id);
        Task Save();

    }
}
