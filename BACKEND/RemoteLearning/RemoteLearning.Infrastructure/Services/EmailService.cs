namespace RemoteLearning.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;

    private readonly AppSettings _settings;
    private readonly SendGridClient _smtp;

    public EmailService(IConfiguration config, IOptions<AppSettings> settings)
    {
        _config = config;
        _settings = settings.Value;
        _smtp = new SendGridClient(_settings.Smtp.Key);
    }

    public async Task SendCredentials(string username, string password, string recipientEmailAddress)
    {
        StringBuilder message = new StringBuilder("<div>");
        message.Append("<h3>Wiadomość wygenerowana automatycznie, prosimy na nią nie odpowiadać.</h3>");
        message.Append($"<p>Twoje dane logowania to:<p>Login: <b>{username}</b><br>Hasło: <b>{password}</b></p></p>");
        message.Append("</div>");

        var email = new SendGridMessage()
        {
            From = new EmailAddress(_settings.Smtp.From, _settings.Smtp.Username),
            Subject = "Dane logowania",
            HtmlContent = message.ToString()
        };
        email.AddTo(new EmailAddress(recipientEmailAddress, username));

        await SendEmail(email);
    }

    private async Task SendEmail(SendGridMessage message)
    {
        await _smtp.SendEmailAsync(message);
    }
}