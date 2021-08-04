using Api.ConfTerm.Application.Objects;
using Api.ConfTerm.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api.ConfTerm.Application.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        private record Superuser
        {
            public string Username { get; set; }
            public string Password { get; set; }
        };
        public static void EnsureSeed(this IApplicationBuilder app, SetupInformationContext setupInformation)
        {
            if (setupInformation.Environment.IsDevelopment())
            {
                var context = app.ApplicationServices.GetService<MeasurementContext>();
                context.Database.EnsureCreated();

                var superUser = setupInformation.Configuration.GetSection(nameof(Superuser)).Get<Superuser>();
                //var firstProfile = context.Profiles.FirstOrDefault(b => b.Username == superUser.Username);
                //if (firstProfile == null)
                //{
                //    var salt = HashingHelper.GenerateSalt();
                //    var hash = HashingHelper.GenerateHash(superUser.Password, salt);
                //    var profile = new Profile
                //    {
                //        Id = 1,
                //        Username = superUser.Username,
                //        Role = Role.Seller.Id,
                //        Salt = salt,
                //        Hash = hash
                //    };
                //    var profileHistory = new ProfileHistoric
                //    {
                //        Hash = hash,
                //        Salt = salt,
                //        Id = 1,
                //        Profile = profile
                //    };
                //    profile.Historics.Add(profileHistory);
                //    context.Profiles.Add(profile);
                //}

                context.SaveChanges();
            }
        }
    }
}
