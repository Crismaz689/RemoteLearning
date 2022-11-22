namespace RemoteLearning.Infrastructure.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected RemoteLearningDbContext _context;
    protected DbSet<T> _dbSet;
    public BaseRepository(RemoteLearningDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task Create(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task Delete(long id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.Where(expression).ToListAsync();
    }

    public async Task<T> GetById(long id)
    {
        return await _dbSet.FindAsync(id);
    }

    public Task Update(T entity)
    {
        throw new NotImplementedException();
    }
}
