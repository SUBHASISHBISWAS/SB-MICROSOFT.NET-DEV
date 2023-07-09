using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    internal static class StrangeBehavior
    {
        // As you'll see later, mark this field as volatile to fix the problem
        private static  volatile Boolean s_stopWorker = false;
        //public static void Main()
        //{
           
        //    Console.WriteLine("Main: letting worker run for 5 seconds");
        //    Thread t = new Thread(Worker);
        //    t.Start();
        //    Thread.Sleep(5000);
        //    s_stopWorker = true;
        //    Console.WriteLine("Main: waiting for worker to stop");
        //    t.Join();
        //}
        private static void Worker(Object o)
        {
            Int32 x = 0;
            while (!s_stopWorker) x++;
            Console.WriteLine("Worker: stopped when x={0}", x);
        }

       

    }



    internal sealed class ThreadsSharingData
    {
        private volatile Int32 m_flag = 0;
        private Int32 m_value = 0;
        // This method is executed by one thread
        public void Thread1()
        {
            // Note: 5 must be written to m_value before 1 is written to m_flag
            m_value = 5;
            m_flag = 1;
        }
        // This method is executed by another thread
        public void Thread2()
        {
            // Note: m_value must be read after m_flag is read
            if (m_flag == 1)
                Console.WriteLine(m_value);
        }
    }

}
