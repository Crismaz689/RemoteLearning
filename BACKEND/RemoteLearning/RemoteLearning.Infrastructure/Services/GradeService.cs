namespace RemoteLearning.Infrastructure.Services;

public class GradeService : IGradeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GradeService(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);
    public async Task<GradeDto> CreateGrade(CreateGradeDto dto, string userId)
    {
        var user = await _unitOfWork.Users.GetUserWithCourses(Convert.ToInt64(userId));

        if (dto != null && user != null && (user.Courses.Select(c => c.Id).Contains(dto.CourseId) || user.RoleId == 1))
        {
            var grade = _mapper.Map<Grade>(dto);

            await _unitOfWork.Grades.Create(grade);
            if (await _unitOfWork.SaveChangesAsync() != 0)
            {
                return _mapper.Map<GradeDto>(grade);
            }
        }
        else
        {
            throw new GradeNoPermissionException("You have no access to creating grades for this course.");
        }

        return null;
    }

    public async Task<bool> DeleteGrade(long id, string userId)
    {
        var user = await _unitOfWork.Users.GetUserWithCourses(Convert.ToInt64(userId));
        var grade = await _unitOfWork.Grades.GetById(id);

        if (id > 0 && user != null && (user.Courses.Select(c => c.Id).Contains(grade.CourseId) || user.RoleId == 1))
        {
            await _unitOfWork.Grades.Delete(id);

            return await _unitOfWork.SaveChangesAsync() != 0;
        }
        else
        {
            throw new GradeNoPermissionException("You have no access to delete this grade.");
        }

        return false;
    }

    public async Task<IEnumerable<GradeUserDetailedDto>> GetAllUsersGrades()
    {
        var grades = await _unitOfWork.Grades.GetAllUsersGrades();

        return grades != null ?
            _mapper.Map<IEnumerable<GradeUserDetailedDto>>(grades) :
            Enumerable.Empty<GradeUserDetailedDto>();
    }

    public async Task<IEnumerable<GradeUserDto>> GetUserGrades(string userId)
    {
        var grades = await _unitOfWork.Grades.GetUserGrades(Convert.ToInt64(userId));

        return grades != null ?
            _mapper.Map<IEnumerable<GradeUserDto>>(grades) :
            Enumerable.Empty<GradeUserDto>();
    }

    public async Task<GradeDto> UpdateGrade(CreateGradeDto dto, long id, string userId)
    {
        var user = await _unitOfWork.Users.GetUserWithCourses(Convert.ToInt64(userId));

        if (dto != null && user != null && (user.Courses.Select(c => c.Id).Contains(dto.CourseId) || user.RoleId == 1))
        {
            var grade = await _unitOfWork.Grades.GetById(id);

            grade.Value = dto.Value;
            grade.Title = dto.Title;
            grade.Description = dto.Description;
            grade.CourseId = dto.CourseId;
            grade.UserId = dto.UserId;
            grade.CategoryId = dto.CategoryId;
            grade.ModificationDate = DateTime.Now;

            await _unitOfWork.Grades.Update(grade);

            if (await _unitOfWork.SaveChangesAsync() != 0)
            {
                return _mapper.Map<GradeDto>(grade);
            }
        }
        else
        {
            throw new GradeNoPermissionException("You have no access to update this grade.");
        }

        return null;
    }
}
