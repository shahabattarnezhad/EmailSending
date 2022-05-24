using Microsoft.AspNetCore.Mvc;
using SendEmail.DTOs;
using SendEmail.Services.EmailService;

namespace SendEmail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }


        [HttpPost]
        public IActionResult SendEmail(EmailDto emailDto)
        {
            _emailService.SendEmail(emailDto);

            return Ok();
        }
    }
}
