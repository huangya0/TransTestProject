using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemotingLibrary
{
    public class ConfigObject : System.MarshalByRefObject
    {
        public string RemoteMethod(string key)
        {
            try
            {
                //在线用户的记录,在这个方法里可以获取IP地址
                string ip = ((System.Net.IPAddress)System.Runtime.Remoting.Messaging.CallContext.GetData("ClientIPAddress")).ToString();
                long ticks = System.DateTime.Now.Ticks;
                /*
                 我的需求，是用Remoting做一个应用程序的服务端，这个服务端为若干个客户端提供服务。这个服务端的作用，可以控制客户端的数量，
                 可以为客户端提供数据的中转服务,可以为客户端提供数据库连接的参数。(这样就不用每个客户端都配置，也防止暴露数据库的安全信息)
                 这个RemoteMethody应该是由Client来调用，但是是在Server端运行，这样Client每次调用的时候，获取到IP地址，记录到OnlineClient类中
                 OnlineClient是一个静态类，在IServer这个项目中可以访问到
                */


                OnlineClient.dic.Add(ip, ticks);

                return "OK";
            }
            catch (Exception ex)
            {
                //Log(ex.Message);
            }


            return null;
        }


        // 这是个心跳函数，由窗口中的Timer定时执行,这样，服务端可以根据OnlineClient.dic中的信息，判断客户端是否在线。
        // ticks是时间戳，比如每10秒钟发一次心跳信息,那么在服务端就可以判断，如果超过20秒还没有心跳信息的客户端，就可以认为是离线了
        public void HeartBeat(string key)
        {
            long ticks = System.DateTime.Now.Ticks;
            OnlineClient.dic.Add(key, ticks);
        }

        public List<ListDataModel> GetListDataModel(int userID)
        {
            List<ListDataModel> childMenu2 = new List<ListDataModel>()
                                                            {
                                                                new ListDataModel() { MenuID=8, ParentID=6, ResourceKey="Level3_1", Area="", Controller="Home", ActionName="MenuLevel3_1", RouteValues="", IsSkip=false, DisplayOrder=1},
                                                                new ListDataModel() { MenuID=9, ParentID=6, ResourceKey="Level3_2", Area="", Controller="Home", ActionName="MenuLevel3_2", RouteValues="", IsSkip=false, DisplayOrder=2},
                                                                new ListDataModel() { MenuID=10, ParentID=6, ResourceKey="Level3_3", Area="", Controller="Sample", ActionName="Index", RouteValues="", IsSkip=false, DisplayOrder=3}
                                                            };

            List<ListDataModel> childMenu1 = new List<ListDataModel>()
                                                            {
                                                                new ListDataModel() { MenuID=5, ParentID=4, ResourceKey="Level2_1", Area="", Controller="Home", ActionName="MenuLevel2_1", RouteValues="", IsSkip=false, DisplayOrder=1},
                                                                new ListDataModel() { MenuID=6, ParentID=4, ResourceKey="Level2_2", Area="", Controller="Home", ActionName="MenuLevel2_2", RouteValues="", IsSkip=false, DisplayOrder=2, ChildrenMenu=childMenu2},
                                                                new ListDataModel() { MenuID=7, ParentID=4, ResourceKey="Level2_3", Area="", Controller="Home", ActionName="MenuLevel2_3", RouteValues="", IsSkip=false, DisplayOrder=3}
                                                            };

            List<ListDataModel> returnVal = new List<ListDataModel>()
                                                            {
                                                                new ListDataModel() { MenuID=1, ParentID=null, ResourceKey="Contact Async", Area="", Controller="Home", ActionName="Contact", RouteValues="", IsSkip=false, DisplayOrder=1},
                                                                new ListDataModel() { MenuID=2, ParentID=null, ResourceKey="About", Area="", Controller="Home", ActionName="About", RouteValues="", IsSkip=false, DisplayOrder=2},
                                                                new ListDataModel() { MenuID=3, ParentID=null, ResourceKey="Home", Area="", Controller="Home", ActionName="Index", RouteValues="", IsSkip=false, DisplayOrder=3},
                                                                new ListDataModel() { MenuID=4, ParentID=null, ResourceKey="MultiLeveMenu", Area="", Controller="", ActionName="", RouteValues="", IsSkip=false, DisplayOrder=4, ChildrenMenu=childMenu1}
                                                            };


            return returnVal;
        }

    }
}
