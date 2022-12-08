using RemoteLearning.Domain.Entities;

namespace RemoteLearning.Infrastructure.Data.Repositories;

public class CourseRepository : BaseRepository<Course>, ICourseRepository
{
    public CourseRepository(RemoteLearningDbContext context) : base(context) { }

    public async Task<Course> GetByName(string name) => await GetByCondition(c => c.Name.ToLower() == name.ToLower());

    public async Task<IEnumerable<Course>> GetMyCourses(long userId) => await _context.Courses
        .Include(course => course.Creator)
        .ThenInclude(creator => creator.UserDetails)
        .Where(creator => creator.CreatorId == userId)
        .ToListAsync();

    public async Task<IEnumerable<Course>> GetAssignedCourses(long userId) => await _context.Courses
        .Where(course => course.CourseUsers.Any(cu => cu.UserId == userId))
        .ToListAsync();

    public async Task<Course> GetWithCreator(long courseId) => await _context.Courses
        .Include(course => course.Creator)
        .ThenInclude(creator => creator.UserDetails)
        .SingleOrDefaultAsync(course => course.Id == courseId);
}
