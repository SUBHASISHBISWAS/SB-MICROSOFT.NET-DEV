using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.SOA.Extensibility
{
    public class SubhasishServiceHost:ServiceHost
    {
        public SubhasishServiceHost(Type serviceType,params Uri[] baseAddresses):base(serviceType,baseAddresses)
        {
            var subhasishServiceBehvior = new SubhasishServiceBehavior(serviceType);
            Description.Behaviors.Add(subhasishServiceBehvior);
        }
    }
}
