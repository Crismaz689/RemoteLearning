namespace RemoteLearning.Application.Exceptions.Account;

public class EnteredInvalidPasswordException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public EnteredInvalidPasswordException() { }

    public EnteredInvalidPasswordException(string message) : base(message) { }

    public EnteredInvalidPasswordException(string message, Exception innerException) : base(message, innerException) { }

    public EnteredInvalidPasswordException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
