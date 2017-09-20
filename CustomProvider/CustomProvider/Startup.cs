using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace CustomProvider
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomLocalization();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IStringLocalizer<Startup> stringLocalizer) ////////////////////////
        {
            var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("it-IT"),
                new CultureInfo("ja-JP"),
                new CultureInfo("nl-NL"),
                new CultureInfo("ru-RU")
            };

            var options = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            app.UseRequestLocalization(options);

            app.Use(async (context, next) =>
            {
                context.Response.StatusCode = 200;
                context.Response.ContentType = "text/html; charset=utf-8";

                var detectedCultureName = CultureInfo.CurrentCulture.EnglishName;
                var detectedUiCultureName = CultureInfo.CurrentUICulture.EnglishName;

                var cultureTable = "<html><body>"
                                   + $"<h2>{stringLocalizer["Hello"]}!</h2><table border=\"1\" cellpadding=\"5\" style=\"border-collapse:collapse;\">"
                                   + $"<tr><td>{stringLocalizer["DetectedCulture"]}</td><td>{detectedCultureName}</td></tr>"
                                   + $"<tr><td>{stringLocalizer["DetectedUICulture"]}</td><td>{detectedUiCultureName}</td></tr>"
                                   + $"<tr><td>{stringLocalizer["CurrentDate"]}</td><td>{DateTime.Now:D}</td></tr>"
                                   + $"<tr><td>{stringLocalizer["FormattedNumber"]}</td><td>{(1234567.89):n}</td></tr>"
                                   + $"<tr><td>{stringLocalizer["CurrencyValue"]}</td><td>{(42):C}</td></tr></table>"
                                   + $"<h2>{stringLocalizer["Goodbye"]}</h2>"
                                   + "</body></html>";

                await context.Response.WriteAsync(cultureTable);
            });
        }
    }
}
