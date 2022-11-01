namespace Antix.Patient.Host.Properties;

public sealed record class AppSettings(
    string Id = "uk.co.antix.patient",
    string Name = "Patient",
    string RootUrl = "https://localhost:7249"
)
{
    public static readonly AppSettings Default = new();
}
