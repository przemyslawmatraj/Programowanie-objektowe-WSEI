using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Przyklad_watki
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread thread = new Thread(work);
            //thread.Start();
            //thread.Join();


            //thread.IsBackground = true;
            // while (!Console.ReadLine().Equals("Q"))
            //{
            //     Console.WriteLine("Wcisnij Q zeby zakonczyc");
            // }




            Task task = Task.Run(work);
            TaskAwaiter taskAwaiter = task.GetAwaiter();
            taskAwaiter.OnCompleted(() => Console.WriteLine("kONIEC"));
            int c = 10;
            while(c-- > 0)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Main:");
            }
            Console.WriteLine("Koniec");
            Task.Run(() =>
            {
                int result = CalcAsync().Result;
                Console.WriteLine(result);
            });
            
        }
        static void work()
        {
            for(int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.Write($"\rWatek: {i}");
            }
        }

        static async Task<int> CalcAsync()
        {
            string[] lines = await File.ReadAllLinesAsync("d:\\rates.tt");
            return 10;

        }
    }
}
