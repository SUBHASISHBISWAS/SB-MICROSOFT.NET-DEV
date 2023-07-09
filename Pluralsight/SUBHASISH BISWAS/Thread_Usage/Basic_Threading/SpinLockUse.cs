using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Basic_Threading
{

    public class SimpleSpinLock
    {
        // 0=false (default), 1=true
        private Int32 m_ResourceInUse;

        public void Enter()
        {
            // Set the resource to in-use and if this thread
            // changed it from Free, then return
            while (Interlocked.Exchange(ref m_ResourceInUse,1)!=0)
            {
                
            }
        }

        public void Leave()
        {
            // Mark the resource as Free
            Thread.VolatileWrite(ref m_ResourceInUse, 0);
        }
    }
 class SpinLockUse
    {
        private SimpleSpinLock m_sl = new SimpleSpinLock();

        public void AccessResource()
        {
            m_sl.Enter();

            m_sl.Leave();
        }
    }   

    

}
