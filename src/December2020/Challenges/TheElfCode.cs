using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    public class TheElfCode : IChallenge
    {
        private readonly ILogger<TheElfCode> _logger;

        public TheElfCode(ILogger<TheElfCode> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            
        }
    }
}
