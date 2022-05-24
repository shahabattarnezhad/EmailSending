using SendEmail.Services.EmailService;

namespace SendEmail.AppExtensions
{
    public static class Extensions
    {
        public static void ConfigureEmail(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
