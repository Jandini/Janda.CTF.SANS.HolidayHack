using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    [Challenge(Flag = "proxmark")]
    public class UncoverSantasGiftList : IChallenge
    {
        private readonly ILogger<UncoverSantasGiftList> _logger;

        public UncoverSantasGiftList(ILogger<UncoverSantasGiftList> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            _logger.LogInformation("Open {tool} and use Twirl option.", "https://www.photopea.com/");
        }
    }
}
