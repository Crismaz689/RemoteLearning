namespace RemoteLearning.Application.Services;

public interface IEmailService
{
    Task SendCredentials(string username, string password, string recipientEmailAddress);
}
