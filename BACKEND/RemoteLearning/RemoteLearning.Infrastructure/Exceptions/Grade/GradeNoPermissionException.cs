namespace RemoteLearning.Infrastructure.Exceptions.Grade;

public class GradeNoPermissionException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public GradeNoPermissionException() { }

    public GradeNoPermissionException(string message) : base(message) { }

    public GradeNoPermissionException(string message, Exception innerException) : base(message, innerException) { }

    public GradeNoPermissionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
