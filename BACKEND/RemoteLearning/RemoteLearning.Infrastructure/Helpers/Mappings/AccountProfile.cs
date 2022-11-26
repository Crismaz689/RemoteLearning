namespace RemoteLearning.Infrastructure.Helpers.Mappings;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateAccountMap();
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.RoleName, map => map.MapFrom(src => src.Role.Name));
    }

    private void CreateAccountMap()
    {
        CreateMap<CreateAccountDto, UserDetails>();
    }
}
