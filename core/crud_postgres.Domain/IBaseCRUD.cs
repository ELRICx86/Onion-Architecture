namespace crud_postgresql.Domain
{
    public interface IBaseCRUD<T>
    {
            Task<T> GetAllAsync(T entity);
            Task<T> AddAsync(T entity);
            Task<T> GetAsync(int id);
            Task<bool> UpdateAsync(T entity);
            Task<bool> DeleteAsync(int id);
     
    }
}
