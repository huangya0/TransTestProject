using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace RemotingServer
{
    public class ClientIPServerSink : BaseChannelObjectWithProperties, IServerChannelSink, IChannelSinkBase
    {


        private IServerChannelSink _next;


        public ClientIPServerSink(IServerChannelSink next)
        {
            _next = next;
        }


        public void AsyncProcessResponse(IServerResponseChannelSinkStack sinkStack, Object state, IMessage msg, ITransportHeaders headers, Stream stream)
        {
        }


        public Stream GetResponseStream(IServerResponseChannelSinkStack sinkStack, Object state, IMessage msg, ITransportHeaders headers)
        {
            return null;
        }


        public System.Runtime.Remoting.Channels.ServerProcessing ProcessMessage(IServerChannelSinkStack sinkStack, IMessage requestMsg, ITransportHeaders requestHeaders, Stream requestStream, out IMessage responseMsg, out ITransportHeaders responseHeaders, out Stream responseStream)
        {
            if (_next != null)
            {
                IPAddress ip = requestHeaders[CommonTransportKeys.IPAddress] as IPAddress;
                //Console.WriteLine(ip.ToString());
                CallContext.SetData("ClientIPAddress", ip);
                ServerProcessing spres = _next.ProcessMessage(sinkStack, requestMsg, requestHeaders, requestStream, out responseMsg, out responseHeaders, out responseStream);


                return spres;
            }
            else
            {
                responseMsg = null;
                responseHeaders = null;
                responseStream = null;


                return new ServerProcessing();
            }
        }


        public IServerChannelSink NextChannelSink
        {
            get { return _next; }
            set { _next = value; }
        }
    }

}
