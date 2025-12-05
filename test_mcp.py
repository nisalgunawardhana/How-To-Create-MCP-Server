import subprocess
import json
import sys

# Start the MCP server
process = subprocess.Popen(
    ["dotnet", "run", "--project", "HelloSriLankaServer/HelloSriLankaServer.csproj"],
    stdin=subprocess.PIPE,
    stdout=subprocess.PIPE,
    stderr=subprocess.PIPE,
    text=True,
    cwd=r"C:\Users\acer\Desktop\MCP Workshop\How-To-Create-MCP-Server"
)

# Initialize the server
init_msg = {
    "jsonrpc": "2.0",
    "id": 1,
    "method": "initialize",
    "params": {
        "protocolVersion": "2024-11-05",
        "capabilities": {},
        "clientInfo": {"name": "test-client", "version": "1.0.0"}
    }
}

# Send initialize message
process.stdin.write(json.dumps(init_msg) + "\n")
process.stdin.flush()

# Call the HelloTool
call_msg = {
    "jsonrpc": "2.0",
    "id": 2,
    "method": "tools/call",
    "params": {
        "name": "HelloTool",
        "arguments": {}
    }
}

# Send tool call
process.stdin.write(json.dumps(call_msg) + "\n")
process.stdin.flush()

# Read responses
try:
    for _ in range(3):
        response = process.stdout.readline()
        if response:
            print("Response:", response.strip())
except:
    pass

process.terminate()