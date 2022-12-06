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

    public async Task Create(T entity) => await _dbSet.AddAsync(entity);

    public async Task Delete(long id)
    {
        var entity = await _dbSet.FindAsync(id);

        if (entity != null)
        {
            _dbSet.Remove(entity);
        }
    }

    public async Task<T> GetById(long id) => await _dbSet.FindAsync(id);

    public async Task<IEnumerable<T>> GetAll() => await _dbSet.ToListAsync();

    public async Task<T> GetByCondition(Expression<Func<T, bool>> expression) => await _dbSet.Where(expression)
            .SingleOrDefaultAsync();

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
}
