using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{

    [Challenge(Type = "Objective", Number = 9, Name = "ARP Shenanigans", Points = 4)]
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

            ".Blog(_logger, "Objective");
        }

        public void About()
        {
            @"
                Jack Frost has hijacked the host at 10.6.6.35 with some custom malware.
                Help the North Pole by getting command line access back to this host.

                Read the HELP.md file for information to help you in this endeavor.

                Note: The terminal lifetime expires after 30 or more minutes so be 
                sure to copy off any essential work you have done as you go.

                guest@68e6e97fccd9:~$ 

            ".Blog(_logger, "Start");
        }


        public void Theory()
        {
            @"
                What is ARP? Address Resolution Protocol

                Address Resolution Protocol (ARP) is a procedure for mapping a dynamic Internet Protocol address (IP address) to a permanent physical machine address in a local area network (LAN). 
                The physical machine address is also known as a Media Access Control or MAC address. 


                More on: https://searchnetworking.techtarget.com/definition/Address-Resolution-Protocol-ARP

            ".Blog(_logger, "Theory");
        }

        public void Hints()
        {
            @"

                Spoofy
                From: Alabaster Snowball
                Objective: 9) ARP Shenanigans
                
                The host is performing an ARP request. Perhaps we could do a spoof to perform a machine-in-the-middle attack. 
                I think we have some sample scapy traffic scripts that could help you in /home/guest/scripts.


                Resolvy
                From: Alabaster Snowball
                Objective: 9) ARP Shenanigans

                Hmmm, looks like the host does a DNS request after you successfully do an ARP spoof. 
                Let's return a DNS response resolving the request to our IP.


                Embedy
                From: Alabaster Snowball
                Objective: 9) ARP Shenanigans
                
                The malware on the host does an HTTP request for a .deb package. 
                Maybe we can get command line access by sending it a command in a customized .deb file


                Sniffy
                From: Alabaster Snowball
                Objective: 9) ARP Shenanigans
                
                Jack Frost must have gotten malware on our host at 10.6.6.35 because we can no longer access it. 
                Try sniffing the eth0 interface using tcpdump -nni eth0 to see if you can view any traffic from that host.


            ".Blog(_logger, "Hints");
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

            ".Blog(_logger, "Chats");
        }



        public void WonderingAround()
        {
            @"
                # resolution or it will stall when reading:                                                                                                 │guest@452dd887658f:~$ 
                ```                                                                                                                                         │
                tshark -nnr arp.pcap                                                                                                                        │
                tcpdump -nnr arp.pcap                                                                                                                       │
                ```                                                                                                                                         │
                                                                                                                                                            │
                guest@452dd887658f:~$ tshark                                                                                                                │
                Capturing on 'eth0'                                                                                                                         │
                    1 0.000000000 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                 │
                    2 1.031989483 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                 │
                ^C2 packets captured                                                                                                                        │
                guest@452dd887658f:~$                                                                                                                       │
                guest@452dd887658f:~$ tshark                                                                                                                │
                Capturing on 'eth0'                                                                                                                         │
                    1 0.000000000 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                 │
                    2 1.039986867 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                 │
                    3 2.075830381 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                 │
                    4 3.131865014 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                 │
                    5 4.171833866 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                 │
                    6 5.203895329 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                 │
                    7 6.255960599 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                 │
                    8 7.291827766 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                 │
                ^C    9 8.328093002 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                               │
                9 packets captured                                                                                                                          │
                guest@452dd887658f:~$ cd pcaps/                                                                                                             │
                guest@452dd887658f:~/pcaps$ tshark -nnr arp.pcap                                                                                            │
                    1   0.000000 cc:01:10:dc:00:00 → ff:ff:ff:ff:ff:ff ARP 60 Who has 10.10.10.1? Tell 10.10.10.2                                           │
                    2   0.031000 cc:00:10:dc:00:00 → cc:01:10:dc:00:00 ARP 60 10.10.10.1 is at cc:00:10:dc:00:00                                            │
                guest@452dd887658f:~/pcaps$                               

            ".Blog(_logger);
        }

        public void Run()
        {
            Objective();
            Hints();
            Chats();
            Theory();


            @"
                guest@505d7d82c555:~$ arp -a                
            ".Blog(_logger, "Getting nothing from ARP cache");


            @"                
                # How To Resize and Switch Terminal Panes:
                You can use the key combinations ( Ctrl+B ↑ or ↓ ) to resize the terminals.
                You can use the key combinations ( Ctrl+B o ) to switch terminal panes.
                See tmuxcheatsheet.com for more details

                # To Add An Additional Terminal Pane:
                `/usr/bin/tmux split-window -hb`

                # To exit a terminal pane simply type:
                `exit`

                # To Launch a webserver to serve-up files/folder in a local directory:
                ```
                cd /my/directory/with/files
                python3 -m http.server 80
                ```

                # A Sample ARP pcap can be viewed at:
                https://www.cloudshark.org/captures/d97c5b81b057

                # A Sample DNS pcap can be viewed at:
                https://www.cloudshark.org/captures/0320b9b57d35

                # If Reading arp.pcap with tcpdump or tshark be sure to disable name
                # resolution or it will stall when reading:
                ```
                tshark -nnr arp.pcap
                tcpdump -nnr arp.pcap
                ```
            ".Blog(_logger, "cat HELP.md");

            @"
                eth0: flags=4419<UP,BROADCAST,RUNNING,PROMISC,MULTICAST>  mtu 1500
                        inet 10.6.0.3  netmask 255.255.0.0  broadcast 10.6.255.255
                        ether 02:42:0a:06:00:03  txqueuelen 0  (Ethernet)
                        RX packets 446  bytes 19164 (19.1 KB)
                        RX errors 0  dropped 0  overruns 0  frame 0
                        TX packets 0  bytes 0 (0.0 B)
                        TX errors 0  dropped 0 overruns 0  carrier 0  collisions 0

                lo: flags=73<UP,LOOPBACK,RUNNING>  mtu 65536
                        inet 127.0.0.1  netmask 255.0.0.0
                        loop  txqueuelen 1000  (Local Loopback)
                        RX packets 40  bytes 2000 (2.0 KB)
                        RX errors 0  dropped 0  overruns 0  frame 0
                        TX packets 40  bytes 2000 (2.0 KB)
                        TX errors 0  dropped 0 overruns 0  carrier 0  collisions 0

            ".Blog(_logger, "ifconfig, IP {ip} MAC {mac}", "10.6.0.3", "02:42:0a:06:00:03");


            @"
                https://www.wireshark.org/docs/man-pages/tshark.html
            ".Blog(_logger, "tshark help");


            @"
                guest@505d7d82c555:~/pcaps$ tshark -nnr arp.pcap
                    1   0.000000 cc:01:10:dc:00:00 → ff:ff:ff:ff:ff:ff ARP 60 Who has 10.10.10.1? Tell 10.10.10.2
                    2   0.031000 cc:00:10:dc:00:00 → cc:01:10:dc:00:00 ARP 60 10.10.10.1 is at cc:00:10:dc:00:00

                guest@505d7d82c555:~/pcaps$ tcpdump -nnr arp.pcap
                reading from file arp.pcap, link-type EN10MB (Ethernet)
                17:16:02.806447 ARP, Request who-has 10.10.10.1 tell 10.10.10.2, length 46
                17:16:02.837447 ARP, Reply 10.10.10.1 is-at cc:00:10:dc:00:00, length 46

                guest@505d7d82c555:~/pcaps$ tshark -nnr dns.pcap
                    1   0.000000 192.168.170.8 → 192.168.170.20 DNS 74 Standard query 0x75c0 A www.netbsd.org
                    2   0.048911 192.168.170.20 → 192.168.170.8 DNS 90 Standard query response 0x75c0 A www.netbsd.org A 204.152.190.12


                guest@505d7d82c555:~/pcaps$ tcpdump -nnr dns.pcap
                reading from file dns.pcap, link-type EN10MB (Ethernet)
                08:49:18.685951 IP 192.168.170.8.32795 > 192.168.170.20.53: 30144+ A? www.netbsd.org. (32)
                08:49:18.734862 IP 192.168.170.20.53 > 192.168.170.8.32795: 30144 1/0/0 A 204.152.190.12 (48)


            ".Blog(_logger, "Read packets files");


            @"
                guest@505d7d82c555:~/pcaps$ tcpdump -nn
                tcpdump: verbose output suppressed, use -v or -vv for full protocol decode
                listening on eth0, link-type EN10MB (Ethernet), capture size 262144 bytes
                21:35:00.464437 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                21:35:01.508446 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                21:35:02.540369 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                21:35:03.580386 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                21:35:04.620438 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                21:35:05.652377 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28

            ".Blog(_logger, "tcpdump -nn");


        }
    }
}
