using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SimpleService" in both code and config file together.
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.Single)]
    public class SimpleService : ISimpleService
    {
        private int number;

        public int IncrementNumber()
        {
            Console.WriteLine("Session ID: {0}",OperationContext.Current.SessionId);
            number = number + 1;
            return number;
        }
    }
}
