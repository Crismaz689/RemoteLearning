namespace RemoteLearning.Infrastructure.Services;

public class GradeService : IGradeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GradeService(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);
    public async Task<GradeDto> CreateGrade(CreateGradeDto dto, string userId)
    {
        if (dto != null)
        {
            var grade = _mapper.Map<Grade>(dto);

            await _unitOfWork.Grades.Create(grade);

            if (await _unitOfWork.SaveChangesAsync() != 0)
            {
                return _mapper.Map<GradeDto>(grade);
            }
        }

        return null;
    }
}
