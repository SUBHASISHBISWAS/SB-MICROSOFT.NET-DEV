using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    class ThreadPoolOperations
    {
        //public static void Main()
        //{
        //    Console.WriteLine("Main Thread Queing asynchronous Operation");
        //    ThreadPool.QueueUserWorkItem(ComputeBoundOperation, 5);
        //    Console.WriteLine("Main Thread doing Work");
        //    Thread.Sleep(1000);
        //    Console.WriteLine("Hit enter To stop Program");
        //    Console.ReadLine();
        //}

        static void ComputeBoundOperation(object state)
        {
            Console.WriteLine("In ComputeBound:{0}",state);
            Thread.Sleep(1000);
        }
    }
}
