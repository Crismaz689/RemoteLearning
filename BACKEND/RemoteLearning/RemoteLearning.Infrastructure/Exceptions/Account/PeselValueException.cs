namespace RemoteLearning.Infrastructure.Exceptions.Account;

public class PeselValueException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public PeselValueException() { }

    public PeselValueException(string message) : base(message) { }

    public PeselValueException(string message, Exception innerException) : base(message, innerException) { }

    public PeselValueException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
