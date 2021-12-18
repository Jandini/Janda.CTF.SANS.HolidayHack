using Microsoft.Extensions.DependencyInjection;

namespace Janda.CTF
{
    public static class S3ScannerExtensions
    {
        public static IServiceCollection AddS3Scanner(this IServiceCollection services)
        {
            return services.AddTransient<IS3Scanner, S3Scanner>();
        }
    }
}
