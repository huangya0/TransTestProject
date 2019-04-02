using RemotingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace RemotingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClientChannel channel = new TcpClientChannel();
            ChannelServices.RegisterChannel(channel, false);
            Hello obj = (Hello)Activator.GetObject(typeof(Hello), "tcp://localhost:8086/hi");
            if (obj == null)
            {
                Console.WriteLine("could not locate server");
                return;

            }
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(obj.Greeting($"Name: {Console.ReadLine()}"));
            }
            Console.ReadLine();
            
        }
    }
}
