using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomTimer
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        TimerCustom timer = new TimerCustom();

    //        timer.Interval = 1500;

    //        timer.Elapsed += (obj, evt) =>
    //        {
    //            TimerCustom singleTimer = obj as TimerCustom;

    //            if (singleTimer != null)
    //            {
    //                if (singleTimer.queue.Count != 0)
    //                {
    //                    var item = singleTimer.queue.Dequeue();

    //                    Send(item);
    //                }
    //            }
    //        };

    //        timer.Start();

    //        Console.Read();
    //    }

    //    static void Send(int obj)
    //    {
    //        //随机暂定8-10s
    //        Thread.Sleep(new Random().Next(8000, 10000));

    //        Console.WriteLine("当前时间：{0}，定时数据发送成功！", DateTime.Now);
    //    }
    //}

    //class TimerCustom : System.Timers.Timer
    //{
    //    public Queue<int> queue = new Queue<int>();

    //    public TimerCustom()
    //    {
    //        for (int i = 0; i < short.MaxValue; i++)
    //        {
    //            queue.Enqueue(i);
    //        }
    //    }
    //}


    //-------------------------------------------------------------------------------


    class Program
    {
        static void Main(string[] args)
        {
            TimerCustom timer = new TimerCustom();

            timer.Interval = 1500;

            timer.Elapsed += (obj, evt) =>
            {
                TimerCustom singleTimer = obj as TimerCustom;

                 //先停掉
                 singleTimer.Stop();

                if (singleTimer != null)
                {
                    if (singleTimer.queue.Count != 0)
                    {
                        var item = singleTimer.queue.Dequeue();

                        Send(item);

                         //发送完成之后再开启
                         singleTimer.Start();
                    }
                }
            };

            timer.Start();

            Console.Read();
        }

        static void Send(int obj)
        {
            Thread.Sleep(new Random().Next(000, 1000));

            Console.WriteLine("当前时间：{0}，邮件发送成功！", DateTime.Now);
        }
    }

    class TimerCustom : System.Timers.Timer
    {
        public Queue<int> queue = new Queue<int>();

        public object lockMe = new object();

        /// <summary>
        /// 为保持连贯性，默认锁住两个
        /// </summary>
        public long lockNum = 0;

        public TimerCustom()
        {
            for (int i = 0; i < short.MaxValue; i++)
            {
                queue.Enqueue(i);
            }
        }
    }
}