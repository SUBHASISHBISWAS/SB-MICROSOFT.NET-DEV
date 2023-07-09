using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    class AutoResetEventExample
    {
        static EventWaitHandle  aWaitHandle=new AutoResetEvent(false);

        //public static void Main()
        //{
        //    new Thread(Waiter).Start();
        //    Thread.Sleep(5000);
        //    aWaitHandle.Set();//signal the waiting thread
        //}


        public static void Waiter()
        {
            Console.WriteLine("Waiting...");
            Thread.Sleep(1000);
            aWaitHandle.WaitOne();//Thread will block and wait for to be signaled
            Console.WriteLine("Notified...");
            
        }
    }
}
