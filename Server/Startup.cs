using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace Server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Includes support for Razor Pages and controllers.
            services.AddMvc();


        
        }

       public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

 private static void HandleMapTest2(IApplicationBuilder app)
    {
        app.Run(async context =>
        {
            await context.Response.WriteAsync("Map Test 2");
        });
    }


        public void Configure(IApplicationBuilder app)
        {
          //  app.UseMvc();
          app.Map("/hello",HandleMapTest2);

 
//app.UseMiddleware<RequestCultureMiddleware>();
                app.UseMvc(routes =>
            {
                
                routes.MapRoute(
                    name: "default",
                    template: "api/{controller=Home}/{action=Index}");

              /*  routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
                    */
            });
        }
    }
}