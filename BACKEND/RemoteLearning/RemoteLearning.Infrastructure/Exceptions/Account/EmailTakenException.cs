namespace RemoteLearning.Application.Exceptions.Account;

public class EmailTakenException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public EmailTakenException() { }

    public EmailTakenException(string message) : base(message) { }

    public EmailTakenException(string message, Exception innerException) : base(message, innerException) { }

    public EmailTakenException(SerializationInfo info, StreamingContext context, int statusCode) : base(info, context) { }
}
