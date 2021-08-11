using Api.ConfTerm.Domain.Interfaces.Services;
using System;

namespace Api.ConfTerm.Application.Services
{
    public class EnviromentVariableReader : IEnviromentVariableReader
    {
        string IEnviromentVariableReader.DatabaseUrl => Environment.GetEnvironmentVariable("DATABASE_URL");
    }
}
