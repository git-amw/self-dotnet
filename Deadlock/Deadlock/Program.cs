using System;
using System.Threading;
using System.Threading.Tasks;

namespace Deadlock
{
    class Program
    {
        static object obj1 = new object();
        static object obj2 = new object();
        static void Main(string[] args)
        {
            Thread t1 = new Thread(MethodOne)
            {
                Name = "Thread A"
            };
            Thread t2 = new Thread(MethodTwo)
            {
                Name = "Thread B"
            };
            t1.Start();
            t2.Start();
            //foo();
            Console.ReadLine();
        }
        static void foo()
        {
            object lock1 = new object();
            object lock2 = new object();
            Console.WriteLine("Starting...");
            var task1 = Task.Run(() =>
            {
                lock (lock1)
                {
                    Thread.Sleep(1000);
                    lock (lock2)
                    {
                        Console.WriteLine("Finished Thread 1");
                    }
                }
            });

            var task2 = Task.Run(() =>
            {
                lock (lock2)
                {
                    Thread.Sleep(1000);
                    lock (lock1)
                    {
                        Console.WriteLine("Finished Thread 2");
                    }
                }
            });

            Task.WaitAll(task1, task2);
            Console.WriteLine("Finished...");
        }
        static void MethodOne()
        {
            lock (obj1)
            {
                Thread.Sleep(1000);
                lock (obj2)
                {
                    Console.WriteLine("From Method One");
                }
            }
        }
        static void MethodTwo()
        {
            lock (obj2)
            {
                Thread.Sleep(1000);
                lock (obj1)
                {
                    Console.WriteLine("From Method One");
                }
            }
        }
    }
}
