using Api.ConfTerm.Core.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Api.ConfTerm.Application.Objects
{
    public class SetupInformationContext
    {
        public SetupInformationContext(IConfiguration configuration, IWebHostEnvironment environment, IEnviromentVariableReader enviromentVariableReader)
        {
            EnviromentVariableReader = enviromentVariableReader;
            Configuration = configuration;
            Environment = environment;
        }
        public IEnviromentVariableReader EnviromentVariableReader { get; }
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
    }
}
