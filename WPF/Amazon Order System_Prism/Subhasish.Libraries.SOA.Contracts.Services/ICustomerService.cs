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
    [ServiceContract(Name ="ICustomerService",Namespace =NamespaceConstants.CONTRACTS)]
    public interface ICustomerService
    {
        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate ="All",ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Customer> GetAllCustomers();

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Search/{customerName}", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<Customer> GetCustomerByName(string customerName);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebGet(UriTemplate = "Details?customerId={customerId}", ResponseFormat = WebMessageFormat.Json)]
        Customer GetCustomerDetails(int customerId);

        [OperationContract]
        [FaultContract(typeof(ServiceError))]
        [WebInvoke(UriTemplate = "Save", RequestFormat = WebMessageFormat.Json)]
        bool AddNewCustomer(Customer customer);

    }
}
