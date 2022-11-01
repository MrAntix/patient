using System.Net.Mail;

namespace Antix.Patient.Host.Server.Smtp
{
    public interface ISmtpService : IDisposable
    {
        Task SendAsync(MailMessage message);
    }
}
