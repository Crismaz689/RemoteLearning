namespace RemoteLearning.Application.Services;

public interface IFileService
{ 
    Task<string> UploadFile(FileCreateDto fileDto, string userId);
    Task<bool> DeleteFile(long id);
    Task<FileDownloadDto> DownloadFile(long id);
}
