using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    [Challenge(Type = "Objective", Number = 11, Name = "Naughty/Nice List with Blockchain Investigation Part 2", Points = 5)]
    public class BlockchainInvestigationPart2 : IChallenge
    {
        private readonly ILogger<BlockchainInvestigationPart2> _logger;

        public BlockchainInvestigationPart2(ILogger<BlockchainInvestigationPart2> logger)
        {
            _logger = logger;
        }

        public void Objective()
        {
            @"
                The SHA256 of Jack's altered block is: 58a3b9335a6ceb0234c12d35a0564c4e f0e90152d0eb2ce2082383b38028a90f. 
                If you're clever, you can recreate the original version of that block by changing the values of only 4 bytes. 
                Once you've recreated the original block, what is the SHA256 of that block?

            ".Blog(_logger);
        }

        public void Run()
        {

        }
    }
}
