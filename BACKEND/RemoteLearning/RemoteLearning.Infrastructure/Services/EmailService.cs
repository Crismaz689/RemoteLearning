namespace RemoteLearning.Infrastructure.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;

    private readonly AppSettings _settings;
    private readonly SmtpClient _smtp;

    public EmailService(IConfiguration config, IOptions<AppSettings> settings)
    {
        _config = config;
        _settings = settings.Value;
        _smtp = new SmtpClient();
        CreateConnection().Wait();
    }

    ~EmailService()
    {
        _smtp.Disconnect(true); // disc async
    }

    public async Task SendCredentials(string username, string password, string recipientEmailAddress)
    {
        MimeMessage email = new MimeMessage();
        StringBuilder message = new StringBuilder("<div>");
        message.Append("<h3>Wiadomość wygenerowana automatycznie, prosimy na nią nie odpowiadać.</h3>");
        message.Append($"<p>Twoje dane logowania to:<p>Login: <b>{username}</b><br>Hasło: <b>{password}</b></p></p>");
        message.Append("</div>");

        email.From.Add(MailboxAddress.Parse(_settings.Smtp.From));
        email.To.Add(MailboxAddress.Parse(recipientEmailAddress));
        email.Subject = "Dane logowania do platformy RL";
        email.Body = new TextPart(TextFormat.Html)
        {
            Text = message.ToString()
        };

        await SendEmail(email);
    }

    private async Task SendEmail(MimeMessage message)
    {
        await _smtp.SendAsync(message);
    }

    private async Task CreateConnection()
    {
        await _smtp.ConnectAsync(_settings.Smtp.Host, _settings.Smtp.Port, SecureSocketOptions.StartTls);
        await _smtp.AuthenticateAsync(_settings.Smtp.Username, _settings.Smtp.Password);
    }
}