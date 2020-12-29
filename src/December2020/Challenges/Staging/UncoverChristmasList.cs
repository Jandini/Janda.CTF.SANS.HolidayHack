using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    [Challenge(Type = "Objective", Number = 1, Name = "Uncover Christmas List", Points = 1, Flag = "proxmark")]
    public class UncoverChristmasList : IChallenge
    {
        private readonly ILogger<UncoverChristmasList> _logger;

        public UncoverChristmasList(ILogger<UncoverChristmasList> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            _logger.LogInformation("Open {tool} and use Twirl option.", "https://www.photopea.com/");
        }
    }
}
