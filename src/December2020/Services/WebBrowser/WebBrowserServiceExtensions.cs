using Microsoft.Extensions.DependencyInjection;

namespace Janda.CTF
{
    public static class WebBrowserServiceExtensions
    {
        public static IServiceCollection AddWebBrowserService(this IServiceCollection services)
        {
            return services.AddTransient<IWebBrowserService, WebBrowserService>();
        }
    }
}
