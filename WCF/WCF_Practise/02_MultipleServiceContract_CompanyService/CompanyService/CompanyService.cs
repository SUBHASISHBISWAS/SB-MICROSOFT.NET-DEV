using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CompanyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CompanyService" in both code and config file together.
    public class CompanyService : ICompanyPublicService, ICompanyCofidentialService
    {
        public string GetConfidentialInformation()
        {
            return "public information available over Http";
        }

        public string GetPublicInformation()
        {
            return "confidential  information available over tcp";
        }
    }
}
