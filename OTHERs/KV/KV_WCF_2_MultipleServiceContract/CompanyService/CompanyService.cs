using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyService
{
    public class CompanyService : ICompanyPrivateService, ICompanyPublicService
    {
        public string GetPrivateInformation()
        {
            return "Private Information";
        }

        public string GetPublicOpertaion()
        {
            return "Public  Information";
        }
    }
}
