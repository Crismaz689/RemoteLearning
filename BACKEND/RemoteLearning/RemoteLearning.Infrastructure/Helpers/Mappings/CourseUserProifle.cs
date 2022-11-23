namespace RemoteLearning.Infrastructure.Helpers.Mappings;

public class CourseUserProifle : Profile
{
	public CourseUserProifle()
	{
		CreateMap<CreateCourseUserDto, CourseUser>();
	}
}
