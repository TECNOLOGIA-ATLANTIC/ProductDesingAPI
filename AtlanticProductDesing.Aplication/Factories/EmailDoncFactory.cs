using AtlanticProductDesing.Application.Models;
using Microsoft.Extensions.Configuration;

namespace AtlanticProductDesing.Application.Factories
{
    public class EmailDoncFactory : IEmailDoncFactory
    {
        private readonly IConfiguration _configuration;
        public EmailDoncFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Email BuildEmailDonc(string body)
        {
            List<EmailAttachment> listAttachment = new();

            listAttachment.Add(new EmailAttachment
            {
                FilePath = Directory.GetCurrentDirectory() + @"\Assets\Image\BodyImageEmail\logo.png",
                Type = "image/png",
                ContentId = "logo",
                Disposition = "inline",
                FileName = "logo.png"
            });

            string head = "<div style='text-align: center;'><img src='cid:logo' height = '50px'/></div>";

            string footer = $"<p style='color:#000000'>  Este mensaje ha sido generado automáticamente.";
            footer += $"Si necesitas ayudas o tienes preguntas, envía un correo a XXXXXXX@XXXXXX.com.";
            footer += $"<p></p>";
            footer += $"<p style='color:#000000'> Gracias </p>";

            string bodyEmail = $"{head}<br>{body}<br>{footer}";

            Email email = new()
            {
                To = "",
                Body = bodyEmail,
                From = _configuration.GetSection("System").GetSection("SystemFromEmail").Value,
                Subject = "",
                emailAttachments = listAttachment
            };

            return email;
        }
    }
}
