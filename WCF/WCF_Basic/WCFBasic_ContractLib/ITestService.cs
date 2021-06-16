using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
namespace WCFBasic_ContractLib
{
    [ServiceContract]
    public interface ITestService
    {
        [OperationContract]
        String EchoOperation(String msg);
    }
}
