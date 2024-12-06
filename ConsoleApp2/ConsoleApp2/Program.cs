﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread Started");
            Thread t1 = new Thread(Method1)
            {
                Name = "Thread1"
            };
            Thread t2 = new Thread(Method2)
            {
                Name = "Thread2"
            };
            Thread t3 = new Thread(Method3)
            {
                Name = "Thread3"
            };
 
            t1.Start();
            t2.Start();
            t3.Start();
            Console.WriteLine("Main Thread Ended");
            Console.Read();
        }
        static async void Method1()
        {
            Console.WriteLine("Method1 Started using " + Thread.CurrentThread.Name);
            ConsoleWriteLine("From Method 1");
            await Task.Run(() =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine("Method1 :" + i);
                }
                Console.WriteLine("Method1 Ended using " + Thread.CurrentThread.Name);
            });
        }
        static void Method2()
        {
            Console.WriteLine("Method2 Started using " + Thread.CurrentThread.Name);
            ConsoleWriteLine("From Method 2");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method2 :" + i);
                //if (i == 3)
                //{
                //    Console.WriteLine("Performing the Database Operation Started");
                //      Thread.Sleep(10000);
                //    Console.WriteLine("Performing the Database Operation Completed");
                //}
            }
            Console.WriteLine("Method2 Ended using " + Thread.CurrentThread.Name);
        }
        static void Method3()
        {
            Console.WriteLine("Method3 Started using " + Thread.CurrentThread.Name);
            ConsoleWriteLine("From Method 3");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Method3 :" + i);
            }
            Console.WriteLine("Method3 Ended using " + Thread.CurrentThread.Name);
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
