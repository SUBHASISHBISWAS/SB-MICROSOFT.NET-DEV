using Microsoft.Practices.Prism.UnityExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_PrismIntroductionEx
{
    class MyBootStrapper:UnityBootstrapper
    {
        protected override System.Windows.DependencyObject CreateShell()
        {
            return (null);
        }

        protected override Microsoft.Practices.Prism.Modularity.IModuleCatalog CreateModuleCatalog()
        {
            return Microsoft.Practices.Prism.Modularity.ModuleCatalog.CreateFromXaml(new Uri("modulecatalog.xaml", UriKind.Relative));
        }
    }
}
