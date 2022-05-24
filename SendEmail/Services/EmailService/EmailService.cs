using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using SendEmail.DTOs;

namespace SendEmail.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(EmailDto emailDto)
        {
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(emailDto.To));

            email.Subject = emailDto.Subject;

            email.Body = new TextPart(TextFormat.Html)
            {
                Text = emailDto.Body
            };

            using var smtp = new SmtpClient();
            smtp.Connect(host: _config.GetSection("EmailHost").Value,port: 587, SecureSocketOptions.StartTls);
            //smtp.Connect("smtp.gmail.com");
            //smtp.Connect("smtp.live.com");
            //smtp.Connect("smtp.office365.com");

            smtp.Authenticate(userName: _config.GetSection("EmailUserName").Value,
                              password: _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
