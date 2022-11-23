namespace RemoteLearning.Infrastructure.Exceptions.CourseUser;

public class UserAlreadyAssigned : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public UserAlreadyAssigned() { }

    public UserAlreadyAssigned(string message) : base(message) { }

    public UserAlreadyAssigned(string message, Exception innerException) : base(message, innerException) { }

    public UserAlreadyAssigned(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
