using Subhasish.Libraries.SOA.Contracts.Data;
using Subhasish.Libraries.SOA.Contracts.Faults;
using Subhasish.Libraries.SOA.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.SOA.Contracts.Services
{
    [ServiceContract(
        Name = "IOrderService",
        Namespace = NamespaceConstants.CONTRACTS)]
    public interface IOrderService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(
            UriTemplate = "Orders?customerId={customerId}")]
        IEnumerable<Order> GetOrdersByCustomerId(int customerId);
    }
}
