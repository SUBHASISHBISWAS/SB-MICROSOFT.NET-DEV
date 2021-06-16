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
       Name = "IOrderSystemService",
       Namespace = NamespaceConstants.CONTRACTS)]
    public interface IOrderSystemService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(
            UriTemplate = "All",
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Customer> GetAllCustomers();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(
            UriTemplate = "Search/{customerName}",
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Customer> GetCustomersByName(string customerName);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(
            UriTemplate = "Details?customerId={customerId}",
            ResponseFormat = WebMessageFormat.Json)]
        Customer GetCustomerDetails(int customerId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(
            UriTemplate = "Orders?customerId={customerId}",
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Order> GetOrdersByCustomerId(int customerId);
    }
}
