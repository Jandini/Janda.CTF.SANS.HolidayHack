using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    [Challenge(Name = "Objective 11a: Naughty/Nice List with Blockchain Investigation Part 1", Points = 5)]
    public class BlockchainInvestigationPart1 : IChallenge
    {
        private readonly ILogger<BlockchainInvestigationPart1> _logger;

        public BlockchainInvestigationPart1(ILogger<BlockchainInvestigationPart1> logger)
        {
            _logger = logger;
        }
        

        public void Objective()
        {
            @"
                Even though the chunk of the blockchain that you have ends with block 129996, can you predict the nonce for block 130000? 
                Talk to Tangle Coalbox in the Speaker UNpreparedness Room for tips on prediction and Tinsel Upatree for more tips and tools. 

                (Enter just the 16-character hex value of the nonce)

            ".Blog(_logger);
        }


        public void Talks()
        {
            @"
                Prof. Qwerty Petabyte, Working with the Official Naughty/Nice Blockchain...                
                https://www.youtube.com/watch?v=reKsZ8E44vw


            ".Blog(_logger, "Talks");
        }

        public void Run()
        {

        }
    }
}
