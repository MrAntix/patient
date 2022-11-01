using Antix.Patient.Host.Properties;

namespace Antix.Patient.Host.Server
{
  public static class ServerServerConfiguration
    {
        public static IServiceCollection ConfigureServer(
            this IServiceCollection services,
            Settings settings
            )
        {
            services.AddControllers();

            services
                .AddSingleton(settings.App)
                .AddCors(options =>
                {
                });

            return services;
        }

        public static IApplicationBuilder UseServer(
            this IApplicationBuilder app
            )
        {
            return app
                .UseRouting()
                .UseCors()
                .UseEndpoints(o => o.MapControllers());
        }

        public static string GetResourceString(
            this Type type,
            string name
            )
        {
            var resource = $"{type.Namespace}.{name}";

            using var stream = type.Assembly.GetManifestResourceStream(resource);
            if (stream == null) throw new Exception($"Resource {resource} not found");

            using var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }
    }
}
