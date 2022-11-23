namespace RemoteLearning.Infrastructure.Exceptions.Course;

public class CourseAlreadyExistsException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public CourseAlreadyExistsException() { }

    public CourseAlreadyExistsException(string message) : base(message) { }

    public CourseAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }

    public CourseAlreadyExistsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
