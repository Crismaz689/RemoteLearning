namespace RemoteLearning.Infrastructure.Exceptions.Course;

public class CourseNotAssignedToException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public CourseNotAssignedToException() { }

    public CourseNotAssignedToException(string message) : base(message) { }

    public CourseNotAssignedToException(string message, Exception innerException) : base(message, innerException) { }

    public CourseNotAssignedToException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
