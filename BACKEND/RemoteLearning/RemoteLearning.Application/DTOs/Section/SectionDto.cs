using RemoteLearning.Application.DTOs.File;
using File = RemoteLearning.Domain.Entities.File;

namespace RemoteLearning.Application.DTOs.Section;

public class SectionDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime Date { get; set; }

    public IEnumerable<FileDto> Files { get; set; }
}
