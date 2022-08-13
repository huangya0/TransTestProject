using GreeterService;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using System;

namespace GrpcGreeterClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = channel.CreateGrpcService<IGreeterService>();

            var reply = client.SayHelloAsync(
                new HelloRequest { Name = "科创" });

            Console.WriteLine($"Greeting: {reply.Result.Message}");
            Console.WriteLine("Press any key to exit!");
            Console.ReadKey();
        }
    }
}
