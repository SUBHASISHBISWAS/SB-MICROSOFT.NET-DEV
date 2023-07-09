using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    class ExecutionContext1
    {
        //public static void Main()
        //{
        //    CallContext.LogicalSetData("Name", "Subhasish");
        //    ThreadPool.QueueUserWorkItem(state => Console.WriteLine("Before Supress"+CallContext.LogicalGetData("Name")));
        //    ExecutionContext.SuppressFlow();
        //    ThreadPool.QueueUserWorkItem(state => Console.WriteLine("After Supress"+CallContext.LogicalGetData("Name")));
        //    ExecutionContext.RestoreFlow();
        //    Thread.Sleep(1000);

        //}
    }
}
