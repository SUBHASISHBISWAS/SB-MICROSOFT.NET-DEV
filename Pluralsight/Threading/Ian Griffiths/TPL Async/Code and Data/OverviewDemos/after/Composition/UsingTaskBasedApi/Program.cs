using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace UsingTaskBasedApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var web1 = new WebClient();
            var web2 = new WebClient();
            Console.WriteLine("Starting work");
            Task<string> getSubTask1 =
                web1.DownloadStringTaskAsync("http://localhost:49182/Slow.ashx");
            Task<string> getSubTask2 =
                web2.DownloadStringTaskAsync("http://localhost:49182/Foo.ashx");

            Task<string[]> getTask = Task.WhenAll(getSubTask1, getSubTask2);

            Console.WriteLine("Setting up continuation");
            Task.Factory.ContinueWhenAll(new[] { getSubTask1, getSubTask2 },
                (Task<string>[] tasks) =>
                {
                    foreach (var t in tasks)
                    {
                        if (t.IsFaulted)
                        {
                            Console.WriteLine(t.Exception);
                        }
                        else
                        {
                            Console.WriteLine(t.Result);
                        }
                    }
                }).Wait();
            getTask.ContinueWith(t =>
                {
                    Console.WriteLine("Completed");
                    if (t.IsFaulted)
                    {
                        Console.WriteLine(t.Exception);
                    }
                    else
                    {
                        Console.WriteLine(t.Result);
                    }
                });

            Console.WriteLine("Continuing on main thread");
            Console.ReadKey();
            GC.Collect();
            Thread.Sleep(10000);
        }
    }
}
