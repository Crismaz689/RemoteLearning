namespace RemoteLearning.Infrastructure.Exceptions.Course;

public class CourseDoesNotExists : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public CourseDoesNotExists() { }

    public CourseDoesNotExists(string message) : base(message) { }

    public CourseDoesNotExists(string message, Exception innerException) : base(message, innerException) { }

    public CourseDoesNotExists(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
