using Api.ConfTerm.Application.Services;
using Api.ConfTerm.Domain.Interfaces.Services;
using Api.ConfTerm.Presentation.Extensions;
using Api.ConfTerm.Presentation.Objects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.ConfTerm.Presentation
{
    public class Startup
    {
        private readonly SetupInformationContext SetupInformationContext;

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            var enviromentVariableReader = new EnviromentVariableReader();
            SetupInformationContext = new SetupInformationContext(configuration, environment, enviromentVariableReader);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDatabases(SetupInformationContext)
                .AddJwtAuthetication(SetupInformationContext)
                .AddRepositories(SetupInformationContext)
                .AddServices(SetupInformationContext)
                .AddUseCases(SetupInformationContext);

            services.AddHttpContextAccessor();
            services.AddScoped(sp => new UserInfoService(sp.GetRequiredService<IHttpContextAccessor>()) as IUserInfoService);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            ConfigureAppExtensions.EnsureSeed(SetupInformationContext, scope);

            app.ConfigureExceptions(SetupInformationContext);

            app.UseHttpsRedirection();
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
