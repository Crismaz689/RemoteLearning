namespace RemoteLearning.Application.Exceptions.Account;

public class PeselTakenException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public PeselTakenException() { }

    public PeselTakenException(string message) : base(message) { }

    public PeselTakenException(string message, Exception innerException) : base(message, innerException) { }

    public PeselTakenException(SerializationInfo info, StreamingContext context, int statusCode) : base(info, context) { }
}
