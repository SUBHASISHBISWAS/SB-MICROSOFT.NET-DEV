using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;

using ModuleTracker;

namespace ModuleA
{
    public class ModuleA:IModule
    {
        private ILoggerFacade logger;
        private IModuleTracker moduleTracker;

        public ModuleA(ILoggerFacade logger,IModuleTracker moduleTracker)
        {
            if( logger==null )
            {
                throw new ArgumentNullException("logger");
            }
            if( moduleTracker==null )
            {
                throw new ArgumentNullException("moduleTracker");
            }

            this.logger = logger;
            this.moduleTracker = moduleTracker;
            moduleTracker.RecordModuleConstructed(WellKnownModuleNames.ModuleA);
        }
        public void Initialize()
        {
            logger.Log("ModuleA demonstrates logging during Initialize().", Category.Info, Priority.Medium);
            moduleTracker.RecordModuleInitialized( WellKnownModuleNames.ModuleA );
        }
    }
}
