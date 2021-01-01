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
            @"
                Wow, it really was all about abusing the pseudo-random sequence!
                I've been thinking, do you think someone could try and cheat the Naughty/Nice Blockchain with this same technique?

                I remember you told us about how if you have control over to bytes in a file, it's easy to create MD5 hash collisions.

                But the nonce would have to be known ahead of time.
                We know that the blockchain works by ""chaining"" blocks together.
                There's no way you know who could change it without messing up the chain, right Santa?
                I'm going to look closer to spot if any of the blocks have been changed.


                https://github.com/corkami/collisions
                This one is interestring... https://github.com/corkami/collisions#shattered-sha1

            ".Blog(_logger);
        }
    }
}
