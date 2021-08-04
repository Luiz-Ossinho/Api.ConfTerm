using Api.ConfTerm.Application.Objects;
using Api.ConfTerm.Data.Contexts;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System;

namespace Api.ConfTerm.Application.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection AddDatabases(this IServiceCollection services, SetupInformationContext setupInformation)
        {
            if (setupInformation.Environment.IsDevelopment())
            {
                var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:" };
                var sqliteConnection = new SqliteConnection(connectionStringBuilder.ToString());
                return services.AddDbContext<MeasurementContext>(opt => opt.UseSqlite(sqliteConnection));
            }

            var databaseUrl = setupInformation.EnviromentVariableReader.DatabaseUrl;
            var connection = ParseDatabaseUrlToConnectionString(databaseUrl);

            return services.AddDbContextPool<MeasurementContext>(opt => opt.UseNpgsql(connection));
        }

        private static string ParseDatabaseUrlToConnectionString(string databaseUrl)
        {
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };
            return builder.ToString();
        }
    }
}
