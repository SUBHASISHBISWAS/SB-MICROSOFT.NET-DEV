using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SampleSevice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISampleService" in both code and config file together.
    [ServiceContract]
    public interface ISampleService
    {
        [OperationContract(IsOneWay =false)]
        string RequestReplyOperation();

        [OperationContract]
        string RequestReplyOperation_ThrowsException();

        [OperationContract(IsOneWay =true)]
        void OneWayOperation();

        [OperationContract(IsOneWay = true)]
        void OneWayOperation_ThrowsException();


    }
}
