using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using ModelContextProtocol.Server;
using System.ComponentModel;

var builder = Host.CreateApplicationBuilder(args);

builder.Logging.AddConsole(options => {
    options.LogToStandardErrorThreshold = LogLevel.Trace;
});

builder.Services.AddMcpServer()
    .WithStdioServerTransport()
    .WithToolsFromAssembly();

Console.WriteLine(builder.Environment.ContentRootPath);
var app = builder.Build();

await app.RunAsync();

[McpServerToolType]
public static class HelloTool
{
    [McpServerTool(Name = "HelloTool"), Description("Say hello to Sri Lanka")]
    public static void SayHello()
    {
        Console.WriteLine("Hello Sri Lanka!");
        
    }
}