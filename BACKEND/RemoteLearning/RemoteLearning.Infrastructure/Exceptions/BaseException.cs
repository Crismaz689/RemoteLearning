namespace RemoteLearning.Infrastructure.Exceptions;

public abstract class BaseException : Exception
{
    public abstract int StatusCode { get; }

    public BaseException() { }

    public BaseException(string message) : base(message) { }

    public BaseException(string message, Exception innerException) : base(message, innerException) { }

    public BaseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
