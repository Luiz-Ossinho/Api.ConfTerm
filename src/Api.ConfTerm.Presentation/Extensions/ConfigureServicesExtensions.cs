using Api.ConfTerm.Application.Abstract.UseCases;
using Api.ConfTerm.Application.Services;
using Api.ConfTerm.Application.UseCases;
using Api.ConfTerm.Data.Contexts;
using Api.ConfTerm.Data.Repositories;
using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.Interfaces.Repositories;
using Api.ConfTerm.Domain.Interfaces.Services;
using Api.ConfTerm.Presentation.Objects;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using System;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace Api.ConfTerm.Presentation.Extensions
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection AddDatabases(this IServiceCollection services, SetupInformationContext setupInformation)
        {
            if (setupInformation.Environment.IsDevelopment())
            {
                //var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "Database.db", Cache = SqliteCacheMode.Default };
                var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ":memory:", Cache = SqliteCacheMode.Shared };
                var sqliteConnection = new SqliteConnection(connectionStringBuilder.ToString());
                sqliteConnection.Open();
                return services.AddDbContext<MeasurementContext>(opt =>
                {
                    opt.UseSqlite(sqliteConnection);
                });
            }

            var databaseUrl = setupInformation.EnviromentVariableReader.DatabaseUrl;
            var connection = ParseDatabaseUrlToConnectionString(databaseUrl);

            return services.AddDbContextPool<MeasurementContext>(opt => opt.UseNpgsql(connection));
        }


        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Measurement>, GenericRepository<Measurement>>()
                .AddScoped<IRepository<AnimalProduction>, GenericRepository<AnimalProduction>>()
                .AddScoped<IRepository<Housing>, GenericRepository<Housing>>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IRepository<Species>, GenericRepository<Species>>()
                .AddScoped<IRepository<BlackGlobeTemparuteHumidityIndexConfort>, GenericRepository<BlackGlobeTemparuteHumidityIndexConfort>>()
                .AddScoped<IRepository<TemperatureHumidityConfort>, GenericRepository<TemperatureHumidityConfort>>()
                .AddScoped<IRepository<TemperatureHumidityIndexConfort>, GenericRepository<TemperatureHumidityIndexConfort>>()
                ;
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IHashingService, HashingService>();
            services.AddScoped(sp => sp.GetRequiredService<MeasurementContext>() as IUnitOfWork);
            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IPerformLoginUseCase, PerformLoginUseCase>()
                .AddScoped<IInsertUserUseCase, InsertUserUseCase>()
                .AddScoped<IInsertHousingUseCase, InsertHousingUseCase>()
                .AddScoped<IInsertAnimalProductionUseCase, InsertAnimalProductionUseCase>()
                .AddScoped<IInsertMeasurementUseCase, InsertMeasurementUseCase>()
                .AddScoped<IInsertSpeciesUseCase, InsertSpeciesUseCase>()
                .AddScoped<IInsertTHIConfortUseCase, InsertTHIConfortUseCase>()
                .AddScoped<IInsertBGTHIConfortUseCase, InsertBGTHIConfortUseCase>()
                .AddScoped<IInsertTemperatureHumidityConfortUseCase, InsertTemperatureHumidityConfortUseCase>()
                //.AddScoped<IRemoveTHIConfortUseCase, RemoveTHIConfortUseCase>()
                //.AddScoped<IRemoveBGTHIConfortUseCase, RemoveBGTHIConfortUseCase>()
                //.AddScoped<IRemoveTemperatureHumidityConfortUseCase, RemoveTemperatureHumidityConfortUseCase>()
                //.AddScoped<IEditTHIConfortUseCase, EditTHIConfortUseCase>()
                //.AddScoped<IEditBGTHIConfortUseCase, EditBGTHIConfortUseCase>()
                //.AddScoped<IEditTemperatureHumidityConfortUseCase, EditTemperatureHumidityConfortUseCase>()
                //.AddScoped<IViewReportUseCase, ViewReportUseCase>()
                ;
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(opt =>
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API Conf-Term",
                    Description = "ASP.NET Core Web API para armazenar dados de conforto termico no estado de Sergipe",
                    Contact = new OpenApiContact
                    {
                        Name = "Luiz Eduardo de Jesus Santana",
                        Email = string.Empty,
                        Url = new Uri("https://www.linkedin.com/in/luiz-eduardo-7246061ba/"),
                    }
                }));
            return services;
        }

        public static IServiceCollection AddAppplicationInfoInjection(this IServiceCollection services)
        {
            services.AddSingleton<IEnviromentVariableReader, EnviromentVariableReader>();
            services.AddSingleton(sp => new SetupInformationContext(
                sp.GetRequiredService<IConfiguration>(),
                sp.GetRequiredService<IWebHostEnvironment>(),
                sp.GetRequiredService<IEnviromentVariableReader>()
            ));
            services.AddHttpContextAccessor();
            services.AddScoped(sp => new UserInfoService(sp.GetRequiredService<IHttpContextAccessor>()) as IUserInfoService);
            return services;
        }

        public static IServiceCollection AddJwtAuthetication(this IServiceCollection services, SetupInformationContext setupInformation)
        {
            var issuerSigninKey = Encoding.ASCII.GetBytes(setupInformation.Configuration["JwtSecret"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(issuerSigninKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddScoped(sp => new TokenService(issuerSigninKey) as ITokenService);

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
