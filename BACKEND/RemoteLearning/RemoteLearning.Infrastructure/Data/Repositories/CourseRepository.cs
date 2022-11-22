namespace RemoteLearning.Infrastructure.Data.Repositories;

public class CourseRepository : BaseRepository<Course>, ICourseRepository
{
    public CourseRepository(RemoteLearningDbContext context) : base(context) { }

    public async Task<Course> GetWithCreator(long courseId) => await _context.Courses.
        Include(course => course.Creator)
        .ThenInclude(creator => creator.UserDetails)
        .SingleOrDefaultAsync(course => course.Id == courseId);
}
