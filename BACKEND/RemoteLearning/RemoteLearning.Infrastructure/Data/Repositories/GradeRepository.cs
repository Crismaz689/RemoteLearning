namespace RemoteLearning.Infrastructure.Data.Repositories;

public class GradeRepository : BaseRepository<Grade>, IGradeRepository
{
    public GradeRepository(RemoteLearningDbContext context) : base(context) { }

    public async Task<IEnumerable<Grade>> GetAllUsersGrades() => await _context.Grades
        .Include(g => g.Course)
        .Include(g => g.Category)
        .Include(g => g.User)
        .ThenInclude(user => user.UserDetails)
        .ToListAsync();

    public async Task<IEnumerable<Grade>> GetUserGrades(long userId) => await _context.Grades
        .Include(g => g.Course)
        .Include(g => g.Category)
        .Where(g => g.UserId == userId)
        .ToListAsync();
}
