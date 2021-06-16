using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Microsoft.Practices.Prism.Modularity;

namespace Modularity
{
    public class AggregateModuleCatalog:IModuleCatalog
    {

        private List<IModuleCatalog> catalogs=new List<IModuleCatalog>();
 
        public AggregateModuleCatalog()
        {
          catalogs.Add( new ModuleCatalog() );  
        }

        public ReadOnlyCollection<IModuleCatalog> Catalogs
        {
            get
            {
                return catalogs.AsReadOnly();
            }
        }

        public void AddCatalog( IModuleCatalog catalog )
        {
            if( catalog==null )
            {
                throw new ArgumentNullException("catalog");
            }
            catalogs.Add( catalog );
        }

        public IEnumerable<ModuleInfo> Modules
        {
            get
            {
                return Catalogs.SelectMany( x => x.Modules );
            }
        }

        public IEnumerable<ModuleInfo> GetDependentModules( ModuleInfo moduleInfo )
        {
            var catalog = catalogs.Single( x => x.Modules.Contains( moduleInfo ) );
            return catalog.GetDependentModules( moduleInfo );
        }

        public IEnumerable<ModuleInfo> CompleteListWithDependencies( IEnumerable<ModuleInfo> modules )
        {
            var moduleGroupedByCatalog = modules.GroupBy<ModuleInfo, IModuleCatalog>( module => catalogs.Single( catalog => catalog.Modules.Contains( module ) ) );
            return moduleGroupedByCatalog.SelectMany( x => x.Key.CompleteListWithDependencies( x ) );
        }

        public void Initialize()
        {
            foreach( var moduleCatalog in Catalogs )
            {
                moduleCatalog.Initialize();
            }
        }

        public void AddModule( ModuleInfo moduleInfo )
        {
            catalogs[0].AddModule( moduleInfo );
        }

       
    }
}
