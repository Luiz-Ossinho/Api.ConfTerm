using Api.ConfTerm.Data.Contexts;
using Api.ConfTerm.Domain.Entities;
using Api.ConfTerm.Domain.Interfaces.Services;
using Api.ConfTerm.Domain.ValueObjects;
using Api.ConfTerm.Presentation.Objects;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
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

            var superUser = setupInformation.Configuration.GetSection(nameof(Superuser)).Get<Superuser>();
            var firstUser = context.Users.FirstOrDefault(b => b.Name == superUser.Username);
            if (firstUser == null)
            {
                var salt = hashingSerivce.GenerateSalt();
                var hash = hashingSerivce.GenerateHash(superUser.Password, salt);
                var user = new User
                {
                    Name = superUser.Username,
                    Salt = salt,
                    Password = hash,
                    Email = new Email("emailValido@confTerm.com"),
                    Type = UserType.Administrator
                };

                var housing = new Housing
                {
                    Identification = "Alojamento de Teste",
                    Owner = user
                };
                user.Housings.Add(housing);

                var now = DateTime.Now;
                var animalProduction = new AnimalProduction
                {
                    Housing = housing,
                    Birthday = now,
                    Equipament = "Prototipo de Teste",
                    MonitoringEnd = now.AddYears(2),
                    MonitoringStart = now
                };
                housing.AnimalProductions.Add(animalProduction);

                context.Users.Add(user);
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
