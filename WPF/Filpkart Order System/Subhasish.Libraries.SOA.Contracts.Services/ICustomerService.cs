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
        Name = "ICustomerService",
        Namespace = NamespaceConstants.CONTRACTS)]
    public interface ICustomerService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate ="All",RequestFormat = WebMessageFormat.Json)]
        IEnumerable<Customer> GetAllCustomers();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(
            UriTemplate = "Search/{customerName}",
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Customer> GetCustomersByName(string customerName);

        [FaultContract(typeof(ServiceError))]
        [WebGet(
            UriTemplate = "Details?customerId={customerId}",
            ResponseFormat = WebMessageFormat.Json)]
        Customer GetCustomerDetails(int customerId);
    }
}
