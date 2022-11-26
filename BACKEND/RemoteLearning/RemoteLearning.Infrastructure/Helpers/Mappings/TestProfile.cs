namespace RemoteLearning.Infrastructure.Helpers.Mappings;

public class TestProfile : Profile
{
	public TestProfile()
	{
		CreateMap<CreateTestDto, Test>();
		CreateMap<Test, TestDto>();
	}
}
