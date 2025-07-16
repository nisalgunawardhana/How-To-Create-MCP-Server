using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using ModelContextProtocol.Server;
using System.ComponentModel;

// Create a host builder to configure the services
var builder = Host.CreateApplicationBuilder(args);

// Configure the logging to use the console
builder.Logging.AddConsole(options => {
    options.LogToStandardErrorThreshold = LogLevel.Trace;
});

// Dependencies
builder.Services.AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

Console.WriteLine(builder.Environment.ContentRootPath);

var app = builder.Build();

await app.RunAsync();

// Create MCP Tools here
[McpServerToolType]
public static class HelloTool
{
    [McpServerTool(Name="HelloTool"),Description("Can you say hello?")]
    public static void SayHello()
    {
        Console.WriteLine("Hello, Srilanka!");
    }
}