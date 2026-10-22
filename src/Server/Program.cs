using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder();
builder.Services.AddSignalR();

// App

var app = builder.Build();

app.MapHub<PingPongHub>("/pingpong");

Console.Title = "Server";

Console.WriteLine("\nStarting up server on http://localhost:61994...\n");

app.Run();

public class PingPongHub: Hub
{
    public async Task SendPing(int clientNr)
    {
        Console.WriteLine($"[Server] Received Ping from client {clientNr}! Responding with Pong...");
        await Clients.All.SendAsync("ReceivePong", $"Pong - invoked by Client {clientNr}");
    }
}



