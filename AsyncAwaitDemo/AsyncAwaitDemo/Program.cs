using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task Start !");
            //DotaskWithThread();
            //DOTaskWithAsync();
            Task.Run(() => {
                DOTaskWithAsync2();
            });
            
            Console.WriteLine("Task End !");
            Console.ReadLine();

        }

        public static void DOTaskWithAsync2()
        {

            Console.WriteLine("Await Taskfunction Start");
                            Task.Run(() => {
                    Dotaskfunction();
                });



        }
        public static async void DOTaskWithAsync()
        {

            Console.WriteLine("Await Taskfunction Start");
            await 
                Task.Run(() => {
                Dotaskfunction();
            });


        }
        public static void Dotaskfunction()
        {
            for (int i = 0; i <= 5; i++)
            {

                Console.WriteLine("task {0}  has been done!", i);
            }

        }




    }
}
