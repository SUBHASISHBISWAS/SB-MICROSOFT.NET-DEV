using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.Modularity;

using ModuleTracker;

namespace ModuleD
{
    [Module(ModuleName = WellKnownModuleNames.ModuleD)]
    public class ModuleD:IModule
    {
        private IModuleTracker moduleTracker;

        public ModuleD(IModuleTracker moduleTracker)
        {
            if (moduleTracker == null)
            {
                throw new ArgumentNullException("moduleTracker");
            }

            this.moduleTracker = moduleTracker;
            this.moduleTracker.RecordModuleConstructed(WellKnownModuleNames.ModuleD);
        }

        public void Initialize()
        {
            this.moduleTracker.RecordModuleInitialized(WellKnownModuleNames.ModuleD);
        }
    }
}
