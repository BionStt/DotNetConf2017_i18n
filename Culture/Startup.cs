using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Localization;

namespace Culture
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Add the needed cultures to the list
            var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("es-ES"),
                new CultureInfo("de-DE"),
                new CultureInfo("fr-FR"),
                new CultureInfo("sv-SE")
            };

            // Set up the RequestLocalizationOptions w/ cultures
            var options = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            // Set the Localization Middleware
            app.UseRequestLocalization(options);

            // Tap into the app's request pipeline to output culture details
            app.Run(async (context) =>
            {
                context.Response.StatusCode = 200;
                context.Response.ContentType = "text/html; charset=utf-8";

                var detectedCultureName = CultureInfo.CurrentCulture.DisplayName;
                var detectedUiCultureName = CultureInfo.CurrentUICulture.DisplayName;

                var cultureTable =  "<html><body>"
                       + "<table border=\"1\" cellpadding=\"5\" style=\"border-collapse:collapse;\">"
                       + $"<tr><td>Detected Culture</td><td>{detectedCultureName}</td></tr>"
                       + $"<tr><td>Detected UI Culture</td><td>{detectedUiCultureName}</td></tr>"
                       + $"<tr><td>Today's Date</td><td>{DateTime.Now:D}</td></tr>"
                       + $"<tr><td>Culture's Formatted Number</td><td>{(1234567.89):n}</td></tr>"
                       + $"<tr><td>Culture's Currency</td><td>{(42):C}</td></tr>"
                       + "</table></body></html>";

                await context.Response.WriteAsync(cultureTable);
            });
        }
    }
}
