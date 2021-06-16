using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.Modularity;

using ModuleTracker;

namespace ModuleB
{
    [Module(ModuleName = WellKnownModuleNames.ModuleB,OnDemand = true)]
    public class ModuleB:IModule
    {
        private IModuleTracker moduleTracker;

        public ModuleB(IModuleTracker moduleTracker)
        {
            if (moduleTracker == null)
            {
                throw new ArgumentNullException("moduleTracker");
            }
            this.moduleTracker = moduleTracker;
            moduleTracker.RecordModuleConstructed(WellKnownModuleNames.ModuleB);
        }
        public void Initialize()
        {
            moduleTracker.RecordModuleInitialized( WellKnownModuleNames.ModuleB );
        }
    }
}
