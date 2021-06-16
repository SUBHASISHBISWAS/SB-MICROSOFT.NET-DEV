using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Unity;
using WPFBasic_FirstPrismEx;

namespace CalculatorLibrary
{
    public class CalculatorModule:IModule
    {
        private IUnityContainer container;
        public CalculatorModule(IUnityContainer container)
        {
            this.container = container;
        }

        public void Initialize()
        {
            container.RegisterType<ICalculator, Calculator>();
            container.RegisterType<ICalculatorReplLoop, CalculatorReplLoop>();
        }
    }
}
