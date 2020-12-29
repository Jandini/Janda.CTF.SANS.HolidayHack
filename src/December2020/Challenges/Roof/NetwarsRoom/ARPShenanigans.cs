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


        public void Goal()
        {
            @"
                Go to the NetWars room on the roof and help Alabaster Snowball get access back to a host using ARP. 
                Retrieve the document at /NORTH_POLE_Land_Use_Board_Meeting_Minutes.txt. 
                Who recused herself from the vote described on the document?

            ".Log(_logger);
        }


        public void Theory()
        {
            @"
                Address Resolution Protocol (ARP) is a procedure for mapping a dynamic Internet Protocol address (IP address) to a permanent physical machine address in a local area network (LAN). 
                The physical machine address is also known as a Media Access Control or MAC address. 


                More on: https://searchnetworking.techtarget.com/definition/Address-Resolution-Protocol-ARP

            ".Log(_logger, "What is ARP? {arp}", "Address Resolution Protocol");
        }

        public void Hints()
        {
            @"
                Go to the NetWars room on the roof and help Alabaster Snowball get access back to a host using ARP. 
                Retrieve the document at /NORTH_POLE_Land_Use_Board_Meeting_Minutes.txt. 
                Who recused herself from the vote described on the document?


                Spoofy
                From: Alabaster Snowball
                Objective: 9) ARP Shenanigans
                The host is performing an ARP request. Perhaps we could do a spoof to perform a machine-in-the-middle attack. I think we have some sample scapy traffic scripts that could help you in /home/guest/scripts.


                Resolvy
                From: Alabaster Snowball
                Objective: 9) ARP Shenanigans
                Hmmm, looks like the host does a DNS request after you successfully do an ARP spoof. Let's return a DNS response resolving the request to our IP.


                Embedy
                From: Alabaster Snowball
                Objective: 9) ARP Shenanigans
                The malware on the host does an HTTP request for a .deb package. Maybe we can get command line access by sending it a command in a customized .deb file


                Sniffy
                From: Alabaster Snowball
                Objective: 9) ARP Shenanigans
                Jack Frost must have gotten malware on our host at 10.6.6.35 because we can no longer access it. Try sniffing the eth0 interface using tcpdump -nni eth0 to see if you can view any traffic from that host.

            ".Log(_logger);
        }


        public void Run()
        {
            Goal();
            Hints();
        }
    }
}
