namespace ServiceLayer
{
    public interface IGenericService<T>:IDisposable
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetEntity(int id);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Delete(int id);
    }
}
