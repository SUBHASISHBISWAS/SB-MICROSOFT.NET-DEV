using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SummarizeLogFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string logPath = @"C:\Users\Ian Griffiths\Documents\ex090101.log";
            //string logPath = @"\\hethel7\d$\logs\ex081221.log";

            var processor = new LogProcessor(logPath);
            //Console.WriteLine("Waiting...");
            //processor.BlogHitsTask.Wait();
            //Console.WriteLine("Done");

            foreach (var pair in processor.BlogHitsTask.Result.OrderByDescending(p => p.Value))
            {
                Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
            }
        }
    }
}
