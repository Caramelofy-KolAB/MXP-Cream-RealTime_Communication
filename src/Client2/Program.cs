using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("------------------------------------------------------------------------------");
Console.WriteLine("\nWelcome to\n \nMXP-Cream RealTime communication console Client 2\n");
Console.WriteLine("------------------------------------------------------------------------------");

Console.WriteLine("\nConnecting Client to server...\n");

// Hub connection

var hubConnection = new HubConnectionBuilder()
    .WithUrl("http://localhost:61994/pingpong")
    .Build();


hubConnection.On<string>("ReceivePong", (message)
    => {
        Console.WriteLine($"[Client] Received from server: {message}");
    });

try
{
    await hubConnection.StartAsync();
    Console.WriteLine("\nClient connected!\n");
}
catch (Exception ex)
{
    Console.WriteLine($"Could not connect to server: {ex.Message}");
    return;
}

Console.WriteLine("\n> Press 'P' on the keyboard to Ping the server. Press any other key to exit");

while (true)
{
    var key = Console.ReadKey(intercept: true).Key;
    if (key == ConsoleKey.P)
    {
        Console.WriteLine("\n[Client] Sending: Ping");
        await hubConnection.InvokeAsync("SendPing", 2);
    }
    else
    {
        break;
    }
}

// Clean up
await hubConnection.StopAsync();
