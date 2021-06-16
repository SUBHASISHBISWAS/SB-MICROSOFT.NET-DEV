using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.SOA.Extensibility
{
    public class SubhasishServiceHostFactory:ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var subhasishServiceHost = new SubhasishServiceHost(serviceType, baseAddresses);
            return subhasishServiceHost;
        }
    }
}
