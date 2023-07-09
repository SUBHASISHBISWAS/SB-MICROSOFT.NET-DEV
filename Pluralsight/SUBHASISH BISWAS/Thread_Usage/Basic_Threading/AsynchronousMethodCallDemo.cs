using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    public class AsynchronousMethodCallDemo
    {
        public delegate string AsynMethodCaller(int callDuration, out int ThreadID);
        public string TestMethod(int callDuration,out int ThreadID)
        {
            Console.WriteLine("Test Method begins");
            Thread.Sleep(callDuration);
            ThreadID = Thread.CurrentThread.ManagedThreadId;
            return string.Format("My call time was:{0}", callDuration);
        }
    }

    public class Program
    {
        //public static void Main()
        //{
        //    int ThreadID;
        //    AsynchronousMethodCallDemo ad = new AsynchronousMethodCallDemo();
        //    AsynchronousMethodCallDemo.AsynMethodCaller caller = new AsynchronousMethodCallDemo.AsynMethodCaller(ad.TestMethod);
        //    IAsyncResult result = caller.BeginInvoke(3000, out ThreadID, new AsyncCallback(CallBack), "The call Executed on Thread {0},with return value {1}");
        //    Thread.Sleep(0);
        //    //result.AsyncWaitHandle.WaitOne();
        //    Console.WriteLine("Main Thread :{0} doing some work",Thread.CurrentThread.ManagedThreadId);
        //    while (result.IsCompleted==false)
        //    {
        //        Thread.Sleep(100);
        //        Console.WriteLine(".");
        //    }
        //    //string returnValue = caller.EndInvoke(out ThreadID, result);
        //    //Console.WriteLine("The call executed on thread:{0} with return value:{1}", ThreadID, returnValue);
           
        //}

        static void CallBack(IAsyncResult result)
        {
            Console.WriteLine("Call Back Called");

            AsyncResult ar = (AsyncResult)result;
            AsynchronousMethodCallDemo.AsynMethodCaller caller = ( AsynchronousMethodCallDemo.AsynMethodCaller) ar.AsyncDelegate;
            String formatString = (string)ar.AsyncState;
            int threadid;
            string returnValue = caller.EndInvoke(out threadid, result);
            Console.WriteLine(formatString , threadid , returnValue);
            
        }
    }
}
