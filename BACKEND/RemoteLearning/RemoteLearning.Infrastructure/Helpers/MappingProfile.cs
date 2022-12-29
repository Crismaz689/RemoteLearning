using RemoteLearning.Application.DTOs.File;
using File = RemoteLearning.Domain.Entities.File;

namespace RemoteLearning.Infrastructure.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        AddAccountMappings();
        AddCourseMappings();
        AddCourseUserMappings();
        AddSectionMappings();
        AddFileMappings();
        AddTestMappings();
        AddTextQuestionMappings();
    }

    private void AddTextQuestionMappings()
    {
        CreateMap<CreateTextQuestionDto, TextQuestion>();
        CreateMap<TextQuestion, TextQuestionDto>();
    }

    private void AddTestMappings()
    {
        CreateMap<CreateTestDto, Test>();
        CreateMap<Test, TestDto>();
    }

    private void AddSectionMappings()
    {
        CreateMap<CreateSectionDto, Section>();
        CreateMap<Section, SectionDto>();
    }

    private void AddCourseUserMappings()
    {
        CreateMap<CreateCourseUserDto, CourseUser>();
    }

    private void AddCourseMappings()
    {
        CreateMap<Course, CourseDto>()
            .ForMember(dest => dest.CreatorFirstName, map => map.MapFrom(src => src.Creator.UserDetails.FirstName))
            .ForMember(dest => dest.CreatorSurname, map => map.MapFrom(src => src.Creator.UserDetails.Surname));
        CreateMap<CourseAllDataDto, CourseDto>();

        CreateMap<Course, CourseAllDataDto>();
        CreateMap<CreateCourseDto, Course>();
        CreateMap<UpdateCourseDto, Course>();
    }

    private void AddFileMappings()
    {
        CreateMap<File, FileDto>();
    }

    private void AddAccountMappings()
    {
        CreateMap<CreateAccountDto, UserDetails>();
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.RoleName, map => map.MapFrom(src => src.Role.Name));
    }
}
