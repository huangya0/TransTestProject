using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemotingLibrary
{
    public static class OnlineClient
    {
        public static int maxClients = -1; //如果是-1，说明不限制客户端数量，这个值，由IServer来赋值
        public static Dictionary<string, long> dic = new Dictionary<string, long>();
    }
}
