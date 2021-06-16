using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using ModuleTracker;
using ModuleA;
namespace Modularity
{
    public class Bootstrapper:UnityBootstrapper
    {
        private readonly CallBackLogger callBackLogger=new CallBackLogger();

        protected override System.Windows.DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override ILoggerFacade CreateLogger()
        {
            return callBackLogger;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            this.RegisterTypeIfMissing( typeof(IModuleTracker),typeof(ModuleTracker),true );
            this.Container.RegisterInstance<CallBackLogger>(this.callBackLogger);
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new AggregateModuleCatalog();
        }

        protected override void ConfigureModuleCatalog()
        {
            Type moduleAType = typeof(ModuleA.ModuleA);
            ModuleCatalog.AddModule(new ModuleInfo(moduleAType.Name,moduleAType.AssemblyQualifiedName));

            Type moduleCType = typeof( ModuleC.ModuleC );
            ModuleCatalog.AddModule( new ModuleInfo()
            {
                    ModuleName = moduleCType.Name,
                    ModuleType = moduleCType.AssemblyQualifiedName,
                    InitializationMode = InitializationMode.OnDemand
            });

            DirectoryModuleCatalog directoryCatalog=new DirectoryModuleCatalog(){ModulePath = @".\DirectoryModules"};
            ((AggregateModuleCatalog)ModuleCatalog).AddCatalog( directoryCatalog );

            ConfigurationModuleCatalog configurationCatalog = new ConfigurationModuleCatalog();
            ((AggregateModuleCatalog)ModuleCatalog).AddCatalog( configurationCatalog );
        }
    }
}
