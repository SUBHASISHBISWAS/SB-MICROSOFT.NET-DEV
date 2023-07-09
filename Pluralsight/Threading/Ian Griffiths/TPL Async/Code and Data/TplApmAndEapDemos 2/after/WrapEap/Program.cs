using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

namespace WrapEap
{
    public static class WebClientExtensions
    {
        public static Task<string> DownloadStringTaskAsync(this WebClient web, string address)
        {
            var tcs = new TaskCompletionSource<string>();

            DownloadStringCompletedEventHandler h = null;
            h = (s, e) =>
            {
                web.DownloadStringCompleted -= h;

                if (e.Cancelled)
                {
                    tcs.SetCanceled();
                }
                else if (e.Error != null)
                {
                    tcs.SetException(e.Error);
                }
                else
                {
                    tcs.SetResult(e.Result);
                }
            };

            web.DownloadStringCompleted += h;
            web.DownloadStringAsync(new Uri(address));

            return tcs.Task;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string page = "http://www.pluralsight-training.xnet";

            using (var w = new WebClient())
            {
                w.DownloadStringTaskAsync(page)
                    .ContinueWith(t => Console.WriteLine(t.Result.Length))
                    .Wait();
            }
        }
    }
}
