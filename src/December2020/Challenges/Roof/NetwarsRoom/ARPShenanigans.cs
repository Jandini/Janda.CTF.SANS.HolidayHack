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


        public void Objective()
        {
            @"
                Go to the NetWars room on the roof and help Alabaster Snowball get access back to a host using ARP. 
                Retrieve the document at /NORTH_POLE_Land_Use_Board_Meeting_Minutes.txt. 
                Who recused herself from the vote described on the document?

            ".Log(_logger, "Objective");
        }


        public void Theory()
        {
            @"
                What is ARP? Address Resolution Protocol

                Address Resolution Protocol (ARP) is a procedure for mapping a dynamic Internet Protocol address (IP address) to a permanent physical machine address in a local area network (LAN). 
                The physical machine address is also known as a Media Access Control or MAC address. 


                More on: https://searchnetworking.techtarget.com/definition/Address-Resolution-Protocol-ARP

            ".Log(_logger, "Theory");
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

            ".Log(_logger, "Hints");
        }


        public void Chats()
        {
            @"

                Alabaster Snowball  8:38PM

                Oh, I see the Scapy Present Packet Prepper has already been completed!
                Now you can help me get access to this machine.
                It seems that some interloper here at the North Pole has taken control of the host.

                We need to regain access to some important documents associated with Kringle Castle.
                Maybe we should try a machine-in-the-middle attack?
            
                Oh, I see the Scapy Present Packet Prepper has already been completed!
                Now you can help me get access to this machine.

                It seems that some interloper here at the North Pole has taken control of the host.
                We need to regain access to some important documents associated with Kringle Castle.

                Maybe we should try a machine-in-the-middle attack?
                That could give us access to manipulate DNS responses.

                But we'll still need to cook up something to change the HTTP response.
            
                I'm sure glad you're here Santa.

            ".Log(_logger, "Chats");
        }


        public void Terminal()
        {
            @"
                Jack Frost has hijacked the host at 10.6.6.35 with some custom malware.
                Help the North Pole by getting command line access back to this host.

                Read the HELP.md file for information to help you in this endeavor.

                Note: The terminal lifetime expires after 30 or more minutes so be 
                sure to copy off any essential work you have done as you go.

                guest@68e6e97fccd9:~$ 

            ".Log(_logger, "Start");
        }


        public void Run()
        {
            Objective();
            Hints();
            Chats();
            Theory();
        }
    }
}
