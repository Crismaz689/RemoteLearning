namespace RemoteLearning.Infrastructure.Exceptions.Account;

public class PeselLengthException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public PeselLengthException() { }

    public PeselLengthException(string message) : base(message) { }

    public PeselLengthException(string message, Exception innerException) : base(message, innerException) { }

    public PeselLengthException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
