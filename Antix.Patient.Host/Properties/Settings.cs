namespace Antix.Patient.Host.Properties
{
  public class Settings
  {
    public AppSettings App { get; init; } = AppSettings.Default;
    public SmtpSettings Smtp { get; init; } = SmtpSettings.Default;

    public int ShutdownTimeoutSeconds { get; init; } = 15;

    public static readonly Settings Default = new();
  }
}
