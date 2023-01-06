namespace RemoteLearning.Application.Data;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IUserDetailsRepository UsersDetails { get; }
    ICategoryRepository Categories { get; }
    ICourseRepository Courses { get; }
    ICourseUserRepository CourseUsers { get; }
    IFileRepository Files { get; }
    IGradeRepository Grades { get; }
    IRoleRepository Roles { get; }
    ISectionRepository Sections { get; }
    ITestRepository Tests { get; }
    ITextQuestionRepository TextQuestions { get; }
    Task<int> SaveChangesAsync();
}
