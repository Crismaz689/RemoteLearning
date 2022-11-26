namespace RemoteLearning.Infrastructure.Services;

public class CourseUserService : ICourseUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourseUserService(IUnitOfWork unitOfWork, IMapper mapper) => (_unitOfWork, _mapper) = (unitOfWork, mapper);

    public async Task<long> Create(CreateCourseUserDto courseUserDto)
    {
        if (courseUserDto != null)
        {
            if (await IsUserAlreadyAssigned(courseUserDto))
            {
                throw new UserAlreadyAssigned("Uzytkownik jest juz zapisany do kursu!");
            }

            var courseUser = _mapper.Map<CourseUser>(courseUserDto);

            await _unitOfWork.CourseUsers.Create(courseUser);

            if (await _unitOfWork.SaveChangesAsync() != 0)
            {
                return courseUser.Id;
            }
        }

        return -1;
    }

    private async Task<bool> IsUserAlreadyAssigned(CreateCourseUserDto courseUserDto) => await _unitOfWork.CourseUsers.GetUserAssign(courseUserDto.UserId, courseUserDto.CourseId) != null;
}
