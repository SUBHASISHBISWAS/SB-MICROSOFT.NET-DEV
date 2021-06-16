using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Subhasish.Libraries.UI.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.UI.Utilities.Impl
{
    public class ContainerManager : IContainerManager
    {
        private IUnityContainer container = default(IUnityContainer);

        public ContainerManager()
        {
            this.container = new UnityContainer().LoadConfiguration();
        }

        public object GetInstance(Type serviceType)
        {
            return this.container.Resolve(serviceType);
        }

        public object GetInstance(Type serviceType, string serviceName)
        {
            return this.container.Resolve(serviceType, serviceName);
        }

        public T GetInstance<T>()
        {
            return this.container.Resolve<T>();
        }

        public T GetInstance<T>(string serviceName)
        {
            return this.container.Resolve<T>(serviceName);
        }

        private static ContainerManager containerManager = default(ContainerManager);

        static ContainerManager() { containerManager = new ContainerManager(); }

        public static ContainerManager Current
        {
            get { return containerManager; }
        }
    }
}
