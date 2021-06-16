using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Subhasish.Libraries.UI.Shells;

namespace Subhasish.Libraries.UI.Bootstrappers
{
    public class OrderSystemBootstrapper: UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            var shell = Container.Resolve<OrderSystemDashboardShell>();

            if (shell!=default(Window))
            {
                shell.Show();
            }

            return shell;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override IUnityContainer CreateContainer()
        {
            var container = new UnityContainer().LoadConfiguration();
            return container;
        }
    }
}
