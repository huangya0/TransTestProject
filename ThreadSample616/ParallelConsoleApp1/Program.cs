using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelConsoleApp1
{
    delegate int MyDel(int first, int second);//委托声明

    class Program
    {
        //static void Main(string[] args)
        //{
        //    //Parallel.For  计算0到6的平方
        //    Parallel.For(1, 50000, i =>
        //    {
        //        Console.WriteLine($"{i}的平方是{i * i}");
        //    });

        //    //Parallel.ForEach 计算每个字符串的长度
        //    string[] strs = { "We", "hold", "these", "truths" };
        //    Parallel.ForEach(strs, i => Console.WriteLine($"{i}有{i.Length}个字节"));
        //    Console.ReadKey();
        //}

        //-----------------------------------------------------------------------
        //static void Main(string[] args)
        //{
        //    //Parallel.Invoke(
        //    //    () => { Console.WriteLine($"并行执行任务1，线程Id为{Thread.CurrentThread.ManagedThreadId}"); },
        //    //    () => { Console.WriteLine($"并行执行任务2，线程Id为{Thread.CurrentThread.ManagedThreadId}"); }
        //    //    );

        //    //Parallel.Invoke(
        //    //        ()=> { BatchJob(Thread.CurrentThread.ManagedThreadId);  },
        //    //        () => { BatchJob2(Thread.CurrentThread.ManagedThreadId); }
        //    //    );

        //    Parallel.Invoke(
        //            () => {
        //                for (int i = 0; i < 11; i++)
        //                {
        //                    Console.WriteLine($"ThreadID：{Thread.CurrentThread.ManagedThreadId} -- {i}的平方是{i * i}");
        //                }
        //            },
        //            () => {
        //                for (int i = 0; i < 10; i++)
        //                {
        //                    Console.WriteLine($"ThreadID：{Thread.CurrentThread.ManagedThreadId} -- {i}的平方是{i * i}");
        //                }
        //            }
        //        );

        //    Console.ReadKey();
        //}

        //static void BatchJob(int threadId)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine($"ThreadID：{threadId} -- {i}的平方是{i * i}");
        //    }
        //}

        //static void BatchJob2(int threadId)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine($"ThreadID：{threadId} -- {i}的平方是{i * i}");
        //    }
        //}
        //-----------------------------------------------------------------------

        //int count = 0;
        //void Run(object state)
        //{
        //    Console.WriteLine("{0},已经调用了{1}次了", state, ++count);
        //}
        //static void Main(string[] args)
        //{
        //    Program p = new Program();
        //    //2000毫秒后开始调用，每次间隔1000毫秒
        //    Timer timer = new Timer(p.Run, "hello", 2000, 1000);
        //    Console.WriteLine("Timer start");

        //    Console.ReadLine();
        //}

        //--------------------------------------------------------------------
        //static int Sum(int x, int y)
        //{
        //    Thread.Sleep(1000);
        //    return x + y;
        //}

        //static void Main(string[] args)
        //{
        //    MyDel del = Sum;
        //    //调用异步操作（第三个参数是回调函数，第四个参数是额外的值）
        //    IAsyncResult iar = del.BeginInvoke(3, 5, null, null);

        //    //doSomehing...
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Console.WriteLine($"{i}的平方是{i * i}");
        //    }

        //    //执行EndInvoke,如果引用方法Sum没有执行完成，主线程就等待其完成
        //    int result = del.EndInvoke(iar);
        //    Console.WriteLine(result);
        //}

        //--------------------------------------------------------------------

        //static int Sum(int x, int y)
        //{
        //    Thread.Sleep(2000);
        //    return x + y;
        //}
        //static void Main(string[] args)
        //{
        //    MyDel del = Sum;
        //    IAsyncResult iar = del.BeginInvoke(3, 5, null, null);

        //    //通过iar.IsCompleted定期查询完成状态
        //    while (!iar.IsCompleted)//IsCompleted表示调用的异步操作是否完成
        //    {
        //        //doSomething
        //        Thread.Sleep(300);
        //        Console.WriteLine("no done");
        //    }
        //    int result = del.EndInvoke(iar);
        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}
        //--------------------------------------------------------------------

        static int Sum(int x, int y)
        {
            Thread.Sleep(1000);
            return x + y;
        }

        //回调方法的签名和返回值类型必须和AsyncCallBack委托类型一致
        //输入参数为IAsyncResult,返回值是Void类型
        static void CallWhenDone(IAsyncResult iar)
        {
            AsyncResult ar = (AsyncResult)iar;
            MyDel del = (MyDel)ar.AsyncDelegate;
            int result = del.EndInvoke(iar);
            Console.WriteLine("回调函数执行EndInvoke");
            Console.WriteLine("result:{0}", result);
            Console.WriteLine("回调函数完成");
        }

        static void Main(string[] args)
        {
            MyDel del = Sum;
            //执行BeginInvoke方法后原始线程就不用管了，在自定义的回调函数（CallWhenDone）中执行EndInvoke方法
            //IAsyncResult iar = del.BeginInvoke(3, 5, CallWhenDone, null);
            IAsyncResult iar = del.BeginInvoke(3, 5, null, null);

            Console.WriteLine("开启新线程，异步任务完成后执行回调函数");
            //doSomething
            Console.WriteLine("回调执行不阻塞原始线程");

            while (true)
            {
                if (iar.IsCompleted)
                {
                    int result = del.EndInvoke(iar);
                    Console.WriteLine(result);
                }
                
            }


            Console.ReadKey();
        }

    }
}
