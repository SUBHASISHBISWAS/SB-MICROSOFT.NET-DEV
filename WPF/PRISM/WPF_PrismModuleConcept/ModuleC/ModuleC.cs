using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.Modularity;

using ModuleTracker;

namespace ModuleC
{
    public class ModuleC:IModule
    {
        private IModuleTracker moduleTracker;

        public ModuleC(IModuleTracker moduleTracker)
        {
            if (moduleTracker == null)
            {
                throw new ArgumentNullException("moduleTracker");
            }

            this.moduleTracker = moduleTracker;
            moduleTracker.RecordModuleConstructed(WellKnownModuleNames.ModuleC);
        }
        public void Initialize()
        {
            moduleTracker.RecordModuleInitialized( WellKnownModuleNames.ModuleC );
        }
    }
}
