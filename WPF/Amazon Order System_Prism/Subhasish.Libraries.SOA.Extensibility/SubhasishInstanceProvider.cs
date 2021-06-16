using Subhasish.Libraries.Common.DI.Interfaces;
using Subhasish.Libraries.Common.DI.ServiceProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.SOA.Extensibility
{
    public class SubhasishInstanceProvider : IInstanceProvider
    {
        private Type serviceType = default(Type);
        private IObjectService objectService = default(IObjectService);

        public SubhasishInstanceProvider(Type serviceType)
        {
            this.serviceType = serviceType;
            this.objectService = ObjectServiceProvider.GetObjectService();
        }
        public object GetInstance(InstanceContext instanceContext)
        {
            return GetInstance(instanceContext);
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            var instance = default(object);
            try
            {
                instance = this.objectService.GetObject(serviceType);
            }
            catch
            {

            }

            return instance;
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            instance = default(object);
        }
    }
}
