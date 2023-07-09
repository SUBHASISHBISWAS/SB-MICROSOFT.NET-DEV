using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    class CancellationTokenDemo
    {
        //public static void Main()
        //{
            
        //    CancellationTokenSource cts = new CancellationTokenSource();
        //    ThreadPool.QueueUserWorkItem(state => CalculateCount(cts, 10000));
        //    //new Thread(() => CalculateCount(cts, 10)).Start();
        //    cts.Token.Register(()=>Console.WriteLine("Cancelled-1"));
        //    cts.Token.Register(() => Console.WriteLine("Cancelled-2"));
        //    Console.WriteLine("Press Enter To cancel the Operation");
        //    Console.ReadLine();
        //    cts.Cancel(true);
            
        //}

        static void CalculateCount(CancellationTokenSource cts,Int32 count)
        {
            for (int i = 0; i < count; i++)
            {
                if (cts.IsCancellationRequested)
                {
                    Console.WriteLine("Operation Cancelled");
                    break;
                }
                Console.WriteLine(i);
                Thread.Sleep(100);
            }
            Console.WriteLine("Count is Done");
        }
    }
}
