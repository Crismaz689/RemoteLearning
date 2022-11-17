namespace RemoteLearning.Infrastructure.Helpers.Mappings;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateAccountMap();
    }

    private void CreateAccountMap()
    {
        CreateMap<CreateAccountDto, UserDetails>();
    }
}
