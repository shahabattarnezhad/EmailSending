using SendEmail.DTOs;

namespace SendEmail.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDto emailDto);
    }
}
