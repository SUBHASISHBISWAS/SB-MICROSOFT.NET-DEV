using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

using PrismApplication.Infrastructure;

namespace ModuleA
{
    public class ModuleAModule:IModule
    {
        private IUnityContainer container;
        private IRegionManager regionManager ;
        public ModuleAModule(IUnityContainer container,IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }
        public void Initialize()
        {
            container.RegisterType<Views.ToolbarA>();
            container.RegisterType<Views.ContentView>();
            container.RegisterType<ViewModel.IContentAViewModel, ViewModel.ContentAViewModel>();

            regionManager.RegisterViewWithRegion( RegionNames.ToolBarRegion, typeof( Views.ToolbarA ) );
            regionManager.RegisterViewWithRegion( RegionNames.ContentRegion, typeof( Views.ContentView ) );
        }
    }
}
