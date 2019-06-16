using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadConsole1
{
    class Program
    {
        ////static bool _done;
        //private static bool done;

        //static void Main(string[] args)
        //{
        //    new Thread(Go).Start();
        //    new Thread(Go).Start();
        //    Go();
        //}

        //static void Go()
        //{
        //    if (!done)
        //    {
        //        done = true;
        //        Console.WriteLine("Done");
        //    }

        //}

        //--------------------------------------------

        //static object lockObj = new object();
        //static bool done = false;
        //static void Main(string[] args)
        //{

        //    var p = new Program();
        //    new Thread(p.Go).Start();
        //    //Thread.Sleep(1000);
        //    p.Go();
        //    //Console.ReadKey();
        //}

        //void Go()
        //{
        //    //lock (lockObj)
        //    {
        //        if (!done)
        //        {
        //            Console.WriteLine("Done");
        //            done = true;
        //        }
        //    }
        //}



        ////----------------------------------------------
        //static bool done = false;
        //static void Main(string[] args)
        //{
        //    Program p = new Program();
        //    new Thread(p.Go).Start();
        //    p.Go();
        //    Console.ReadKey();
        //}

        //void Go()
        //{
        //    if (!done)
        //    {
        //        Console.WriteLine("Done");
        //        done = true;
        //    }
        //}

        //---------------------------------

        //static void Main(string[] args)
        //{
        //    Thread t = new Thread(Go);
        //    t.Start();
        //    //t.Join();

        //    Thread t2 = new Thread(Go2);
        //    t2.Start();
        //    t2.Join();

        //    Console.WriteLine("Thread t has ended!");
        //    Console.ReadKey();

        //}
        //static void Go()
        //{
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        Console.Write("y");
        //    }
        //}

        //static void Go2()
        //{
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        Console.Write("x");
        //    }
        //}


        //---------------------------------------------
        //static void Main(string[] args)
        //{
        //    Thread t = new Thread(()=> {
        //        Print("test", "");
        //    });

        //    t.Start();
        //}


        //static void Print(string message, string ss)
        //{
        //    Console.WriteLine(message);
        //}
        //--------------------------------------------

        //static void Main(string[] args)
        //{
        //    Thread t = new Thread(Print);
        //    t.Start("message1");
        //}

        //static void Print(object obj)
        //{
        //    string message = (string)obj;//必须进行转换
        //    Console.WriteLine(message);
        //}

        //--------------------------------------------

        //static void Main(string[] args)
        //{
        //    //Thread t = new Thread(ForeachMethod1);
        //    //t.Start();

        //    for (int i = 0; i < 10; i++)
        //    {
        //        int temp = i;
        //        Thread t = new Thread(() => Console.Write(temp));
        //        t.Start();
        //        //t.Join();
        //    }

        //}

        //private static void ForeachMethod1()
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        new Thread(() => Console.Write(i)).Start();
        //    }
        //}

        //----------------------------------------------
        //static void Main(string[] args)
        //{
        //    string text = "A";
        //    Thread a = new Thread(() => Console.WriteLine(text));
        //    a.Start();
        //    //a.Join();

        //    text = "B";
        //    Thread b = new Thread(() => Console.WriteLine(text));


        //    b.Start();

        //}

        //---------------------------------------------------

        //static void Main(string[] args)
        //{
        //    Thread.CurrentThread.Name = "Main Thread";
        //    Thread t = new Thread(Go);
        //    t.Name = "Worker Thread";
        //    t.Start();
        //    Go();
        //    Console.ReadKey();
        //}
        //static void Go()
        //{
        //    Console.WriteLine("Go! The current thread is {0}", Thread.CurrentThread.Name);
        //}

        //--------------------------------------------------------
        //static void Main(string[] args)
        //{
        //    Task<string> t = Task.Factory.StartNew<string>(()=> {
        //        return Go("");

        //    });
        //    //t.Start();
        //    //t.Wait();
        //    var result = t.Result;
        //    Console.WriteLine(result);
        //}

        //static string Go(string ss)
        //{
        //    Console.WriteLine("From the thread pool start...");
        //    Thread.Sleep(3000);
        //    Console.WriteLine("From the thread pool end");
        //    return "completed!";
        //}

        //-------------------------------------------------
        //static void Main(string[] args)
        //{
        //    Task<string> task = Task.Factory.StartNew<string>(
        //        () => DownloadString("http://www.baidu.com"));
        //    //调用其他方法
        //    //

        //    //可以用task的Result的属性来获得task返回值。
        //    //如果这个任务还在运行，当前的主线程将会被阻塞，直到这个任务完成。
        //    string result = task.Result;
        //    Console.WriteLine(result);
        //}

        //static string DownloadString(string uri)
        //{
        //    using (var wc = new System.Net.WebClient())
        //    {
        //        return wc.DownloadString(uri);
        //    }
        //}
        //--------------------------------------------------------

        //static void Main(string[] args)
        //{
        //    ThreadPool.QueueUserWorkItem(Go);
        //    ThreadPool.QueueUserWorkItem(Go, "123");
        //}

        //static void Go(object data)
        //{
        //    Console.WriteLine("A from thread pool! " + data);
        //}

        //-----------------------------------------------------------

        static void Main(string[] args)
        {
            Func<string, int> t = Go;
            IAsyncResult result = t.BeginInvoke("test by zack", null, null);
            //
            // ... 这里可以执行其他并行的任务
            //
            Console.WriteLine(Caculate());

            int len = t.EndInvoke(result);
            Console.WriteLine("String lenth is： " + len);

            
        }

        static int Go(string messsage)
        {
            Thread.Sleep(2000);
            return messsage.Length;
        }

        static int Caculate()
        {
            for (int i = 0; i < ushort.MaxValue; i++)
            { }

            Thread.Sleep(1000);
            return ushort.MaxValue;
        }



    }
}
