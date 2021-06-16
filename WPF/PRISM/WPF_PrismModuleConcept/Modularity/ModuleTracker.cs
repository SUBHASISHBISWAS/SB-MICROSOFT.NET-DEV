using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.Logging;
using Microsoft.Practices.Prism.Modularity;

using Modularity.Properties;

using ModuleTracker;

namespace Modularity
{
    public class ModuleTracker:IModuleTracker
    {
        private readonly ModuleTrackingState moduleATrackingState;
        private readonly ModuleTrackingState moduleBTrackingState;
        private readonly ModuleTrackingState moduleCTrackingState;
        private readonly ModuleTrackingState moduleDTrackingState;
        private readonly ModuleTrackingState moduleETrackingState;
        private readonly ModuleTrackingState moduleFTrackingState;

        private ILoggerFacade logger;

        public ModuleTracker(ILoggerFacade logger)
        {
            if( logger==null )
            {
                throw new ArgumentNullException("logger");
            }
            this.logger = logger;

            moduleATrackingState=new ModuleTrackingState
            {
                    ModuleName = WellKnownModuleNames.ModuleA,
                    ExpectedDiscoveryMethod = DiscoveryMethod.ApplicationReference,
                    ExpectedInitializationMode = InitializationMode.WhenAvailable,
                    ExpectedDownloadTiming =DownloadTiming.WithApplication,
                    ConfiguredDependencies = WellKnownModuleNames.ModuleD
            };
            moduleBTrackingState = new ModuleTrackingState
            {
                ModuleName = WellKnownModuleNames.ModuleB,
                ExpectedDiscoveryMethod = DiscoveryMethod.DirectorySweep,
                ExpectedInitializationMode = InitializationMode.OnDemand,
                ExpectedDownloadTiming = DownloadTiming.InBackground,
            };
            moduleCTrackingState = new ModuleTrackingState
            {
                ModuleName = WellKnownModuleNames.ModuleC,
                ExpectedDiscoveryMethod = DiscoveryMethod.ApplicationReference,
                ExpectedInitializationMode = InitializationMode.OnDemand,
                ExpectedDownloadTiming = DownloadTiming.WithApplication,
            };
            moduleDTrackingState = new ModuleTrackingState
            {
                ModuleName = WellKnownModuleNames.ModuleD,
                ExpectedDiscoveryMethod = DiscoveryMethod.DirectorySweep,
                ExpectedInitializationMode = InitializationMode.WhenAvailable,
                ExpectedDownloadTiming = DownloadTiming.InBackground,
            };
            moduleETrackingState = new ModuleTrackingState
            {
                ModuleName = WellKnownModuleNames.ModuleE,
                ExpectedDiscoveryMethod = DiscoveryMethod.ConfigurationManifest,
                ExpectedInitializationMode = InitializationMode.OnDemand,
                ExpectedDownloadTiming = DownloadTiming.InBackground,
            };
            moduleFTrackingState = new ModuleTrackingState
            {
                ModuleName = WellKnownModuleNames.ModuleF,
                ExpectedDiscoveryMethod = DiscoveryMethod.ConfigurationManifest,
                ExpectedInitializationMode = InitializationMode.OnDemand,
                ExpectedDownloadTiming = DownloadTiming.InBackground,
                ConfiguredDependencies = WellKnownModuleNames.ModuleE,
            };
        }

        public ModuleTrackingState ModuleATrackingState
        {
            get
            {
                return moduleATrackingState;
            }
        }

        public ModuleTrackingState ModuleBTrackingState
        {
            get
            {
                return moduleBTrackingState;
            }
        }

        public ModuleTrackingState ModuleCTrackingState
        {
            get
            {
                return moduleCTrackingState;
            }
        }

        public ModuleTrackingState ModuleDTrackingState
        {
            get
            {
                return moduleDTrackingState;
            }
        }

        public ModuleTrackingState ModuleETrackingState
        {
            get
            {
                return moduleETrackingState;
            }
        }

        public ModuleTrackingState ModuleFTrackingState
        {
            get
            {
                return moduleFTrackingState;
            }
        }

        private ModuleTrackingState GetModuleTrackingState( string moduleName )
        {
            switch( moduleName )
            {
                case WellKnownModuleNames.ModuleA:
                    return this.ModuleATrackingState;
                case WellKnownModuleNames.ModuleB:
                    return this.ModuleBTrackingState;
                case WellKnownModuleNames.ModuleC:
                    return this.ModuleCTrackingState;
                case WellKnownModuleNames.ModuleD:
                    return this.ModuleDTrackingState;
                case WellKnownModuleNames.ModuleE:
                    return this.ModuleETrackingState;
                case WellKnownModuleNames.ModuleF:
                    return this.ModuleFTrackingState;
                default:
                    return null;  
            }
        }

        public void RecordModuleDownloading(string moduleName, long byteReceived, long totalByteReceived)
        {
            ModuleTrackingState moduleTrackingState = GetModuleTrackingState( moduleName );
            if( moduleTrackingState!=null )
            {
                moduleTrackingState.BytesReceived = byteReceived;
                moduleTrackingState.TotalBytesToReceived = totalByteReceived;
                if( byteReceived<totalByteReceived )
                {
                    moduleTrackingState.ModuleInitializationStatus=ModuleInitializationStatus.Downloading;
                }
                else
                {
                    moduleTrackingState.ModuleInitializationStatus=ModuleInitializationStatus.Downloaded;
                }
            }
        }

        public void RecordModuleLoaded(string moduleName)
        {
            ModuleTrackingState moduleTrackingState = this.GetModuleTrackingState(moduleName);
            if (moduleTrackingState != null)
            {
                moduleTrackingState.ModuleInitializationStatus = ModuleInitializationStatus.Initialized;
            }
           logger.Log(string.Format(CultureInfo.CurrentCulture, Resources.ModuleIsInitialized, moduleName), Category.Debug, Priority.Low);
        }

        public void RecordModuleConstructed(string moduleName)
        {
            ModuleTrackingState moduleTrackingState = GetModuleTrackingState(moduleName);
            if( moduleTrackingState!=null )
            {
                moduleTrackingState.ModuleInitializationStatus=ModuleInitializationStatus.Constracted;
            }

            logger.Log( string.Format( CultureInfo.CurrentCulture,Resources.ModuleConstraced,moduleName ),Category.Debug, Priority.Low );
        }

        public void RecordModuleInitialized(string moduleName)
        {
            logger.Log(string.Format(CultureInfo.CurrentCulture,Resources.ModuleLoaded,moduleName),Category.Debug, Priority.Low);
        }
    }
}
