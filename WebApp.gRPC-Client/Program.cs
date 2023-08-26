using Grpc.Net.Client;
using WebApp.gRPC_Client;

using var channel = GrpcChannel.ForAddress("https://localhost:7237");
var client = new Greeter.GreeterClient(channel);
var reply = await client.SayHelloAsync(new HelloRequest { Name = "GreeterClient" });

Console.WriteLine("Greeting: " + reply.Message);
Console.WriteLine("Press any key to exit...");
Console.ReadKey();