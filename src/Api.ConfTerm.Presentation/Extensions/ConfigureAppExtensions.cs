using Api.ConfTerm.Data.Contexts;
using Api.ConfTerm.Domain.Interfaces.Services;
using Api.ConfTerm.Presentation.Objects;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace Api.ConfTerm.Presentation.Extensions
{
    public static class ConfigureAppExtensions
    {
        private record Superuser
        {
            public string Username { get; set; }
            public string Password { get; set; }
        };

        public static void AddSwagger(this IApplicationBuilder app, SetupInformationContext setupInformation, IServiceScope scope)
        {
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/swagger/{documentname}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "API Conf-Term");
                c.RoutePrefix = "api/swagger";
            });
        }

        public static void EnsureSeed(SetupInformationContext setupInformation, IServiceScope scope)
        {
            var hashingSerivce = scope.ServiceProvider.GetService<IHashingService>();
            var context = scope.ServiceProvider.GetService<MeasurementContext>();

            context.Database.EnsureCreated();

            if (!context.Users.Any())
            {
                var superuser = setupInformation.EnviromentVariableReader.Superuser;
                context.Users.Add(superuser.ToUser(hashingSerivce));
            }

            context.SaveChanges();
        }

        public static IApplicationBuilder ConfigureExceptions(this IApplicationBuilder app, SetupInformationContext setupInformation)
        {
            if (setupInformation.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            return app;
        }
    }
}
