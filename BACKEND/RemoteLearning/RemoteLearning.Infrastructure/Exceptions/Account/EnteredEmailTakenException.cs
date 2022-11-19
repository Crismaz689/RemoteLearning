namespace RemoteLearning.Application.Exceptions.Account;

public class EnteredEmailTakenException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public EnteredEmailTakenException() { }

    public EnteredEmailTakenException(string message) : base(message) { }

    public EnteredEmailTakenException(string message, Exception innerException) : base(message, innerException) { }

    public EnteredEmailTakenException(SerializationInfo info, StreamingContext context, int statusCode) : base(info, context) { }
}
