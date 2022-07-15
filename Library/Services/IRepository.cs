namespace Library.Services;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    T? Get(int id);
    T? Add(T entity);
    T? Update(T entity);
    T? Delete(int id);
}