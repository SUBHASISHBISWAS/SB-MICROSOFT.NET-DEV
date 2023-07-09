using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Basic_Threading
{

    public class ProduceConsumerQueue:IDisposable
    {
        EventWaitHandle wh = new AutoResetEvent(false);
        Thread worker;
        readonly object locker = new object();
        Queue<string> taskQueue = new Queue<string>();

        public ProduceConsumerQueue()
        {
            worker = new Thread(Work);
            worker.Start();
        }


        public void EnqueTask(string aTask)
        {
            lock (locker)
            {
                taskQueue.Enqueue(aTask);
               
            }
            wh.Set();
        }

        public void Dispose()
        {
            
 
            EnqueTask(null);// Signal the consumer to exit.
            worker.Join();// Wait for the consumer's thread to finish.
            wh.Close();// Release any OS resources.
        }
        void Work()
        {
            while (true)
            {
                string aTask = null;
                lock (locker)
                {
                    if (taskQueue.Count() > 0)
                    {
                        aTask = taskQueue.Dequeue();
                        if (aTask == null)
                        {
                            return;
                        }
                    }
                }
                    if (aTask!=null)
                    {
                        Console.WriteLine("Performing Task.."+aTask);
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        wh.WaitOne(); // No more tasks - wait for a signal
                    }
                
            }
        }
    }
    class ProduceConsumerQueueWithAutoResetEvent
    {
        //public static void Main()
        //{
        //    using (ProduceConsumerQueue q=new ProduceConsumerQueue())
        //    {
                
        //        q.EnqueTask("Hello");
                
        //        for (int i = 0; i < 10; i++)
        //        {
        //            q.EnqueTask("Say " + i);
                   
        //        }
        //        q.EnqueTask("Good Buy");
        //    }
        //}
    }
}
