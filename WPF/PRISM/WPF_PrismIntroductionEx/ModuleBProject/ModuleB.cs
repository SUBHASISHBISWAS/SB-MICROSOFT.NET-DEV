using InterfacesProject;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleBProject
{
    class ModuleB:IModule
    {
        IUnityContainer container;
        public ModuleB(IUnityContainer container)
        {
            this.container = container;
        }
        public void Initialize()
        {
            container.RegisterType<IUIService, UIService>();
        }
    }
}
