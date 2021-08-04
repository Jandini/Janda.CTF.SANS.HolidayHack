using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{  
    [Challenge(Name = "Hiddenyard",
        Brief = @"
            ...
        ")]
    public class Hiddenyard : IChallenge
    {
        private readonly ILogger<Hiddenyard> _logger;

        public Hiddenyard(ILogger<Hiddenyard> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {

        }
    }
}
