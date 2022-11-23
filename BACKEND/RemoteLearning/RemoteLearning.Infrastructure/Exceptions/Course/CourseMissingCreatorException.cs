namespace RemoteLearning.Infrastructure.Exceptions.Course;

public class CourseMissingCreatorException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public CourseMissingCreatorException() { }

    public CourseMissingCreatorException(string message) : base(message) { }

    public CourseMissingCreatorException(string message, Exception innerException) : base(message, innerException) { }

    public CourseMissingCreatorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
