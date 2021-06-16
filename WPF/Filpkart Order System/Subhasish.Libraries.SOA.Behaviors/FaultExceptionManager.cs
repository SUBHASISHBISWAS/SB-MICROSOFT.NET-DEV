using Subhasish.Libraries.SOA.Contracts.Faults;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.SOA.Behaviors
{
    public static class FaultExceptionManager
    {
        public static FaultException<ServiceError> To(this Exception exceptionObject,int errorId=default(int))
        {
            return new FaultException<ServiceError>(new ServiceError { ErrorId = errorId, Message = exceptionObject.Message, Source = exceptionObject.Source }, 
                new FaultReason(exceptionObject.Message));
        }

        public static void Log(this Exception exceptionObject)
        {
            var messageToLog = string.Format(@"{0} : {1} : {2}",
                DateTime.Now.ToString(), Environment.MachineName, exceptionObject.Message);

            EventLog.WriteEntry("Application", messageToLog, EventLogEntryType.Error);
        }
    }
}
