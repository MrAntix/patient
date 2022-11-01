using Antix.Patient.Host.Properties;
using System.Net;
using System.Net.Mail;

namespace Antix.Patient.Host.Server.Smtp
{
    public sealed class SmtpService :
            ISmtpService
    {
        readonly SmtpClient _client;
        readonly SmtpSettings _settings;

        public SmtpService(
            SmtpSettings settings
            )
        {
            _client = new SmtpClient(
                settings.Host, settings.Port
                );

            if (!string.IsNullOrWhiteSpace(settings.UserName))
                _client.Credentials = new NetworkCredential(
                    settings.UserName,
                    settings.Password
                    );

            else
                _client.UseDefaultCredentials
                    = settings.UseDefaultCredentials;

            if (string.IsNullOrEmpty(settings.PickupDirectory))
                _client.PickupDirectoryLocation = settings.PickupDirectory;

            _settings = settings;
        }

        Task ISmtpService
            .SendAsync(MailMessage message)
        {
            if (message.From == null)
                message.From = new MailAddress(_settings.FromAddress);

            return _client.SendMailAsync(message);
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
