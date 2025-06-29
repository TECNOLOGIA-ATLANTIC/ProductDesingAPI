using AtlanticProductDesing.Application.Contracts.Infrastructure;
using AtlanticProductDesing.Application.Models;
using Microsoft.Extensions.Options;
using NLog;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace AtlanticProductDesing.Infrastruture.Email
{/// <summary>
/// clase para manejar el servicio de email
/// </summary>
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }

        private readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private IFileSystemService _fileSystemService;
        private string _sendGridApiKey;

        public EmailService(IOptions<EmailSettings> emailSettings, IFileSystemService fileSystemService)
        {
            _emailSettings = emailSettings.Value;
            _fileSystemService = fileSystemService;
            _sendGridApiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY") ?? _emailSettings.ApiKey;
        }

        public async Task<bool> SendEmail(Application.Models.Email email)
        {
            var client = new SendGridClient(_sendGridApiKey);
            var myMessage = new SendGridMessage();

            var subject = email.Subject;
            if (_emailSettings.ReplaceTo)
            {
                email.To = "jonathan.uzcategui.g@gmail.com";
            }
            ;

            var to = new EmailAddress(email.To);
            var emailBody = email.Body;

            var from = new EmailAddress
            {
                Email = "juzcategui@wcslat.com",
                Name = "Registro AtlanticProductClient"
            };

            var sendGridMesage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
            if (email.emailAttachments != null)
                foreach (EmailAttachment item in email.emailAttachments)
                {
                    using (var fileStream = File.OpenRead(item.FilePath))
                    {
                        await sendGridMesage.AddAttachmentAsync(item.FileName, fileStream, item.Type, item.Disposition, item.ContentId);
                    }
                }

            var response = await client.SendEmailAsync(sendGridMesage);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }

            _logger.Error("El email no se pudo enviar");

            return false;

        }
    }
}
