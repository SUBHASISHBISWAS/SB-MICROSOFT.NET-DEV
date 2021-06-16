using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace WPFBasic_FirstPrismEx
{


    class CalculatorBootStrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return (null);

        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return (new ConfigurationModuleCatalog());
        }
       
    }
    class Program
    {
        static void Main(string[] args)
        {



            CalculatorBootStrapper bootstrapper = new CalculatorBootStrapper();
            bootstrapper.Run();

            //UnityContainer container=new UnityContainer();

            ////container.RegisterType<ICalculator, Calculator>();
            ////container.RegisterType<IInputService, ConsoleInputService>();
            ////container.RegisterType<IOutputService, ConsoleOutputService>();
            ////container.RegisterType<IInputPerserService, InputPerserService>();
            ////container.RegisterType<ICalculatorReplLoop, CalculatorReplLoop>();

            ////UnityConfigurationSection configSection =
            ////    (UnityConfigurationSection) ConfigurationManager.GetSection("unity");
            ////configSection.Configure(container);
            
            ////ICalculatorReplLoop loop = container.Resolve<ICalculatorReplLoop>();
            ////loop.Run();


            //container.RegisterInstance<IServiceLocator>(new UnityServiceLocatorAdapter(container));
            
            //var catalog=new ConfigurationModuleCatalog();
            //container.RegisterInstance<IModuleCatalog>(catalog);

            //var logger=new TextLogger();
            //container.RegisterInstance<ILoggerFacade>(logger);

            //container.RegisterType<IModuleInitializer, ModuleInitializer>();

            //container.RegisterType<IModuleManager, ModuleManager>();

            //IModuleManager manager = container.Resolve<IModuleManager>();
            //manager.Run();

        }

        

       
    }
}
