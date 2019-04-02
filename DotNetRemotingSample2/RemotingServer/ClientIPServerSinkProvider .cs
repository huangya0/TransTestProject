using System;
using System.Collections;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace RemotingServer
{
    public class ClientIPServerSinkProvider : IServerChannelSinkProvider
    {
        private IServerChannelSinkProvider next = null;


        public ClientIPServerSinkProvider()
        {
        }


        public ClientIPServerSinkProvider(IDictionary properties, ICollection providerData)
        {
        }


        public void GetChannelData(IChannelDataStore channelData)
        {
        }


        public IServerChannelSink CreateSink(IChannelReceiver channel)
        {
            IServerChannelSink nextSink = null;
            if (next != null)
            {
                nextSink = next.CreateSink(channel);
            }


            return new ClientIPServerSink(nextSink);
        }


        public IServerChannelSinkProvider Next
        {
            get { return next; }
            set { next = value; }
        }
    }
}
