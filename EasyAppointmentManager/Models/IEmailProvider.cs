using SendGrid.Helpers.Mail;
using SendGrid;

namespace EasyAppointmentManager.Models
{
    public interface IEmailProvider
    {
        Task SendEmailAsync(string toEmail, string fromEmail, string subject, string message, string htmlMessage);


    }

    public class EmailProviderSendGrid: IEmailProvider
    {
        private readonly IConfiguration _config;
        public EmailProviderSendGrid(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string toEmail, string fromEmail, string subject, string message, string htmlMessage)
        {
            var apiKey = _config.GetSection("SendGridKey").Value;
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(_config.GetSection("FromEmail").Value, "EasyAppointmentManager-DevTeam"),
                Subject = "News from EasyAppointmentManager-DevTeam",
                PlainTextContent = "with the latest updates from our developers team",
                HtmlContent = "<strong>with the latest updates from our developers team</strong>"
            };
            msg.AddTo(new EmailAddress(_config.GetSection("FromEmail").Value, "EasyAppointmentManager-DevTeam"));
            // var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}
