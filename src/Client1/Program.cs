using Microsoft.AspNetCore.SignalR.Client;

// Hub connection

var hubConnection = new HubConnectionBuilder()
    .WithUrl("http://localhost:61994/pingpong")
    .Build();


hubConnection.On<string>("ReceivePong", (message)
    => {
        Console.WriteLine($"[Client] Received from server: {message}");
    });

await hubConnection.StartAsync();
Console.WriteLine("\nClient connected!\n");

Console.WriteLine("\n> Press 'P' on the keyboard to Ping the server. Press any other key to exit");

while (true)
{
    var key = Console.ReadKey(intercept: true).Key;
    if (key == ConsoleKey.P)
    {
        Console.WriteLine("\n[Client] Sending: Ping");
        await hubConnection.InvokeAsync("SendPing");
    }
    else
    {
        break;
    }
}