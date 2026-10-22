using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder();
builder.Services.AddSignalR();

// App

var app = builder.Build();

app.MapHub<PingPongHub>("/pingpong");

Console.WriteLine("\nStarting up server http://localhost:61994...\n");

app.Run();

public class PingPongHub: Hub
{
    public async Task SendPing()
    {
        Console.WriteLine("[Server] Received Ping from a client! Responding with Pong...");
        await Clients.All.SendAsync("ReceivePong", "Pong");
    }
}



