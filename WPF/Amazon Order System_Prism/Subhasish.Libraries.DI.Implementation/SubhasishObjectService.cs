using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Subhasish.Libraries.Common.DI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.DI.Implementation
{
    public class SubhasishObjectService : IObjectService
    {
        private IUnityContainer container = default(IUnityContainer);

        private SubhasishObjectService()
        {
            this.container = new UnityContainer().LoadConfiguration();
        }

        public object GetObject(Type serviceType)
        {
            return this.container.Resolve(serviceType);
        }

        public T GetObject<T>()
        {
            return this.container.Resolve<T>();
        }

        private static SubhasishObjectService subhasishObjectService = default(SubhasishObjectService);

        static SubhasishObjectService()
        {
            subhasishObjectService = new SubhasishObjectService();
        }

        public static IObjectService Current
        {
            get
            {
                return subhasishObjectService;
            }
        }
    }
}
