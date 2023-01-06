namespace RemoteLearning.Infrastructure.Exceptions.File;

public class CreateFileNoPermissionException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public CreateFileNoPermissionException() { }

    public CreateFileNoPermissionException(string message) : base(message) { }

    public CreateFileNoPermissionException(string message, Exception innerException) : base(message, innerException) { }

    public CreateFileNoPermissionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
