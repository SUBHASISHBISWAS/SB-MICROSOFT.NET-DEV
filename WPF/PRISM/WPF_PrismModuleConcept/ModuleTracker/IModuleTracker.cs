using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleTracker
{
    public interface IModuleTracker
    {
        void RecordModuleDownloading( string moduleName, long byteReceived, long totalByteReceived );

        void RecordModuleLoaded(string moduleName);

        void RecordModuleConstructed(string moduleName);

        void RecordModuleInitialized( string moduleName );
    }
}
