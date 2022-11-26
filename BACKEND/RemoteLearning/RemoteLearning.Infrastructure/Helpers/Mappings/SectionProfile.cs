namespace RemoteLearning.Infrastructure.Helpers.Mappings;

public class SectionProfile : Profile
{
    public SectionProfile()
    {
        CreateMap<CreateSectionDto, Section>();
        CreateMap<Section, SectionDto>();
    }
}
