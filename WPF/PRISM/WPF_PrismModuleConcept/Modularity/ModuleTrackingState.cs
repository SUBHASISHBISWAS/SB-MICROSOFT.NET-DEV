using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.Modularity;

using Modularity.Annotations;

namespace Modularity
{

    public static class PropertyNames
    {
        public const string ModuleName = "ModuleName";
        public const string ModuleInitializationStatus = "ModuleInitializationStatus";
        public const string ExpectedDiscoveryMethod = "ExpectedDiscoveryMethod";
        public const string ExpectedInitializationMode = "ExpectedInitializationMode";
        public const string ExpectedDownloadTiming = "ExpectedDownloadTiming";
        public const string ConfiguredDependencies = "ConfiguredDependencies";
        public const string BytesReceived = "BytesReceived";
        public const string TotalBytesToReceive = "TotalBytesToReceive";
        public const string DownloadProgressPercentage = "DownloadProgressPercentage";
    }

    public class ModuleTrackingState:INotifyPropertyChanged
    {
        private string moduleName;
        private ModuleInitializationStatus moduleInitializationStatus;
        private DiscoveryMethod expectedDiscoveryMethod;
        private InitializationMode expectedInitializationMode;
        private DownloadTiming expectedDownloadTiming;
        private string configuredDependencies = "(none)";
        private long bytesReceived;
        private long totalBytesToReceived;

        
        
        
        public event PropertyChangedEventHandler PropertyChanged;

        public string ModuleName
        {
            get
            {
                return moduleName;
            }
            set
            {
                moduleName = value;
                RaisePropertyChanged( PropertyNames.ModuleName );
            }
        }

        public ModuleInitializationStatus ModuleInitializationStatus
        {
            get
            {
                return moduleInitializationStatus;
            }
            set
            {
                moduleInitializationStatus = value;
                RaisePropertyChanged( PropertyNames.ModuleInitializationStatus );
            }
        }

        public DiscoveryMethod ExpectedDiscoveryMethod
        {
            get
            {
                return expectedDiscoveryMethod;
            }
            set
            {
                if (expectedDiscoveryMethod != value)
                {
                    expectedDiscoveryMethod = value;
                    RaisePropertyChanged(PropertyNames.ExpectedDiscoveryMethod);
                }
            }
        }

        public InitializationMode ExpectedInitializationMode
        {
            get
            {
                return expectedInitializationMode;
            }
            set
            {
                if (expectedInitializationMode != value)
                {
                    expectedInitializationMode = value;
                    RaisePropertyChanged(PropertyNames.ExpectedInitializationMode);
                }
            }
        }

        public DownloadTiming ExpectedDownloadTiming
        {
            get
            {
                return expectedDownloadTiming;
            }
            set
            {
                if (expectedDownloadTiming != value)
                {
                    expectedDownloadTiming = value;
                    RaisePropertyChanged(PropertyNames.ExpectedDownloadTiming);
                }
            }
        }

        public string ConfiguredDependencies
        {
            get
            {
                return configuredDependencies;
            }
            set
            {

                if (configuredDependencies != value)
                {
                    configuredDependencies = value;
                    RaisePropertyChanged(PropertyNames.ConfiguredDependencies);
                }
            }
        }

        public long BytesReceived
        {
            get
            {
                return bytesReceived;
            }
            set
            {
                bytesReceived = value;
                RaisePropertyChanged( PropertyNames.BytesReceived );
                RaisePropertyChanged( PropertyNames.DownloadProgressPercentage );
            }
        }

        public long TotalBytesToReceived
        {
            get
            {
                return totalBytesToReceived;
            }
            set
            {
                totalBytesToReceived = value;
                RaisePropertyChanged( PropertyNames.TotalBytesToReceive );
                RaisePropertyChanged( PropertyNames.DownloadProgressPercentage );
            }
        }


        public int DownloadProgressPercentage
        {
            get
            {
                if( bytesReceived<totalBytesToReceived )
                {
                    return (int) (bytesReceived * 100 / totalBytesToReceived);
                }
                else
                {
                    return 100;
                }
            }
        }


        protected virtual void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if( handler != null )
            {
                handler( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }
    }
}
