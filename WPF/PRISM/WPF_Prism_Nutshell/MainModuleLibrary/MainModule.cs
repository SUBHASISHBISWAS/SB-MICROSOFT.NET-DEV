using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using WPFBasic_FirstPrismEx;

namespace MainModuleLibrary
{
    public class MainModule:IModule
    {
        public MainModule(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        } 

        public void Initialize()
        {
            ICalculatorReplLoop loop = serviceLocator.GetInstance<ICalculatorReplLoop>();
            loop.Run();
        }

        private IServiceLocator serviceLocator;
    }
}
