using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CompanyService
{
    [ServiceContract(Name = "ICompanyPublicService")]
    public interface ICompanyPublicService
    {
        [OperationContract]
        string GetPublicOpertaion();
    }

    [ServiceContract(Name = "ICompanyPrivateService")]
    public interface ICompanyPrivateService
    {
        [OperationContract]
        string GetPrivateInformation();
    }
}
