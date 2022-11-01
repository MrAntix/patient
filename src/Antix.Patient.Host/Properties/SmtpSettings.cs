namespace Antix.Patient.Host.Properties;

/// <summary>
/// Setting for the SMTP client service
/// </summary>
/// <param name="Host">Host (localhost)</param>
/// <param name="Port">Port (25)</param>
/// <param name="FromAddress">From Address (admin@localhost)</param>
/// <param name="UserName">User name (not required)</param>
/// <param name="Password">Password (not required)</param>
/// <param name="UseDefaultCredentials">Use default credentials (true)</param>
/// <param name="PickupDirectory">Directory where files are written for processing by local smtp server (not required)</param>
public sealed record class SmtpSettings(
    string Host = "localhost",
    int Port = 25,
    string FromAddress = "admin@localhost",
    string? UserName = null, string? Password = null,
    bool UseDefaultCredentials = true,
    string? PickupDirectory = null
    )
{
    /// <summary>
    /// Default instance
    /// </summary>
    public static readonly SmtpSettings Default = new();
}
