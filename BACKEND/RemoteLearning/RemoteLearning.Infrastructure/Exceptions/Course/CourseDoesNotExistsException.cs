namespace RemoteLearning.Infrastructure.Exceptions.Course;

public class CourseDoesNotExistsException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public CourseDoesNotExistsException() { }

    public CourseDoesNotExistsException(string message) : base(message) { }

    public CourseDoesNotExistsException(string message, Exception innerException) : base(message, innerException) { }

    public CourseDoesNotExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
