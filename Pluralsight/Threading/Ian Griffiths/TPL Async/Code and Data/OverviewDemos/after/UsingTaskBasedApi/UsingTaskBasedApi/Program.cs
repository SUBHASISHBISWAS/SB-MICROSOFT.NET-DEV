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
            var web = new WebClient();
            Console.WriteLine("Starting work");
            Task<string> getTask =
                web.DownloadStringTaskAsync("http://localhost:49182/Slow.ashx");
            //Task<string> getTask = Task<string>.Factory.StartNew(() =>
            //    {
            //        string result =
            //            web.DownloadString("http://localhost:49182/Slow.ashx");
            //        return result;
            //    });
            Console.WriteLine("Setting up continuation");
            getTask.ContinueWith(t =>
                {
                    Console.WriteLine(t.Result);
                });

            Console.WriteLine("Continuing on main thread");
            Thread.Sleep(10000);
        }
    }
}
