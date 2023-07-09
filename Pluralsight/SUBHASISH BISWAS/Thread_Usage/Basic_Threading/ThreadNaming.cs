using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    class ThreadNaming
    {
        //public static void Main()
        //{
        //    Thread.CurrentThread.Name = "main";
        //    Thread worker = new Thread(Go);
        //    worker.Name = "worker";
        //    worker.Start();
        //    Go();
        //}
        static void Go()
        {
            Console.WriteLine("Hello From :{0}",Thread.CurrentThread.Name);
        }
    }
}
