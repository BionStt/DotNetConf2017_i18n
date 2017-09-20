using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace CustomProvider
{
    public static class CustomLocalizationServiceCollectionExtensions
    {
        public static void AddCustomLocalization(this IServiceCollection services)
        {
            services.AddSingleton<IStringLocalizerFactory, CustomStringLocalizerFactory>();
            services.AddTransient(typeof(IStringLocalizer<>), typeof(StringLocalizer<>));
        }
    }
}