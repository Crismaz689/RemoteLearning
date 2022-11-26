namespace RemoteLearning.Infrastructure.Helpers.Mappings;

public class TextQuestionProfile : Profile
{
	public TextQuestionProfile()
	{
		CreateMap<CreateTextQuestionDto, TextQuestion>();
		CreateMap<TextQuestion, TextQuestionDto>();
	}
}
