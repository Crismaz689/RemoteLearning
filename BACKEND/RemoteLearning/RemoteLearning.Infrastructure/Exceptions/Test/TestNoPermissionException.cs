namespace RemoteLearning.Infrastructure.Exceptions.Test;

public class TestNoPermissionException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public TestNoPermissionException() { }

    public TestNoPermissionException(string message) : base(message) { }

    public TestNoPermissionException(string message, Exception innerException) : base(message, innerException) { }

    public TestNoPermissionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
