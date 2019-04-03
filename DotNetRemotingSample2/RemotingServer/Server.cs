using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace RemotingServer
{
    public class Server
    {
        RemotingServerFrm f = null;
        TcpServerChannel channel = null;

        //因为我是在一个Form里面启动了这个服务端，为了在Form里显示一些信息，所以我把这个From传递进了Server类
        public Server(RemotingServerFrm o)
        {
            f = o;
        }

        public void Start()
        {
            //这是之前用于启动的代码，这种启动方式，是不能获取IP地址的
            //channel = new TcpServerChannel(7575);
            //ChannelServices.RegisterChannel(channel, false);            
            //RemotingConfiguration.RegisterWellKnownServiceType(typeof(IObject.ConfigObject), "Config", WellKnownObjectMode.Singleton);


            //------------------------------------------------------------
            //这段代码，就是用于启动Remoting的服务端
            BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
            provider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            ClientIPServerSinkProvider IpProvider = new ClientIPServerSinkProvider();
            provider.Next = IpProvider;//加入接收链

            IDictionary props = new Hashtable();
            props["port"] = 7575;
            channel = new TcpServerChannel(props, provider);
            ChannelServices.RegisterChannel(channel, false);


            //LifetimeServices.LeaseTime = TimeSpan.Zero;//租用周期，不知道有啥用
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemotingLibrary.ConfigObject), "Config", WellKnownObjectMode.Singleton);
            //------------------------------------------------------------

            //这两个都是Form里我自己定义的方法，各位看官不要看错了. :)
            f.WriteMsg("程序已经启动,Port:7575!");

            f.Start();
        }


        public void Stop()
        {
            if (channel == null) return;
            ChannelServices.UnregisterChannel(channel);
            f.WriteMsg("程序已经停止!");
            f.Stop();
        }
    }
}
