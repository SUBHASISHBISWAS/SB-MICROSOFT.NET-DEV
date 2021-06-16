using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modularity
{
    public enum ModuleInitializationStatus
    {
        NotStarted,
        Downloading,
        Downloaded,
        Constracted,
        Initialized
    }
}
