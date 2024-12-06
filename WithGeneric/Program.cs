using System;
using System.Diagnostics;
using withgeneric;

namespace WithGeneric
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericSort obj = new GenericSort();
            Stopwatch stopWatch = new Stopwatch();
            Console.WriteLine("1 Sort 100 Random Integer");
            Console.WriteLine("2 Sort 100 Random String");
            Console.WriteLine("3 Sort 100 Random Date outcome");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        stopWatch.Start();

                        for (int i = 0; i < 10000; i++)
                        {
                            obj.SortData<int>("integerinp.txt");
                        }

                        stopWatch.Stop();
                        // Get the elapsed time as a TimeSpan value.
                        TimeSpan ts = stopWatch.Elapsed;
                        // Format and display the TimeSpan value.
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);
                        Console.WriteLine("RunTime " + elapsedTime);
                        break;
                    }
                case 2:
                    {
                        stopWatch.Start();

                        for (int i = 0; i < 10000; i++)
                        {
                            obj.SortData<string>("stringinp.txt");
                        }

                        stopWatch.Stop();

                        // Get the elapsed time as a TimeSpan value.
                        TimeSpan ts = stopWatch.Elapsed;

                        // Format and display the TimeSpan value.
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);
                        Console.WriteLine("RunTime " + elapsedTime);
                        break;
                    }
                case 3:
                    {
                        stopWatch.Start();

                        for (int i = 0; i < 10000; i++)
                        {
                        }

                        stopWatch.Stop();

                        // Get the elapsed time as a TimeSpan value.
                        TimeSpan ts = stopWatch.Elapsed;

                        // Format and display the TimeSpan value.
                        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            ts.Hours, ts.Minutes, ts.Seconds,
                            ts.Milliseconds / 10);
                        Console.WriteLine("RunTime " + elapsedTime);
                        break;
                    }
            }


        }
    }
}
