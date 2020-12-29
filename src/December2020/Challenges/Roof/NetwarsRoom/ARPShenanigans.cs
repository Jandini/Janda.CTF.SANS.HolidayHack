using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{

    [Challenge(Name = "Objective 9: ARP Shenanigans", Points = 4)]
    public class ARPShenanigans : IChallenge
    {
        private readonly ILogger<ARPShenanigans> _logger;

        public ARPShenanigans(ILogger<ARPShenanigans> logger)
        {
            _logger = logger;
        }


        public void Info()
        {
            @"
                Go to the NetWars room on the roof and help Alabaster Snowball get access back to a host using ARP. 
                Retrieve the document at /NORTH_POLE_Land_Use_Board_Meeting_Minutes.txt. 
                Who recused herself from the vote described on the document?
            ".LogNote(_logger);
        }
        
        public void Run()
        {

        }
    }
}
