namespace RemoteLearning.Infrastructure.Exceptions.Account;

public class EnteredNoPasswordException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public EnteredNoPasswordException() { }

    public EnteredNoPasswordException(string message) : base(message) { }

    public EnteredNoPasswordException(string message, Exception innerException) : base(message, innerException) { }

    public EnteredNoPasswordException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
