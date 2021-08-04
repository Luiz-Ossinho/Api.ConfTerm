using Api.ConfTerm.Core.Services;
using System;

namespace Api.ConfTerm.Services.General
{
    public class EnviromentVariableReader : IEnviromentVariableReader
    {
        string IEnviromentVariableReader.DatabaseUrl => Environment.GetEnvironmentVariable("DATABASE_URL");
    }
}
