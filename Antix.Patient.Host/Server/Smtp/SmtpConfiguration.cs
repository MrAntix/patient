using Antix.Patient.Host.Properties;

namespace Antix.Patient.Host.Server.Smtp
{
    public static class SmtpConfiguration
    {
        public static IServiceCollection ConfigureSmtp(
            this IServiceCollection services,
            SmtpSettings settings
            )
        {
            return services
                .AddSingleton(settings)
                .AddTransient<ISmtpService, SmtpService>();
        }
    }
}
