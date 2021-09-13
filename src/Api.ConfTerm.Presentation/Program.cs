using Api.ConfTerm.Application.Services;
using Api.ConfTerm.Presentation.Objects;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Api.ConfTerm.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup(builder =>
                    {
                        var enviromentVariableReader = new EnviromentVariableReader();
                        var startupContext = new SetupInformationContext(builder.Configuration, builder.HostingEnvironment, enviromentVariableReader);
                        return new Startup(startupContext);
                    });
                });
    }
}
