using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t = new Thread(a => { Console.WriteLine("coś"); });
            t.Start();
            //Thread.Sleep(3000);
            Task task = new Task(() => Console.WriteLine("task"));
            Task task2 = new Task(() =>
            {
                Thread.Sleep(2000);

            });
            task.Start();
            task2.Start();
            Task.WaitAll(task, task2);
            PrintOK().Wait();
            Console.WriteLine("Hello World!");
            //Console.Read();

        }
        public static async Task PrintOK()
        {
            await Task.Run(() => Console.WriteLine("OK"));
        }
    }
}
