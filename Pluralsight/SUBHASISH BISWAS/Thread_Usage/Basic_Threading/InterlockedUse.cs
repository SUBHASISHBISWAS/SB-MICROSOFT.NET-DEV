using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    class InterlockedUse
    {
        private static int usingResource = 0;
        private const int numThreadIteration = 5;
        private const int numThread = 10;

        //public static void Main()
        //{
        //    Thread myThread;
        //    Random rnd = new Random();
        //    for (int i = 0; i < numThread; i++)
        //    {
        //        myThread = new Thread(MyThreadProc);
        //        myThread.Name = string.Format("Thread {0}", i + 1);
        //        Thread.Sleep(rnd.Next(0, 1000));
        //        myThread.Start();
        //    }
        //}

        private static void MyThreadProc()
        {
            UseResource();
            Thread.Sleep(1000);
        }

        static bool UseResource()
        {
            if (0==Interlocked.Exchange(ref usingResource,1))
            {
                Console.WriteLine("{0} acquire the lock",Thread.CurrentThread.Name);
                Thread.Sleep(500);
                Console.WriteLine("{0} exiting lock",Thread.CurrentThread.Name);
                Interlocked.Exchange(ref usingResource, 0);
                return true;
            }
            else
            {
                Console.WriteLine("{0} was denied lock",Thread.CurrentThread.Name);
                return false;
            }
        }
    }

    
}
