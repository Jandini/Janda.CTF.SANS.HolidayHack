using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    public class BlockchainInvestigationPart1 : IChallenge
    {
        private readonly ILogger<BlockchainInvestigationPart1> _logger;

        public BlockchainInvestigationPart1(ILogger<BlockchainInvestigationPart1> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {

        }
    }
}
