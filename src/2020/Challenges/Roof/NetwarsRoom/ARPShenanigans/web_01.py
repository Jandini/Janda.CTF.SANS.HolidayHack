#!/usr/bin/python3
from http.server import HTTPServer, BaseHTTPRequestHandler
class SimpleHTTPRequestHandler(BaseHTTPRequestHandler):
    def do_GET(self):
        self.send_response(200)
        self.end_headers()        
        f = open("/home/guest/debs/golang-github-huandu-xstrings-dev_1.2.1-1_all.deb", "rb")
        self.wfile.write(f.read())
    
    def do_POST(self):
        print("POST:")
        print(self.rfile.read(int(self.headers['Content-Length'])).decode('utf-8'))
        self.send_response(200)
        self.end_headers()

httpd = HTTPServer(('', 80), SimpleHTTPRequestHandler)
httpd.serve_forever()
