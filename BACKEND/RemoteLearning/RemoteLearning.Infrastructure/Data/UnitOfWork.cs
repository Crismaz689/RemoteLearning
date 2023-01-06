namespace RemoteLearning.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    public IUserRepository Users { get; private set; }
    public IUserDetailsRepository UsersDetails { get; private set; }
    public ICategoryRepository Categories { get; private set; }
    public ICourseRepository Courses { get; private set; }
    public ICourseUserRepository CourseUsers { get; private set; }
    public IFileRepository Files { get; private set; }
    public IGradeRepository Grades { get; private set; }
    public IRoleRepository Roles { get; private set; }
    public ISectionRepository Sections { get; private set; }
    public ITestRepository Tests { get; private set; }
    public ITextQuestionRepository TextQuestions { get; private set; }

    private readonly ILogger _logger;

    public RemoteLearningDbContext Context { get; private set; }

    private readonly RemoteLearningDbContext _context;

    public UnitOfWork(RemoteLearningDbContext context, ILogger<UnitOfWork> logger)
    {
        _context = context;
        _logger = logger;

        Users = new UserRepository(_context);
        UsersDetails = new UserDetailsRepository(_context);
        Categories = new CategoryRepository(_context);
        Courses = new CourseRepository(_context);
        CourseUsers = new CourseUserRepository(_context);
        Files = new FileRepository(_context);
        Grades = new GradeRepository(_context);
        Roles = new RoleRepository(_context);
        Sections = new SectionRepository(_context);
        Tests = new TestRepository(_context);
        TextQuestions = new TextQuestionRepository(_context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
