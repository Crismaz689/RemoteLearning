namespace RemoteLearning.Application.Exceptions.Account;

public class InvalidUsernameException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public InvalidUsernameException() { }

    public InvalidUsernameException(string message) : base(message) { }

    public InvalidUsernameException(string message, Exception innerException) : base(message, innerException) { }

    public InvalidUsernameException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
