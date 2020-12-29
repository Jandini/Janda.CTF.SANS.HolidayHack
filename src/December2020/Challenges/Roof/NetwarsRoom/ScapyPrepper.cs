using Microsoft.Extensions.Logging;

namespace Janda.CTF.SANS.HolidayHack
{
    [Challenge(Type = "Terminal", Name = "Scapy Prepper")]
    public class ScapyPrepper : IChallenge
    {
        private readonly ILogger<ScapyPrepper> _logger;

        public ScapyPrepper(ILogger<ScapyPrepper> logger)
        {
            _logger = logger;
        }
        
        public void Run()
        {

            @"
                Welcome to the ""Present Packet Prepper"" interface! The North Pole could use your help preparing pr
                esent packets for shipment.
                Start by running the task.submit() function passing in a string argument of 'start'.
                Type task.help() for help on this question.

            ".Blog(_logger, "yes");


            @"
                Welcome to the ""Present Packet Prepper"" interface! The North Pole could use your help preparing pr
                esent packets for shipment.
                Start by running the task.submit() function passing in a string argument of 'start'.
                Type task.help() for help on this question.

                Correct! adding a () to a function or class will execute it. Ex - FunctionExecuted()

            ".Blog(_logger, "task.submit('start')");


            @"
                Submit the class object of the scapy module that sends packets at layer 3 of the OSI model.
                
                Correct! The ""send"" scapy class will send a crafted scapy packet out of a network interface.

            ".Blog(_logger, "task.submit(send)");


            @"
                Submit the class object of the scapy module that sniffs network packets and returns those packets in a list.
                
                Correct! the ""sniff"" scapy class will sniff network traffic and return these packets in a list.

            ".Blog(_logger, "task.submit(sniff)");



            @"
                Submit the NUMBER only from the choices below that would successfully send a TCP packet and then return the first sniffed response packet to be stored in a variable named ""pkt"":
                1.pkt = sr1(IP(dst = ""127.0.0.1"") / TCP(dport = 20))
                2.pkt = sniff(IP(dst = ""127.0.0.1"") / TCP(dport = 20))
                3.pkt = sendp(IP(dst = ""127.0.0.1"") / TCP(dport = 20))

                Correct! sr1 will send a packet, then immediately sniff for a response packet.

            ".Blog(_logger, "task.submit(1)");


            @"
                Submit the class object of the scapy module that can read pcap or pcapng files and return a list of packets.

                Correct! the ""rdpcap"" scapy class can read pcap files.

            ".Blog(_logger, "task.submit(rdpcap)");


            @"
                The variable UDP_PACKETS contains a list of UDP packets. Submit the NUMBER only from the choices 
                below that correctly prints a summary of UDP_PACKETS:

                1. UDP_PACKETS.print()
                2. UDP_PACKETS.show()
                3. UDP_PACKETS.list()

                Correct! .show() can be used on lists of packets AND on an individual packet.

            ".Blog(_logger, "task.submit(2)");


            @"
                Submit only the first packet found in UDP_PACKETS.

                >>> UDP_PACKETS.show()
                0000 Ether / IP / UDP / DNS Qry ""b'www.elves.rule.'""
                0001 Ether / IP / UDP / DNS Ans ""10.21.23.12""

                Correct! Scapy packet lists work just like regular python lists so packets can be accessed by their position in the list starting at offset 0.

            ".Blog(_logger, "task.submit(UDP_PACKETS[0])");



            @"
                Submit only the entire TCP layer of the second packet in TCP_PACKETS

                Correct! Most of the major fields like Ether, IP, TCP, UDP, ICMP, DNS, DNSQR, DNSRR, Raw, etc... can be accessed this way. Ex - pkt[IP][TCP]

            ".Blog(_logger, "task.submit(TCP_PACKETS[1][TCP])");


            @"
                Change the source IP address of the first packet found in UDP_PACKETS to 127.0.0.1 and then submit this modified packet                

                Correct! You can change ALL scapy packet attributes using this method.

            ".Blog(_logger, @"
                UDP_PACKETS[0][IP].src=""127.0.0.1""
                task.submit(UDP_PACKETS[0])
            ");


            @"
                Submit the password ""task.submit('elf_password')"" of the user alabaster as found in the packet list TCP_PACKETS.
                
                >>> TCP_PACKETS.hexdump()

                0000 17:24:40.499548 Ether / IP / TCP 192.168.0.114:1137 > 192.168.0.193:ftp S
                0000  00 15 F2 40 76 EF 00 16 CE 6E 8B 24 08 00 45 00  ...@v....n.$..E.
                0010  00 30 A7 E3 40 00 80 06 D0 60 C0 A8 00 72 C0 A8  .0..@....`...r..
                0020  00 C1 04 71 00 15 DF B3 B2 FE 00 00 00 00 70 02  ...q..........p.
                0030  40 00 29 63 00 00 02 04 05 B4 01 01 04 02        @.)c..........
                0001 17:24:40.501867 Ether / IP / TCP 192.168.0.193:ftp > 192.168.0.114:1137 SA
                0000  00 16 CE 6E 8B 24 00 15 F2 40 76 EF 08 00 45 00  ...n.$...@v...E.
                0010  00 30 29 60 00 00 80 06 8E E4 C0 A8 00 C1 C0 A8  .0)`............
                0020  00 72 00 15 04 71 C6 C7 01 41 DF B3 B2 FF 70 12  .r...q...A....p.
                0030  40 00 61 51 00 00 02 04 05 AC 01 01 04 02        @.aQ..........
                0002 17:24:40.501886 Ether / IP / TCP 192.168.0.114:1137 > 192.168.0.193:ftp A
                0000  00 15 F2 40 76 EF 00 16 CE 6E 8B 24 08 00 45 00  ...@v....n.$..E.
                0010  00 28 A7 E4 40 00 80 06 D0 67 C0 A8 00 72 C0 A8  .(..@....g...r..
                0020  00 C1 04 71 00 15 DF B3 B2 FF C6 C7 01 42 50 10  ...q.........BP.
                0030  44 10 89 FD 00 00                                D.....
                0003 17:24:40.503947 Ether / IP / TCP 192.168.0.193:ftp > 192.168.0.114:1137 PA / Raw
                0000  00 16 CE 6E 8B 24 00 15 F2 40 76 EF 08 00 45 00  ...n.$...@v...E.
                0010  00 46 29 61 40 00 80 06 4E CD C0 A8 00 C1 C0 A8  .F)a@...N.......
                0020  00 72 00 15 04 71 C6 C7 01 42 DF B3 B2 FF 50 18  .r...q...B....P.
                0030  FF FF D9 7D 00 00 32 32 30 20 4E 6F 72 74 68 20  ...}..220 North 
                0040  50 6F 6C 65 20 46 54 50 20 53 65 72 76 65 72 0D  Pole FTP Server.
                0050  0A                                               .
                0004 17:24:40.504807 Ether / IP / TCP 192.168.0.114:1137 > 192.168.0.193:ftp PA / Raw
                0000  00 15 F2 40 76 EF 00 16 CE 6E 8B 24 08 00 45 00  ...@v....n.$..E.
                0010  00 37 A7 E5 40 00 80 06 D0 57 C0 A8 00 72 C0 A8  .7..@....W...r..
                0020  00 C1 04 71 00 15 DF B3 B2 FF C6 C7 01 60 50 18  ...q.........`P.
                0030  43 F2 0A 98 00 00 55 53 45 52 20 61 6C 61 62 61  C.....USER alaba
                0040  73 74 65 72 0D                                   ster.
                0005 17:24:40.506108 Ether / IP / TCP 192.168.0.193:ftp > 192.168.0.114:1137 PA / Raw
                0000  00 16 CE 6E 8B 24 00 15 F2 40 76 EF 08 00 45 00  ...n.$...@v...E.
                0010  00 4D 29 62 40 00 80 06 4E C5 C0 A8 00 C1 C0 A8  .M)b@...N.......
                0020  00 72 00 15 04 71 C6 C7 01 60 DF B3 B3 0E 50 18  .r...q...`....P.
                0030  FF F0 3D 9C 00 00 33 33 31 20 50 61 73 73 77 6F  ..=...331 Passwo
                0040  72 64 20 72 65 71 75 69 72 65 64 20 66 6F 72 20  rd required for 
                0050  61 6C 61 62 61 73 74 65 72 2E 0D                 alabaster..
                0006 17:24:40.507195 Ether / IP / TCP 192.168.0.114:1137 > 192.168.0.193:ftp PA / Raw
                0000  00 15 F2 40 76 EF 00 16 CE 6E 8B 24 08 00 45 00  ...@v....n.$..E.
                0010  00 33 A7 E6 40 00 80 06 D0 5A C0 A8 00 72 C0 A8  .3..@....Z...r..
                0020  00 C1 04 71 00 15 DF B3 B3 0E C6 C7 01 85 50 18  ...q..........P.
                0030  43 CD E9 6B 00 00 50 41 53 53 20 65 63 68 6F 0D  C..k..PASS echo.
                0040  0A                                               .
                0007 17:24:40.509484 Ether / IP / TCP 192.168.0.193:ftp > 192.168.0.114:1137 PA / Raw
                0000  00 16 CE 6E 8B 24 00 15 F2 40 76 EF 08 00 45 00  ...n.$...@v...E.
                0010  00 46 29 63 40 00 80 06 4E CB C0 A8 00 C1 C0 A8  .F)c@...N.......
                0020  00 72 00 15 04 71 C6 C7 01 85 DF B3 B3 19 50 18  .r...q........P.
                0030  FF E5 00 D3 00 00 32 33 30 20 55 73 65 72 20 61  ......230 User a
                0040  6C 61 62 61 73 74 65 72 20 6C 6F 67 67 65 64 20  labaster logged 
                0050  69 6E 2E 0D                                      in..

                >>> TCP_PACKETS[6][Raw]
                <Raw  load='PASS echo\r\n' |>


                Correct! Here is some really nice list comprehension that will grab all the raw payloads from tcp packets:
                [pkt[Raw].load for pkt in TCP_PACKETS if Raw in pkt]


            ".Blog(_logger, "task.submit('echo')");



            @"
                The ICMP_PACKETS variable contains a packet list of several icmp echo-request and icmp echo-reply packets. 
                Submit only the ICMP chksum value from the second packet in the ICMP_PACKETS list.

                >>> ICMP_PACKETS
                <No name: TCP:0 UDP:0 ICMP:4 Other:0>

                >>> ICMP_PACKETS.show()
                0000 Ether / IP / ICMP 10.2.2.123 > 10.21.23.12 echo-request 0 / Raw
                0001 Ether / IP / ICMP 10.21.23.12 > 10.21.23.12 echo-reply 0 / Raw
                0002 Ether / IP / ICMP 10.2.2.123 > 10.21.23.12 echo-request 0 / Raw
                0003 Ether / IP / ICMP 10.21.23.12 > 10.21.23.12 echo-reply 0 / Raw

                >>> ICMP_PACKETS[1]
                <Ether  dst=00:0c:29:d0:96:b3 src=00:50:56:f9:54:66 type=IPv4 |<IP  version=4 ihl=5 tos=0x0 len=84 id=2585 flags= frag=0 ttl=128 proto=icmp chksum=0xe69b src=10.21.23.12 dst=10.21.23.12 |<ICMP  type=echo-reply code=0 chksum=0x4c44 id=0x6d38 seq=0x1 unused='' |<Raw  load='L=\xa7^\x00\x00\x00\x00\x88\x13\x0c\x00\x00\x00\x00\x00\x10\x11\x12\x13\x14\x15\x16\x17\x18\x19\x1a\x1b\x1c\x1d\x1e\x1f !""#$%&\'()*+,-./01234567' |>>>>

                Correct! You can access the ICMP chksum value from the second packet using ICMP_PACKETS[1][ICMP].chksum .

            ".Blog(_logger, "task.submit(ICMP_PACKETS[1][ICMP].chksum)");



            @"
                Submit the number of the choice below that would correctly create a ICMP echo request packet with a destination IP of 127.0.0.1 stored in the variable named ""pkt""

                1.pkt = Ether(src = '127.0.0.1') / ICMP(type = ""echo-request"")
                2.pkt = IP(src = '127.0.0.1') / ICMP(type = ""echo-reply"")
                3.pkt = IP(dst = '127.0.0.1') / ICMP(type = ""echo-request"")

                Correct! Once you assign the packet to a variable named ""pkt"" you can then use that variable to send or manipulate your created packet.

            ".Blog(_logger, "task.submit(3)");




            @"
                Create and then submit a UDP packet with a dport of 5000 and a dst IP of 127.127.127.127. (all other packet attributes can be unspecified)

                >>> pkt = IP(dst=""127.127.127.127"")/UDP(dport=5000)
                >>> task.submit(pkt)

                Correct! Your UDP packet creation should look something like this:
                pkt = IP(dst=""127.127.127.127"")/UDP(dport=5000)
                task.submit(pkt)

            ".Blog(_logger, "task.submit(IP(dst=\"127.127.127.127\")/UDP(dport=5000))");


            @"
                Create and then submit a UDP packet with a dport of 53, a dst IP of 127.2.3.4, and is a DNS query 
                with a qname of ""elveslove.santa"". (all other packet attributes can be unspecified)

                Correct! Your UDP packet creation should look something like this:
                pkt = IP(dst=""127.2.3.4"")/UDP(dport=53)/DNS(rd=1,qd=DNSQR(qname=""elveslove.santa""))
                task.submit(pkt)

            ".Blog(_logger, "task.submit(IP(dst=\"127.2.3.4\")/UDP(dport=53)/DNS(qd=DNSQR(qname=\"elveslove.santa\")))");



            @"
                The variable ARP_PACKETS contains an ARP request and response packets. 
                The ARP response (the second packet) has 3 incorrect fields in the ARP layer. 
                Correct the second packet in ARP_PACKETS to be a proper ARP response and then task.submit(ARP_PACKETS) for inspection.

                >>> task.submit(ARP_PACKETS)
                Incorrect!
                The variable ARP_PACKETS contains an ARP request and response packets. The ARP response (the second packet) has 3 incorrect fields in the ARP layer. 
                Correct the second packet in ARP_PACKETS to be a proper ARP response and then task.submit(ARP_PACKETS) for inspection.

                The three fields in ARP_PACKETS[1][ARP] that are incorrect are op, hwsrc, and hwdst. 
                A sample ARP pcap can be referenced at https://www.cloudshark.org/captures/e4d6ea732135. 
                You can run the ""reset_arp()"" function to reset the ARP packets back to their original form.

                >>> ARP_PACKETS[1][ARP]
                <ARP  hwtype=0x1 ptype=IPv4 hwlen=6 plen=4 op=None hwsrc=ff:ff:ff:ff:ff:ff psrc=192.168.0.1 hwdst=ff:ff:ff:ff:ff:ff pdst=192.168.0.114 |<Padding  load='\xc0\xa8\x00r' |>>

                >>> reset_arp()

                >>> ARP_PACKETS[1][ARP]
                <ARP  hwtype=0x1 ptype=IPv4 hwlen=6 plen=4 op=None hwsrc=ff:ff:ff:ff:ff:ff psrc=192.168.0.1 hwdst=ff:ff:ff:ff:ff:ff pdst=192.168.0.114 |<Padding  load='\xc0\xa8\x00r' |>>

                >>> ARP_PACKETS.hexdump()
                0000 19:59:22.880651 Ether / ARP who has 192.168.0.1 says 192.168.0.114
                0000  FF FF FF FF FF FF 00 16 CE 6E 8B 24 08 06 00 01  .........n.$....
                0010  08 00 06 04 00 01 00 16 CE 6E 8B 24 C0 A8 00 72  .........n.$...r
                0020  00 00 00 00 00 00 C0 A8 00 01                    ..........
                0001 19:59:22.884732 Ether / ARP None 192.168.0.1 > 192.168.0.114 / Padding
                0000  00 16 CE 6E 8B 24 00 13 46 0B 22 BA 08 06 00 01  ...n.$..F.......
                0010  08 00 06 04 00 00 FF FF FF FF FF FF C0 A8 00 01  ................
                0020  FF FF FF FF FF FF C0 A8 00 72 C0 A8 00 72        .........r...r


                >>> ARP_PACKETS[0][ARP]
                <ARP  hwtype=0x1 ptype=IPv4 hwlen=6 plen=4 op=who-has hwsrc=00:16:ce:6e:8b:24 psrc=192.168.0.114 hwdst=00:00:00:00:00:00 pdst=192.168.0.1 |>

                >>> ARP_PACKETS[1][ARP]
                <ARP  hwtype=0x1 ptype=IPv4 hwlen=6 plen=4 op=None hwsrc=ff:ff:ff:ff:ff:ff psrc=192.168.0.1 hwdst=ff:ff:ff:ff:ff:ff pdst=192.168.0.114 |<Padding  load='\xc0\xa8\x00r' |>>

              
                >>> ARP_PACKETS[1]
                <Ether  dst=00:16:ce:6e:8b:24 src=00:13:46:0b:22:ba type=ARP |<ARP  hwtype=0x1 ptype=IPv4 hwlen=6 plen=4 op=is-at hwsrc=01:16:ce:6e:8b:24 psrc=192.168.0.1 hwdst=00:16:ce:6e:8b:24 pdst=192.168.0.114 |<Padding  load='\xc0\xa8\x00r' |>>>

                >>> ARP_PACKETS[1][ARP].op='is-at'
                >>> ARP_PACKETS[1][ARP].hwsrc='00:13:46:0b:22:ba'
                >>> ARP_PACKETS[1][ARP].hwdst='00:16:ce:6e:8b:24'


                Great, you prepared all the present packets!

                Congratulations, all pretty present packets properly prepared for processing!

            ".Blog(_logger, @"
                ARP_PACKETS[1][ARP].op='is-at'                
                ARP_PACKETS[1][ARP].hwsrc='00:13:46:0b:22:ba'
                ARP_PACKETS[1][ARP].hwdst='00:16:ce:6e:8b:24'task.submit(ARP_PACKETS)
            ");

        }
    }
}
