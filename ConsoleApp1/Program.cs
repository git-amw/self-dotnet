using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleWriteLine("Main Thread Started");
            //Method1();
            //Console.WriteLine("Moving forward from method1");
            //Method2();
            //Console.WriteLine("Moving forward from method2");


            Middle();
            Console.WriteLine("While calculation let's have a CUP of TEA ");

            ConsoleWriteLine("Main Thread Ended");
            Console.ReadKey();
        }

        static async Task Middle()
        {
            int result = await Calculate();
            Console.WriteLine(result);
        }

        static async Task<int> Calculate()
        {
            int ans = 0;
            await Task.Run(() => 
            {
                ConsoleWriteLine("Allocated to Calculate function");
                for (int i = 0; i < 10; i++)
                {
                    ans += i;
                }
            });
            Console.WriteLine("from here");
            return ans;
        }

        static async Task Method1()
        {
            ConsoleWriteLine("From method 1");
            await Task.Run(() =>
            {
                ConsoleWriteLine("Form method 1");
                Console.WriteLine("Method 1 changing ..");
                Console.WriteLine("Method 1 Ending..");
            });
        }
        static async Task Method2()
        {
            ConsoleWriteLine("From method 2");
            await Task.Run(() =>
            {
                ConsoleWriteLine("from method 2");
                Console.WriteLine("Method 2 Starting..");
                Console.WriteLine("Method 2 Ending..");
            });
        }

        static void ConsoleWriteLine(string str)
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            Console.ForegroundColor = threadId == 1 ? ConsoleColor.White : ConsoleColor.Cyan;
            Console.WriteLine(
               $" Thread {threadId} {str}");
        }
    }
}
