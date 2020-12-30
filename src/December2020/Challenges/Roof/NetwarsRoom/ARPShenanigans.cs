﻿using Microsoft.Extensions.Logging;

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




            @"
                tcpdump: verbose output suppressed, use -v or -vv for full protocol decode
                listening on eth0, link-type EN10MB (Ethernet), capture size 262144 bytes
                22:14:36.566554 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                22:14:37.345679 IP6 fe80::9822:6fff:fe7b:92de > ff02::2: ICMP6, router solicitation, length 16
                22:14:37.610555 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                22:14:38.642595 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                22:14:39.674605 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                22:14:40.782625 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                22:14:41.826849 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                22:14:42.862631 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                22:14:43.902643 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                22:14:44.938686 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                22:14:45.970638 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                22:14:46.049697 IP6 fe80::9822:6fff:fe7b:92de > ff02::2: ICMP6, router solicitation, length 16
                22:14:47.002821 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                22:14:48.038662 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                22:14:49.090932 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                22:14:50.126659 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                22:14:51.166754 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                22:14:52.206596 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                22:14:53.238806 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                22:14:54.274839 ARP, Request who-has 10.6.6.53 tell 10.6.6.35, length 28


            guest@1dbc829b765d:~$ tshark
            Capturing on 'eth0'
                1 0.000000000 fe80::2827:f1ff:fef6:e49d → ff02::2      ICMPv6 70 Router Solicitation from 2a:27:f1:f6:e4:9d
                2 0.161261685 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                3 1.209474837 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                4 2.244852384 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                5 3.284891781 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                6 4.324876935 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                7 5.360963713 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                8 6.396865986 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                9 7.423932814 fe80::2827:f1ff:fef6:e49d → ff02::2      ICMPv6 70 Router Solicitation from 2a:27:f1:f6:e4:9d
               10 7.437029569 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               11 8.472865340 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               12 9.504907119 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               13 10.561525306 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               14 11.592910912 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               15 12.636858756 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               16 13.689205728 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               17 14.728905098 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               18 15.772974532 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               19 16.812953139 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               20 17.852897605 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               21 18.884977571 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               22 19.928908522 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               23 20.972919679 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               24 22.008884886 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               25 22.527940896 fe80::2827:f1ff:fef6:e49d → ff02::2      ICMPv6 70 Router Solicitation from 2a:27:f1:f6:e4:9d
               26 23.065161088 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               27 24.112834401 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               28 25.152877006 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               29 26.212860899 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               30 27.252883953 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               31 28.304987317 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               32 29.352902817 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               33 30.396905879 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               34 31.441033315 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               35 32.488884888 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               36 33.532955828 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               37 34.564894101 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               38 35.612875309 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               39 36.661061380 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
               40 37.704864306 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35


            ".Blog(_logger, @"When logged immediatelly run {command}. The ICMP6 does not happen later... 
                
                The MAC address {mac} changes everytime accessing the terminal.
                Router discovery messages
                To enable router discovery, the IRDP defines two kinds of ICMP messages:[4][5]

                The ICMP Router Solicitation message is sent from a computer host to any routers on the local area network to request that they advertise their presence on the network.

            ", "tcpdump -nni eth0", "2a:27:f1:f6:e4:9d");


            @"

                1 0.000000000 4c: 24:57:ab: ed: 84 → Broadcast ARP 42 Who has 10.6.6.53 ? Tell 10.6.6.35
                2 1.039942918 4c: 24:57:ab: ed: 84 → Broadcast ARP 42 Who has 10.6.6.53 ? Tell 10.6.6.35
                3 2.091998751 4c: 24:57:ab: ed: 84 → Broadcast ARP 42 Who has 10.6.6.53 ? Tell 10.6.6.35
                4 3.131935943 4c: 24:57:ab: ed: 84 → Broadcast ARP 42 Who has 10.6.6.53 ? Tell 10.6.6.35
                5 4.199995086 4c: 24:57:ab: ed: 84 → Broadcast ARP 42 Who has 10.6.6.53 ? Tell 10.6.6.35
                6 5.259945568 4c: 24:57:ab: ed: 84 → Broadcast ARP 42 Who has 10.6.6.53 ? Tell 10.6.6.35
                7 6.303958906 4c: 24:57:ab: ed: 84 → Broadcast ARP 42 Who has 10.6.6.53 ? Tell 10.6.6.35
                8 7.183032133 fe80::f8f1:edff: fe60: 3c57 → ff02::2      ICMPv6 70 Router Solicitation from fa:f1: ed: 60:3c: 57
                9 7.351906056 4c: 24:57:ab: ed: 84 → Broadcast ARP 42 Who has 10.6.6.53 ? Tell 10.6.6.35
                10 8.399987293 4c: 24:57:ab: ed: 84 → Broadcast ARP 42 Who has 10.6.6.53 ? Tell 10.6.6.35

            ".Blog(_logger, "Found how to read specific frame: {command}", "tshark -r out.pcap -Y \"frame.number >= 1 && frame.number <= 10\"");



            // https://github.com/x4nth055/pythoncode-tutorials/tree/master/scapy/arp-spoofer

            // sc config RemoteAccess start=demand
            // sc start RemoteAccess
            // https://www.thepythoncode.com/article/building-arp-spoofer-using-scapy#:~:text=Building%20and%20creating%20an%20ARP%20Spoof%20script%20in,is%20a%20method%20of%20gaining%20a%20man-in-the-middle%20situation.


            @"              
                inet 10.6.0.3  netmask 255.255.0.0  broadcast 10.6.255.255
                Jack Frost has hijacked the host at 10.6.6.35 with some custom malware.                
                Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                      
            ".Blog(_logger, @"What do we know now...
                my ip is {myip} with mac {myhw}
                hijacked host is at {hijackedip}
                found ARP who-has {hijackedip} packets flying over the network

                For:
                    Request who-has 10.6.6.53 tell 10.6.6.35, length 28
                We must reply: 
                    10.6.6.35 is-at 4c:24:57:ab:ed:84

                    Sender IP addres:   10.6.6.35
                    Sender MAC address: 4c:24:57:ab:ed:84



                Based on packet comparison (sniffed and the example provided in pcaps) we must reply with: 

                    Ether dst: 02:42:0a:06:00:06 
                    ARP target ip: 10.10.10.2
                    ARP sender ip: 10.6.6.53


            ",                 
            "10.6.0.3", "02:42:0a:06:00:03", "10.6.6.35", "10.6.6.35");



            @"
                guest@3fcc52341816:~$ python3
                Python 3.8.5 (default, Jul 28 2020, 12:59:40) 
                [GCC 9.3.0] on linux
                Type ""help"", ""copyright"", ""credits"" or ""license"" for more information.
                >>> from scapy.all import Ether, ARP, srp, send
                >>> srp(Ether(dst = 'ff:ff:ff:ff:ff:ff') / ARP(pdst = ""10.6.6.35""), timeout = 1, verbose = 0)[0][0][1].src
                '4c:24:57:ab:ed:84'

            ".Blog(_logger, "Get hijacked host MAC address");



            @"

                guest@d4a322bde6e4:~$ tshark -n
                Capturing on 'eth0'
                    1 0.000000000 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                    2 0.000157636 02:42:0a:06:00:06 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.0.6
                    3 0.088167525 02:42:0a:06:00:06 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.35? Tell 10.6.0.6
                    4 1.055984658 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                    5 2.099919201 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                    6 2.204333394 02:42:0a:06:00:06 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.0.6
                    7 2.284136670 02:42:0a:06:00:06 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.35? Tell 10.6.0.6
                    8 3.135988466 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                    9 4.180013747 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                   10 4.376467450 02:42:0a:06:00:06 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.0.6
                   11 4.440169404 02:42:0a:06:00:06 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.35? Tell 10.6.0.6
                   12 5.235964835 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                   13 6.295972797 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                   14 6.508090208 02:42:0a:06:00:06 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.0.6
                   15 6.604233788 02:42:0a:06:00:06 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.35? Tell 10.6.0.6
                   16 7.339963840 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35

                    Who has 10.6.6.35? Tell 10.6.0.6
                    Who has 10.6.6.53? Tell 10.6.6.35

            ".Blog(_logger, "There are multiple ARP requests which we might have to answer, for example 10.6.6.35");


            @"
                 2338 2394.379999382 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                   
                 2339 2395.420053549 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                   
                 2340 2396.251885630     10.6.0.7 → 169.254.169.254 DNS 63 Standard query 0xeb7a A MAC                                                
                 2341 2396.319089628 02:42:0a:06:00:07 → 02:42:94:00:d2:d6 ARP 42 Who has 10.6.0.1? Tell 10.6.0.7                                     
                 2342 2396.319146187 02:42:94:00:d2:d6 → 02:42:0a:06:00:07 ARP 42 10.6.0.1 is at 02:42:94:00:d2:d6                                    
                 2343 2396.460168832 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                   
                 2344 2397.508022900 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                   
                 2345 2398.555955377 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35   

                 2373 2421.277998227     10.6.0.7 → 169.254.169.254 DNS 89 Standard query 0xf15a A IP.c.holidayhack2020.internal                      
                 2374 2421.636063916 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                   
                 2375 2422.680070877 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                   
                 2376 2423.724111830 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                   
                 2377 2424.768039488 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                   
                 2378 2425.807966415 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                   
                 2379 2426.283261025     10.6.0.7 → 169.254.169.254 DNS 89 Standard query 0xf15a A IP.c.holidayhack2020.internal                      
                 2380 2426.843980274 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                   
                 2381 2427.887958485 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                   
                 2382 2428.935949396 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35     

            ".Blog(_logger, "When trying send a new packet (not completed yet) I can see DNS packages...");


            @"
                3388 3397.343838237 00:00:00:00:00:00 → 4c:24:57:ab:ed:84 ARP 42 Gratuitous ARP for 10.6.6.35 (Reply) (duplicate use of 10.6.6.35 detected!)                                                                                                                                           │
                 
                https://wiki.wireshark.org/Gratuitous_ARP#:~:text=Gratuitous%20ARPs%20are%20useful%20for%20four%20reasons%3A%201,to%20that%20MAC%20address%20...%20More%20items...%20

            ".Blog(_logger, "Using {code} I have discovered something called Gratuitous ARP", "arp_resp_02.py");


            @"
                 4013 3987.852213869 00:00:00:00:00:00 → 4c:24:57:ab:ed:84 ARP 42 Gratuitous ARP for 10.6.6.35 (Reply)             
                 4014 3988.868052715 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                
                 4015 3988.892174494 00:00:00:00:00:00 → 4c:24:57:ab:ed:84 ARP 42 Gratuitous ARP for 10.6.6.35 (Reply)             
                 4016 3989.908116466 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                
                 4017 3989.928012661 00:00:00:00:00:00 → 4c:24:57:ab:ed:84 ARP 42 Gratuitous ARP for 10.6.6.35 (Reply)             
                 4018 3990.944052549 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35        

            ".Blog(_logger, "Using {code} we still get Gratuitous ARP but no duplicate", "arp_resp_03.py");
        }
    }
}
