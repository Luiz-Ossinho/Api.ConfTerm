using Api.ConfTerm.Application.Abstract.UseCases;
using Api.ConfTerm.Application.Services;
using Api.ConfTerm.Application.UseCases;
using Api.ConfTerm.Core.Interfaces.Services;
using Api.ConfTerm.Data.Contexts;
using Api.ConfTerm.Data.Repositories;
using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using Api.ConfTerm.Presentation.Objects;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;
using System;

namespace Api.ConfTerm.Presentation.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection AddDatabases(this IServiceCollection services, SetupInformationContext setupInformation)
        {
            if (setupInformation.Environment.IsDevelopment())
            {
                var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:", Cache = SqliteCacheMode.Shared };
                var sqliteConnection = new SqliteConnection(connectionStringBuilder.ToString());
                sqliteConnection.Open();
                return services.AddDbContext<MeasurementContext>(opt => opt.UseSqlite(sqliteConnection));
            }

            var databaseUrl = setupInformation.EnviromentVariableReader.DatabaseUrl;
            var connection = ParseDatabaseUrlToConnectionString(databaseUrl);

            return services.AddDbContextPool<MeasurementContext>(opt => opt.UseNpgsql(connection));
        }


        public static IServiceCollection AddRepositories(this IServiceCollection services, SetupInformationContext setupInformation)
        {
            services.AddScoped<IRepository<Measurement>, GenericRepository<Measurement>>()
                .AddScoped<IRepository<AnimalProduction>, GenericRepository<AnimalProduction>>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services, SetupInformationContext setupInformation)
        {
            services.AddScoped<IHashingService, HashingService>();
            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services, SetupInformationContext setupInformation)
        {
            services.AddScoped<IInsertMeasurementUseCase, InsertMeasurementUseCase>();
            return services;
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
