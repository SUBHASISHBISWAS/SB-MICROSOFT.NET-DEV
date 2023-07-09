using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    class StaticFieldDataSharing
    {
        static bool done;// Static fields are shared between all threads

        readonly static object locker = new object();

        //public static void Main()
        //{
        //    Thread.CurrentThread.Name = "Thread-0";
        //    Thread t = new Thread(Go);
        //    t.Name = "Thread-1";
        //    t.Start();
        //    Go();
        //}

        static void Go()
        {
            lock (locker)
            {
                if (!done)
                {
                    System.Console.WriteLine(Thread.CurrentThread.Name);
                    Console.WriteLine("Done");
                    done = true;
                } 
            }
           
        }
    }
}
