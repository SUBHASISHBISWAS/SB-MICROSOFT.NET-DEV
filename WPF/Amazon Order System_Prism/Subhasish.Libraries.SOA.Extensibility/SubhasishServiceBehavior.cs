using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;

namespace Subhasish.Libraries.SOA.Extensibility
{
    public class SubhasishServiceBehavior : IServiceBehavior
    {
        private Type serviceType = default(Type);

        public SubhasishServiceBehavior(Type serviceType)
        {
            this.serviceType = serviceType;
        }

        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            var subhasishInstanceProvider = new SubhasishInstanceProvider(serviceType);
            var channelDispatchers = serviceHostBase.ChannelDispatchers;

            foreach (ChannelDispatcher dispatcher in channelDispatchers)
            {
                var endpoints = dispatcher.Endpoints;

                foreach (var endpoint in endpoints)
                {
                    endpoint.DispatchRuntime.InstanceProvider = subhasishInstanceProvider;
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            
        }
    }
}
