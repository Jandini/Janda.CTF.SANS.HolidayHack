#!/usr/bin/python3
from http.server import HTTPServer, BaseHTTPRequestHandler
class SimpleHTTPRequestHandler(BaseHTTPRequestHandler):
    def do_GET(self):
        self.send_response(200)
        self.end_headers()
        self.wfile.write(b'Hello, world!')
httpd = HTTPServer(('', 80), SimpleHTTPRequestHandler)
httpd.serve_forever()
