using Microsoft.Extensions.DependencyInjection;

namespace Janda.CTF
{
    public static class WebPageServiceExtensions
    {
        public static IServiceCollection AddWebPageService(this IServiceCollection services)
        {
            return services.AddTransient<IWebPageService, WebPageService>();
        }
    }
}
