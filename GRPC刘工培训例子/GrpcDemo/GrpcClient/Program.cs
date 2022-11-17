using Grpc.Net.Client;
using System;

namespace GrpcClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var response = client.SayHello(new HelloRequest() { Name="科创"});
            Console.WriteLine($"调用结果：{response.Message}");
            Console.ReadLine();
        }
    }
}
