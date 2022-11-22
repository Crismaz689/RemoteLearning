namespace RemoteLearning.Infrastructure.Exceptions.Account;

public class EnteredNoPeselException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public EnteredNoPeselException() { }

    public EnteredNoPeselException(string message) : base(message) { }

    public EnteredNoPeselException(string message, Exception innerException) : base(message, innerException) { }

    public EnteredNoPeselException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
