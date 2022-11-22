namespace RemoteLearning.Application.Exceptions.Account;

public class InvalidPasswordException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public InvalidPasswordException() { }

    public InvalidPasswordException(string message) : base(message) { }

    public InvalidPasswordException(string message, Exception innerException) : base(message, innerException) { }

    public InvalidPasswordException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
