using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    [Challenge(Flag = "santapass")]
    public class PointOfSalePasswordRecovery : IChallenge
    {
        private readonly ILogger<PointOfSalePasswordRecovery> _logger;

        public PointOfSalePasswordRecovery(ILogger<PointOfSalePasswordRecovery> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {
            _logger.LogInformation("Install {command}", "npm install -g --engine-strict asar");
            _logger.LogInformation("Run {command}", "asar e app.asar .\\app");                       
        }
    }
}
