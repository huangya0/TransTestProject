using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

        //static void Main(string[] args)
        //{
        //    Func<string, int> t = Go;
        //    IAsyncResult result = t.BeginInvoke("test by zack", null, null);
        //    //
        //    // ... 这里可以执行其他并行的任务
        //    //
        //    Console.WriteLine(Caculate());

        //    int len = t.EndInvoke(result);
        //    Console.WriteLine("String lenth is： " + len);


        //}

        //static int Go(string messsage)
        //{
        //    Thread.Sleep(2000);
        //    return messsage.Length;
        //}

        //static int Caculate()
        //{
        //    for (int i = 0; i < ushort.MaxValue; i++)
        //    { }

        //    Thread.Sleep(1000);
        //    return ushort.MaxValue;
        //}
        //-------------------------------------------------------------

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("starting Main function---------------");
        //    Thread.CurrentThread.Name = "Main Thread";
        //    int result = Add(2);
        //    Console.WriteLine($"Result is : {result.ToString()}");

        //    for (int i = 1; i < 4; i++)
        //    {
        //        Thread.Sleep(TimeSpan.FromSeconds(1));
        //        Console.WriteLine($"{Thread.CurrentThread.Name} started {i} seconds");

        //    }
        //    Console.WriteLine("end Main function-----readkey----------");
        //    Console.ReadKey();
        //}

        //private static int Add(int num)
        //{
        //    if (Thread.CurrentThread.IsThreadPoolThread)
        //    {
        //        Thread.CurrentThread.Name = "Pool Thread";
        //    }

        //    Console.WriteLine("--------starting add function---------------");
        //    int sum = 0;
        //    for (int i = 1; i < num + 1; i++)
        //    {
        //        sum += i;
        //        Thread.Sleep(TimeSpan.FromSeconds(1));
        //        Console.WriteLine($"--------{Thread.CurrentThread.Name} started {i} seconds");
        //    }

        //    Console.WriteLine("--------end add function---------------");
        //    return sum;

        //}

        //----------------------------------------------------
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("starting Main function---------------");
        //    Thread.CurrentThread.Name = "Main Thread";
        //    //方式一， 直执行
        //    //int result = Add(2);

        //    //方式二
        //    //Task<int> task = Task.Factory.StartNew<int>(()=> {
        //    //    return Add(2);
        //    //});

        //    ////方式三
        //    Thread t = new Thread(() =>
        //    {
        //        int result = Add(2);
        //        Console.WriteLine($"Result is : {result.ToString()}");
        //    });

        //    t.Start();


        //    for (int i = 1; i < 4; i++)
        //    {
        //        Thread.Sleep(TimeSpan.FromSeconds(1));
        //        Console.WriteLine($"{Thread.CurrentThread.Name} started {i} seconds");

        //    }

        //    //方式二
        //    //int result = task.Result;
        //    //Console.WriteLine($"Result is : {result.ToString()}");

        //    Console.WriteLine("end Main function-----readkey----------");
        //    Console.ReadKey();
        //}

        //private static int Add(int num)
        //{
        //    if (Thread.CurrentThread.IsThreadPoolThread)
        //    {
        //        Thread.CurrentThread.Name = "Pool Thread";
        //    }

        //    Console.WriteLine("--------starting add function---------------");
        //    int sum = 0;
        //    for (int i = 1; i < num + 1; i++)
        //    {
        //        sum += i;
        //        Thread.Sleep(TimeSpan.FromSeconds(1));
        //        Console.WriteLine($"--------{Thread.CurrentThread.Name} started {i} seconds");
        //    }

        //    Console.WriteLine("--------end add function---------------");
        //    return sum;

        //}

        //--------------------------------------------------------------------------------------------------

        //static void Main(string[] args)
        //{

        //    Func<int, int> addDelegate = Add;

        //    Console.WriteLine("starting Main function---------------");
        //    Thread.CurrentThread.Name = "Main Thread";
        //    string msg = "I am here";
        //    //方法一，
        //    //addDelegate.BeginInvoke(2, AddCallback, msg);
        //    //方法二，
        //    IAsyncResult result = addDelegate.BeginInvoke(2, null, msg);

        //    for (int i = 1; i < 4; i++)
        //    {
        //        Thread.Sleep(TimeSpan.FromSeconds(1));
        //        Console.WriteLine($"{Thread.CurrentThread.Name} started {i} seconds");

        //    }

        //    ////方法二，
        //    int sum = addDelegate.EndInvoke(result);
        //    Console.WriteLine($"Result is : {sum.ToString()}");

        //    Console.WriteLine("end Main function-----readkey----------");
        //    Console.ReadKey();
        //}

        //////方法一，
        ////private static void AddCallback(IAsyncResult ar)
        ////{
        ////    var msg = ar.AsyncState;
        ////    var result = (AsyncResult)ar;
        ////    Func<int, int> myDelegate = (Func<int, int>)result.AsyncDelegate;
        ////    int sum = myDelegate.EndInvoke(ar);
        ////    Console.WriteLine($"Result is : {sum.ToString()}");
        ////}

        //private static int Add(int num)
        //{
        //    if (Thread.CurrentThread.IsThreadPoolThread)
        //    {
        //        Thread.CurrentThread.Name = "Pool Thread";
        //    }

        //    Console.WriteLine("--------starting add function---------------");
        //    int sum = 0;
        //    for (int i = 1; i < num + 1; i++)
        //    {
        //        sum += i;
        //        Thread.Sleep(TimeSpan.FromSeconds(1));
        //        Console.WriteLine($"--------{Thread.CurrentThread.Name} started {i} seconds");
        //    }

        //    Console.WriteLine("--------end add function---------------");
        //    return sum;

        //}

        //==================================================================

        //static void Main(string[] args)
        //{
        //    Task task1 = new Task(() =>
        //    {
        //        Thread.Sleep(500);
        //        Console.WriteLine("线程1执行完毕！");
        //    });
        //    task1.Start();
        //    Task task2 = new Task(() =>
        //    {
        //        Thread.Sleep(1000);
        //        Console.WriteLine("线程2执行完毕！");
        //    });
        //    task2.Start();
        //    ////task1，task2执行完了后执行后续操作
        //    //Task.WhenAll(task1, task2).ContinueWith((t) =>
        //    //{
        //    //    Thread.Sleep(100);
        //    //    Console.WriteLine("执行后续操作完毕！");
        //    //});

        //    Task.Factory.ContinueWhenAll(new Task[] { task1, task2 }, (t)=> {
        //        Thread.Sleep(1000);
        //        Console.WriteLine("执行后续操作完毕！");
        //    });

        //    Console.WriteLine("主线程执行完毕！");
        //    Console.ReadKey();
        //}
        //----------------------------------------------------------------------

        //static void Main(string[] args)
        //{
        //    bool isStop = false;
        //    int index = 0;
        //    Thread t = new Thread(()=> {
        //        while (!isStop)
        //        {
        //            Thread.Sleep(1000);
        //            Console.WriteLine($"第{++index}次执行，线程运行中。。。。");
        //        }
        //        Console.WriteLine("停止执行");
        //    });
        //    t.Start();

        //    Thread.Sleep(6000);
        //    isStop = true;
        //    Console.WriteLine("主线程完毕");
        //    Console.ReadKey();
        //}
        //------------------------------------------------------------------

        //static void Main(string[] args)
        //{
        //    //CancellationTokenSource source = new CancellationTokenSource();
        //    bool isStop = false;
        //    int index = 0;
        //    //开启一个task执行任务
        //    Task task1 = new Task(() =>
        //    {
        //        //while (!source.IsCancellationRequested)
        //        while(!isStop)
        //        {
        //            Thread.Sleep(1000);
        //            Console.WriteLine($"第{++index}次执行，线程运行中...");
        //        }
        //        Console.WriteLine("停止执行");
        //    });
        //    task1.Start();
        //    //五秒后取消任务执行
        //    Thread.Sleep(5000);
        //    //source.Cancel()方法请求取消任务，IsCancellationRequested会变成true
        //    //source.Cancel();
        //    isStop = true;
        //    Console.WriteLine("主线程完毕");
        //    Console.ReadKey();
        //}

        //-----------------------------------------------------
        //static void Main(string[] args)
        //{
        //    CancellationTokenSource source = new CancellationTokenSource();
        //    //注册任务取消的事件
        //    source.Token.Register(() =>
        //    {
        //        Console.WriteLine("任务被取消后执行xx操作！");
        //    });

        //    int index = 0;
        //    //开启一个task执行任务
        //    Task task1 = new Task(() =>
        //    {
        //        while (!source.IsCancellationRequested)
        //        {
        //            Thread.Sleep(1000);
        //            Console.WriteLine($"第{++index}次执行，线程运行中...");
        //        }
        //    });
        //    task1.Start();
        //    //延时取消，效果等同于Thread.Sleep(5000);source.Cancel();
        //    source.CancelAfter(5000);
        //    Console.ReadKey();
        //}
        //------------------------------------------------------

        //static void Main(string[] args)
        //{
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        //ThreadPool执行任务
        //        ThreadPool.QueueUserWorkItem(new WaitCallback((obj) => {
        //            Console.WriteLine($"第{obj}个执行任务");
        //        }), i);
        //    }
        //    Console.ReadKey();
        //}
        //-------------------------------------------------------------

        //static void Main(string[] args)
        //{
        //    //1.new方式实例化一个Task，需要通过Start方法启动
        //    Task task = new Task(() =>
        //    {
        //        Thread.Sleep(100);
        //        Console.WriteLine($"hello, task1的线程ID为{Thread.CurrentThread.ManagedThreadId}");
        //    });
        //    task.Start();

        //    //2.Task.Factory.StartNew(Action action)创建和启动一个Task
        //    Task task2 = Task.Factory.StartNew(() =>
        //    {
        //        Thread.Sleep(100);
        //        Console.WriteLine($"hello, task2的线程ID为{ Thread.CurrentThread.ManagedThreadId}");
        //    });

        //    //3.Task.Run(Action action)将任务放在线程池队列，返回并启动一个Task
        //    Task task3 = Task.Run(() =>
        //    {
        //        Thread.Sleep(100);
        //        Console.WriteLine($"hello, task3的线程ID为{ Thread.CurrentThread.ManagedThreadId}");
        //    });
        //    Console.WriteLine("执行主线程！");
        //    Console.ReadKey();
        //}

        //-----------------------------------------

        //static void Main(string[] args)
        //{
        //    ////1.new方式实例化一个Task，需要通过Start方法启动
        //    Task<string> task = new Task<string>(() =>
        //    {
        //        return $"hello, task1的ID为{Thread.CurrentThread.ManagedThreadId}";
        //    });
        //    task.Start();

        //    ////2.Task.Factory.StartNew(Func func)创建和启动一个Task
        //    Task<string> task2 = Task.Factory.StartNew<string>(() =>
        //    {
        //        return $"hello, task2的ID为{ Thread.CurrentThread.ManagedThreadId}";
        //    });

        //    ////3.Task.Run(Func func)将任务放在线程池队列，返回并启动一个Task
        //    Task<string> task3 = Task.Run<string>(() =>
        //    {
        //        return $"hello, task3的ID为{ Thread.CurrentThread.ManagedThreadId}";
        //    });

        //    Console.WriteLine("执行主线程！");
        //    Console.WriteLine(task.Result);

        //    Console.WriteLine(task3.Result);
        //    Console.WriteLine(task2.Result);
        //    Console.ReadKey();
        //}
        //-----------------------------------------------------

        //static void Main(string[] args)
        //{
        //    Task task = new Task(() =>
        //    {
        //        Thread.Sleep(100);
        //        Console.WriteLine("执行Task结束!");
        //    });
        //    //同步执行，task会阻塞主线程
        //    task.RunSynchronously();
        //    Console.WriteLine("执行主线程结束！");
        //    Console.ReadKey();
        //}
        //-----------------------------------------------------

        //static void Main(string[] args)
        //{
        //    Thread th1 = new Thread(() => {
        //        Thread.Sleep(500);
        //        Console.WriteLine("线程1执行完毕！");
        //    });
        //    th1.Start();
        //    Thread th2 = new Thread(() => {
        //        Thread.Sleep(1000);
        //        Console.WriteLine("线程2执行完毕！");
        //    });
        //    th2.Start();
        //    //阻塞主线程
        //    th1.Join();
        //    th2.Join();
        //    Console.WriteLine("主线程执行完毕！");
        //    Console.ReadKey();
        //}

        //-----------------------------------------------------

        //static void Main(string[] args)
        //{
        //    Task task1 = new Task(() => {
        //        Thread.Sleep(500);
        //        Console.WriteLine("线程1执行完毕！");
        //    });
        //    task1.Start();
        //    Task task2 = new Task(() => {
        //        Thread.Sleep(1000);
        //        Console.WriteLine("线程2执行完毕！");
        //    });
        //    task2.Start();
        //    //阻塞主线程。task1,task2都执行完毕再执行主线程
        //    //执行【task1.Wait();task2.Wait();】可以实现相同功能
        //    Task.WaitAll(new Task[] { task1, task2 });
        //    Console.WriteLine("主线程执行完毕！");
        //    Console.ReadKey();
        //}
        //-----------------------------------------------------

        //static void Main(string[] args)
        //{
        //    Task task1 = new Task(() => {
        //        Thread.Sleep(500);
        //        Console.WriteLine("线程1执行完毕！");
        //    });
        //    task1.Start();
        //    Task task2 = new Task(() => {
        //        Thread.Sleep(1000);
        //        Console.WriteLine("线程2执行完毕！");
        //    });
        //    task2.Start();
        //    //task1，task2执行完了后执行后续操作
        //    Task.WhenAll(task1, task2).ContinueWith((t) => {
        //        Thread.Sleep(100);
        //        Console.WriteLine("执行后续操作完毕！");
        //    });

        //    Console.WriteLine("主线程执行完毕！");
        //    Console.ReadKey();
        //}

        //-----------------------------------------------------

        //static void Main(string[] args)
        //{
        //    CancellationTokenSource source = new CancellationTokenSource();
        //    //注册任务取消的事件
        //    source.Token.Register(() =>
        //    {
        //        Console.WriteLine("任务被取消后执行xx操作！");
        //    });

        //    int index = 0;
        //    //开启一个task执行任务
        //    Task task1 = new Task(() =>
        //    {
        //        while (!source.IsCancellationRequested)
        //        {
        //            Thread.Sleep(1000);
        //            Console.WriteLine($"第{++index}次执行，线程运行中...");
        //        }
        //    });
        //    task1.Start();
        //    //延时取消，效果等同于Thread.Sleep(5000);source.Cancel();
        //    source.CancelAfter(5000);
        //    Console.ReadKey();
        //}

        //-----------------------------------------------------

    }
}
