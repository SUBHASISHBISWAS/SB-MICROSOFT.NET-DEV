using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    class TwoWaySignalingWithAutoResetEvent
    {
        static EventWaitHandle ready = new EventWaitHandle(false, EventResetMode.AutoReset);
        static EventWaitHandle go = new EventWaitHandle(false, EventResetMode.AutoReset);
        private static object locker = new object();
        private static string message = string.Empty;
        //public static void Main()
        //{
        //    new Thread(Worker).Start();
        //    ready.WaitOne();
        //    lock (locker)
        //    {
        //        message = "Subhasish";
        //    }
        //    go.Set();

        //    ready.WaitOne();
        //    lock (locker)
        //    {
        //        message = "Biswas";
        //    }
        //    go.Set();

        //    ready.WaitOne();
        //    lock (locker)
        //    {
        //        message = null;
        //    }
        //    go.Set();
        //}

        public static void Worker()
        {
            while (true)
            {
                ready.Set();
                go.WaitOne();
                lock (locker)
                {
                    if (message==null)
                    {
                        return;
                    }
                    Console.WriteLine(message);
                }
            }
        }
    }
}
