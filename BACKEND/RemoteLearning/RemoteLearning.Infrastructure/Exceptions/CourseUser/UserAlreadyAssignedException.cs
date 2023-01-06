namespace RemoteLearning.Infrastructure.Exceptions.CourseUser;

public class UserAlreadyAssingedException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public UserAlreadyAssingedException() { }

    public UserAlreadyAssingedException(string message) : base(message) { }

    public UserAlreadyAssingedException(string message, Exception innerException) : base(message, innerException) { }

    public UserAlreadyAssingedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
