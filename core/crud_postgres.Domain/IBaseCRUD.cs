namespace crud_postgresql.Domain
{
    public interface IBaseCRUD<T>
    {
            Task<List<T>> GetAllAsync();
            Task<T> AddAsync(T entity);
            Task<T> GetAsync(int id);
            Task<bool> UpdateAsync(int id,T entity);
            Task<bool> DeleteAsync(int id);
     
    }
}
