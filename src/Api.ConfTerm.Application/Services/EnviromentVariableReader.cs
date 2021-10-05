using Api.ConfTerm.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Api.ConfTerm.Application.Services
{
    public class EnviromentVariableReader : IEnviromentVariableReader
    {
        string IEnviromentVariableReader.DatabaseUrl => GetEnviromentVariable("DATABASE_URL");
        string[] IEnviromentVariableReader.AllowedOrigins => GetEnviromentVariable<string[]>("AllowedOrigins");
        string IEnviromentVariableReader.JwtSecret => GetEnviromentVariable("JWT_SECRET");
        Superuser IEnviromentVariableReader.Superuser => GetEnviromentVariable<Superuser>("Superuser");

        protected static string GetEnviromentVariable(string variableName) => Environment.GetEnvironmentVariable(variableName);
        protected static TObject GetEnviromentVariable<TObject>(string variableName) => JsonSerializer.Deserialize<TObject>(GetEnviromentVariable(variableName));
    }
}
