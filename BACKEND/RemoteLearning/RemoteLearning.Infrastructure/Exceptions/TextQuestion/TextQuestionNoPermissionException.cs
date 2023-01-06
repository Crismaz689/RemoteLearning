namespace RemoteLearning.Infrastructure.Exceptions.TextQuestion;

public class TextQuestionNoPermissionException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.Unauthorized;

    public TextQuestionNoPermissionException() { }

    public TextQuestionNoPermissionException(string message) : base(message) { }

    public TextQuestionNoPermissionException(string message, Exception innerException) : base(message, innerException) { }

    public TextQuestionNoPermissionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
