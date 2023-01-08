namespace RemoteLearning.Application.Services;

public interface IGradeService
{
    Task<GradeDto> CreateGrade(CreateGradeDto dto, string userId);
}
