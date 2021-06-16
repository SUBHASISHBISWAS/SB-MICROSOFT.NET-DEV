using Subhasish.Libraries.SOA.Contracts.Fault;
using Subhasish.Libraries.SOA.Contracts.Shared;
using Subhasish.Libraries.SOA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.SOA.Contracts.Services
{
    [ServiceContract(Name ="IOrderService",Namespace =NamespaceConstants.CONTRACTS)]
    public interface IOrderService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Orders?customerId={customeId}")]
        IEnumerable<Order> GetOrdersByCustomerId(int customerId);
    }
}
