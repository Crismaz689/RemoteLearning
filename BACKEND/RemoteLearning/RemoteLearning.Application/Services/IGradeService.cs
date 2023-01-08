namespace RemoteLearning.Application.Services;

public interface IGradeService
{
    Task<GradeDto> CreateGrade(CreateGradeDto dto, string userId);

    Task<IEnumerable<GradeUserDto>> GetUserGrades(string userId);

    Task<IEnumerable<GradeUserDetailedDto>> GetAllUsersGrades();

    Task<bool> DeleteGrade(long id, string userId);

    Task<GradeDto> UpdateGrade(CreateGradeDto dto, long id, string userId);
}
