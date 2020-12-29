using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    [Challenge(Name = "Objective 11b: Naughty/Nice List with Blockchain Investigation Part 2", Points = 5)]
    public class BlockchainInvestigationPart2 : IChallenge
    {
        private readonly ILogger<BlockchainInvestigationPart2> _logger;

        public BlockchainInvestigationPart2(ILogger<BlockchainInvestigationPart2> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {

        }
    }
}
