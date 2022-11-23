namespace RemoteLearning.Infrastructure.Helpers.Mappings;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<Course, CourseDto>()
            .ForMember(dest => dest.CreatorFirstName, map => map.MapFrom(src => src.Creator.UserDetails.FirstName))
            .ForMember(dest => dest.CreatorSurname, map => map.MapFrom(src => src.Creator.UserDetails.Surname));

        CreateMap<CreateCourseDto, Course>();
        CreateMap<UpdateCourseDto, Course>();
        CreateMap<Course, CourseDto>();
    }
}
