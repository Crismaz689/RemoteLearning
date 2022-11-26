namespace RemoteLearning.Infrastructure.Exceptions.Sections;

public class CreateSectionNoPermissionException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public CreateSectionNoPermissionException() { }

    public CreateSectionNoPermissionException(string message) : base(message) { }

    public CreateSectionNoPermissionException(string message, Exception innerException) : base(message, innerException) { }

    public CreateSectionNoPermissionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
