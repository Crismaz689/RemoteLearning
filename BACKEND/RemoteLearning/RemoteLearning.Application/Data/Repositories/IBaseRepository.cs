namespace RemoteLearning.Application.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();

    Task<T> GetById(long id);

    Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression);

    Task Create(T entity);

    void Update(T entity);

    Task Delete(long id);
}