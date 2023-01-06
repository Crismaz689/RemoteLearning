using File = RemoteLearning.Domain.Entities.File;

namespace RemoteLearning.Infrastructure.Services;

public class FileService : IFileService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _contextAccessor;
    public FileService(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor, IMapper mapper) => 
        (_unitOfWork, _contextAccessor, _mapper) = (unitOfWork, contextAccessor, mapper);

    public async Task<string> UploadFile(FileCreateDto fileDto, string userId)
    {
        var section = await _unitOfWork.Sections.GetById(fileDto.SectionId);
        var user = await _unitOfWork.Users.GetById(Convert.ToInt64(userId));

        if (!await DoesUserHasPermission(section.CourseId, userId) && user.RoleId != 1)
        {
            throw new CreateFileNoPermissionException("You do not have permissions to upload the file.");
        }

        var path = Path.Combine(Directory.GetCurrentDirectory(), "uploads", fileDto.File.FileName);

        using (var fileStream = new FileStream(path, FileMode.Create))
        {
            fileDto.File.CopyTo(fileStream);
        }

        var url = _contextAccessor.HttpContext.Request.Scheme + "://" + _contextAccessor.HttpContext.Request.Host + _contextAccessor.HttpContext.Request.PathBase;

        File fileToUpload = new File()
        {
            Extension = fileDto.File.FileName.Split(".").Last() ?? "",
            Size = fileDto.File.Length,
            Name = fileDto.File.FileName,
            Path = path,
            MimeType = fileDto.File.ContentType,
            SectionId = fileDto.SectionId,
            Description = fileDto.Description
        };

        await _unitOfWork.Files.Create(fileToUpload);

        return await _unitOfWork.SaveChangesAsync() != 0 ?
            Path.Combine(url + "/uploads/" + fileDto.File.FileName) :
            string.Empty;
    }

    public async Task<FileDownloadDto> DownloadFile(long id)
    {
        var file = await _unitOfWork.Files.GetById(id);
        var fileByte = await System.IO.File.ReadAllBytesAsync(file.Path);

        return new FileDownloadDto()
        {
            Data = $"data:image / png; base64, {Convert.ToBase64String(fileByte)}",
            FullName = file.Name
        };
    }

    public async Task<bool> DeleteFile(long id)
    {
        var file = await _unitOfWork.Files.GetById(id);

        if (file != null)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "uploads", file.Name);
            System.IO.File.Delete(path);
            await _unitOfWork.Files.Delete(id);

            return await _unitOfWork.SaveChangesAsync() != 0;
        }

        return false;
    }

    private async Task<bool> DoesUserHasPermission(long courseId, string userId) => await _unitOfWork.Users.GetCreatedCourse(courseId, Convert.ToInt64(userId)) != null;
}
