
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Server
{
public class RequestCultureMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestCultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
              context.Response.WriteAsync("Hello World!");

            var cultureQuery = context.Request.Query["culture"];
            if (string.IsNullOrWhiteSpace(cultureQuery))
            {
                var culture = new CultureInfo(cultureQuery);

                CultureInfo.CurrentCulture = culture;
                CultureInfo.CurrentUICulture = culture;
                
                context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(culture));

            }

            // Call the next delegate/middleware in the pipeline
            return this._next(context);
        }
    }
}