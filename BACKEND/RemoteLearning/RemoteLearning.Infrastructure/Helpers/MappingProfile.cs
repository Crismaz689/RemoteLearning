using RemoteLearning.Application.DTOs.UserTestResult;
using File = RemoteLearning.Domain.Entities.File;

namespace RemoteLearning.Infrastructure.Helpers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        AddAccountMappings();
        AddCourseMappings();
        AddSectionMappings();
        AddFileMappings();
        AddTestMappings();
        AddTextQuestionMappings();
        AddCategoryMappings();
        AddUserTestResultMappings();
        AddCourseUserMappings();
        AddGradeMappings();
    }

    private void AddTextQuestionMappings()
    {
        CreateMap<CreateTextQuestionDto, TextQuestion>();
        CreateMap<TextQuestion, TextQuestionDto>();
        CreateMap<TextQuestion, TextQuestionForStudentDto>();
    }

    private void AddCourseUserMappings()
    {
        CreateMap<CourseUser, CourseUserDto>()
            .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.User.UserDetails.FirstName))
            .ForMember(dest => dest.Surname, map => map.MapFrom(src => src.User.UserDetails.Surname));
    }

    private void AddTestMappings()
    {
        CreateMap<CreateTestDto, Test>();
        CreateMap<Test, TestDto>()
            .ForMember(dest => dest.TestResults, map => map.MapFrom(src => src.UserTestResults));
        CreateMap<Test, TestAdminDto>()
            .ForMember(dest => dest.TestName, map => map.MapFrom(src => src.Name))
            .ForMember(dest => dest.CourseName, map => map.MapFrom(src => src.Course.Name));
    }

    private void AddSectionMappings()
    {
        CreateMap<CreateSectionDto, Section>()
            .ForMember(dest => dest.ScheduleDate, map => map.MapFrom(src => src.Date));

        CreateMap<Section, SectionDto>()
            .ForMember(dest => dest.Date, map => map.MapFrom(src => src.ScheduleDate));
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

        CreateMap<User, UserDetailedDto>()
            .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.UserDetails.FirstName))
            .ForMember(dest => dest.Surname, map => map.MapFrom(src => src.UserDetails.Surname))
            .ForMember(dest => dest.Pesel, map => map.MapFrom(src => src.UserDetails.Pesel))
            .ForMember(dest => dest.Email, map => map.MapFrom(src => src.UserDetails.Email));
    }

    private void AddCategoryMappings()
    {
        CreateMap<Category, CategoryDto>();
    }

    private void AddUserTestResultMappings()
    {
        CreateMap<UserTestResult, UserTestResultDto>()
            .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.User.UserDetails.FirstName))
            .ForMember(dest => dest.Surname, map => map.MapFrom(src => src.User.UserDetails.Surname))
            .ForMember(dest => dest.FinishDate, map => map.MapFrom(src => src.CreationDate));
    }

    private void AddGradeMappings()
    {
        CreateMap<Grade, GradeDto>()
            .ForMember(dest => dest.CategoryName, map => map.MapFrom(src => src.Category.Name));
        CreateMap<CreateGradeDto, Grade>();

        CreateMap<Grade, GradeUserDto>()
            .ForMember(dest => dest.CourseName, map => map.MapFrom(src => src.Course.Name));

        CreateMap<Grade, GradeUserDetailedDto>()
            .ForMember(dest => dest.FirstName, map => map.MapFrom(src => src.User.UserDetails.FirstName))
            .ForMember(dest => dest.Surname, map => map.MapFrom(src => src.User.UserDetails.Surname));
    }
}
