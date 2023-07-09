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

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string page = "http://www.pluralsight-training.xnet";
        }
    }
}
