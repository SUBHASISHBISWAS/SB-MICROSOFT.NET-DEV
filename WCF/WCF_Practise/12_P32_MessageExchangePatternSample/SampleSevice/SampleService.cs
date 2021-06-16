using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace SampleSevice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SampleService" in both code and config file together.
    public class SampleService : ISampleService
    {
        public void OneWayOperation()
        {
            Thread.Sleep(2000);
            return;
        }

        public void OneWayOperation_ThrowsException()
        {
            throw new NotImplementedException();
        }

        public string RequestReplyOperation()
        {
            DateTime dtStart = DateTime.Now;
            Thread.Sleep(2000);
            DateTime dtEnd = DateTime.Now;

            return dtEnd.Subtract(dtStart).Seconds.ToString() + " seconds Processing Time";
        }

        public string RequestReplyOperation_ThrowsException()
        {
            throw new NotImplementedException();
        }
    }
}
