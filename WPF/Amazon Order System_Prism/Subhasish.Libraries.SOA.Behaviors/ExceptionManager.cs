using Subhasish.Libraries.SOA.Contracts.Fault;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.SOA.Behaviors
{
    public static class ExceptionManager
    {

        public static FaultException<ServiceError> Transform(this Exception exceptionObject,int errorId=default(int))
        {
            var faultException = new FaultException<ServiceError>(new ServiceError { ErrorId = errorId,
                Message = exceptionObject.Message, Source = exceptionObject.Source },
                new FaultReason(exceptionObject.Message)
            );

            return faultException;
        }

        public static void Log(this Exception exceptionObject)
        {
            var messageToLog = string.Format(@"{0}:{1}:{2}", DateTime.Now.ToString(), Environment.MachineName, exceptionObject.Message);
            EventLog.WriteEntry("Application", messageToLog, EventLogEntryType.Error);
        }


    }
}
