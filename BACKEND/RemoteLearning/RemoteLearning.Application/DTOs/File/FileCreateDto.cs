namespace RemoteLearning.Application.DTOs.File;

public class FileCreateDto
{
    public IFormFile File { get; set; }

    public string Description { get; set; }

    public long SectionId { get; set; }
}
