using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.Modularity;

using ModuleTracker;

namespace ModuleE
{
    [Module(ModuleName = WellKnownModuleNames.ModuleE)]
    public class ModuleE : IModule
    {
        private IModuleTracker moduleTracker;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModuleE"/> class.
        /// </summary>
        /// <param name="moduleTracker">The module tracker.</param>        
        public ModuleE(IModuleTracker moduleTracker)
        {
            if (moduleTracker == null)
            {
                throw new ArgumentNullException("moduleTracker");
            }

            this.moduleTracker = moduleTracker;
            this.moduleTracker.RecordModuleConstructed(WellKnownModuleNames.ModuleE);
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        public void Initialize()
        {
            this.moduleTracker.RecordModuleInitialized(WellKnownModuleNames.ModuleE);
        }
    }
}
