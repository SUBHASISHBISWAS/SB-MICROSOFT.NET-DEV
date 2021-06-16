using Subhasish.Libraries.SOA.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.SOA.Contracts.Services
{

    [ServiceContract(Name="IOrderSystemService",Namespace =NamespaceConstants.CONTRACTS)]
    public interface IOrderSystemService:ICustomerService,IOrderService
    {
    }
}
