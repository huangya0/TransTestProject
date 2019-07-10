using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeadLoopConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
            Run2();
            Console.ReadKey();
        }
        //死循环，会造成cpu内存占用过高
        static void Run()
        {
            Thread th = new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine("hello windbg");
                }
            });
            th.Start();
        }
        //不会占用太高的cpu资源
        static void Run2()
        {
            Thread th = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("hello windbg2");
                }
            });
            th.Start();
        }
    }
}
