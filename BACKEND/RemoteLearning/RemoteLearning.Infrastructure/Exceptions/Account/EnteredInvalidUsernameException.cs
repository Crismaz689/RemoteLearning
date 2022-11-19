namespace RemoteLearning.Application.Exceptions.Account;

public class EnteredInvalidUsernameException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public EnteredInvalidUsernameException() { }

    public EnteredInvalidUsernameException(string message) : base(message) { }

    public EnteredInvalidUsernameException(string message, Exception innerException) : base(message, innerException) { }

    public EnteredInvalidUsernameException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
