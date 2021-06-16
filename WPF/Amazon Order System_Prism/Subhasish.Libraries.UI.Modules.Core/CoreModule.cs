using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using Subhasish.Libraries.UI.Modules.Core.Views;
using Subhasish.Libraries.UI.Modules.Core.Widgets;
using Subhasish.Libraries.UI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.UI.Modules.Core
{
    public class CoreModule : IModule
    {
        private IUnityContainer container = default(IUnityContainer);
        private IRegionManager regionManager = default(IRegionManager);

        public CoreModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }
        public void Initialize()
        {
            if (container != default(IUnityContainer) && this.regionManager != default(IRegionManager))
            {
                var headerView = this.container.Resolve<HeaderWidget>();
                var navigationView = this.container.Resolve<NavigationWidget>();
                var menuView = this.container.Resolve<MenuWidget>();

                var homeView = this.container.Resolve<HomeView>();
                var settingsView = this.container.Resolve<SettingsView>();
                var helpView = this.container.Resolve<HelpView>();

                this.container.RegisterInstance<object>("HomeView", homeView);
                this.container.RegisterInstance<object>("SettingsView", settingsView);
                this.container.RegisterInstance<object>("HelpView", helpView);

                this.regionManager.AddToRegion(RegionConstants.HEADER_REGION, headerView);
                this.regionManager.AddToRegion(RegionConstants.MENU_REGION, menuView);
                this.regionManager.AddToRegion(RegionConstants.NAVIGATION_REGION, navigationView);
                this.regionManager.AddToRegion(RegionConstants.CONTENT_REGION, homeView);
            }
        }
    }
}
