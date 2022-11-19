namespace RemoteLearning.Infrastructure.Exceptions.Account;

public class EnteredNoPasswordException : BaseException
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;
}
