using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Basic_Threading
{
    class OneInstanceKernelObjectSemaphore
    {
        //public static void Main()
        //{
        //    bool createNew;

        //    using (new Semaphore(0, 1, "SomeUniqueStringIdentifyingMyApp", out createNew))
        //    {
        //        if (createNew)
        //        {
        //            Console.WriteLine(" // This thread created the kernel object so no other instance of this //application must be running. Run the rest of the application here");
        //            Console.ReadLine();
        //        }
        //        else
        //        {
        //            // This thread opened an existing kernel object with the same string name;
        //            // another instance of this application must be running now.
        //            // There is nothing to do in here, let's just return from Main to terminate
        //            // this second instance of the application.

        //            Console.WriteLine("Terminated");
                    

        //        }
        //    }
        //}
    }

    //public class EventWaitHandle : WaitHandle
    //{
    //    public Boolean Set();    // Sets Boolean to true; always returns true
    //    public Boolean Reset();  // Sets Boolean to false; always returns true
    //}
    //public sealed class AutoResetEvent : EventWaitHandle
    //{
    //    public AutoResetEvent(Boolean initialState);
    //}
    //public sealed class ManualResetEvent : EventWaitHandle
    //{
    //    public ManualResetEvent(Boolean initialState);
    //}

    //internal sealed class SimpleWaitLock : IDisposable
    //{
    //    private AutoResetEvent m_ResourceFree = new AutoResetEvent(true); // Initially free
    //    public void Enter()
    //    {
    //        // Block efficiently in the kernel for the resource to be free, then return
    //        m_ResourceFree.WaitOne();
    //    }
    //    public void Leave()
    //    {
    //        m_ResourceFree.Set();// Mark the resource as Free
    //    }
    //    public void Dispose() { m_ResourceFree.Dispose(); }
    //}

}
