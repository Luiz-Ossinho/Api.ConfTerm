using Api.ConfTerm.Presentation.Extensions;
using Api.ConfTerm.Presentation.Filters;
using Api.ConfTerm.Presentation.Objects;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.ConfTerm.Presentation
{
    public class Startup
    {
        private readonly SetupInformationContext SetupInformationContext;

        public Startup(SetupInformationContext setupInformationContext)
        {
            SetupInformationContext = setupInformationContext;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(opt=> {
                opt.Filters.Add<ValidationFilter>();
            }).AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase, true));
                opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });

            services.AddCors(SetupInformationContext)
                .AddDatabases(SetupInformationContext)
                .AddJwtAuthetication(SetupInformationContext)
                .AddSwagger()
                .AddAppplicationInfoInjection()
                .AddRepositories()
                .AddServices()
                .AddUseCases()
                .AddMapping()
                .AddValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            app.UseCors();

            ConfigureAppExtensions.EnsureSeed(SetupInformationContext, scope);
            app.AddSwagger(SetupInformationContext, scope);

            app.ConfigureExceptions(SetupInformationContext);

            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
