import http.server
from msilib.schema import Directory;
import socketserver;
import json;

with open('./settings./settings.json') as f :
        jsn = json.load(f);

PORT = (jsn["port"]);
Directory = "web";

class Handler(http.server.SimpleHTTPRequestHandler):
    def __init__(self, *args, **kwargs):
        super().__init__(*args, directory=Directory, **kwargs);

with socketserver.TCPServer(("",PORT), Handler) as httpd:
        print("Server Start in port:", PORT);
        print("このウインドウはソフト終了時まで閉じないでください。");
        httpd.serve_forever();

#セミコロンは癖なので気にしないでください