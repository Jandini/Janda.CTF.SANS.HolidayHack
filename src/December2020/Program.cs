using Janda.CTF.SANS.HolidayHack.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Janda.CTF.SANS.HolidayHack
{       
    class Program 
    {
        [CTF(Name = "SANS Holiday Hack, December 2020")]
        static void Main(string[] args) => CTF.Run(args, (services) => services
            .AddTransient<IS3Scanner, S3Scanner>()
            .AddDictionary());
    }
}