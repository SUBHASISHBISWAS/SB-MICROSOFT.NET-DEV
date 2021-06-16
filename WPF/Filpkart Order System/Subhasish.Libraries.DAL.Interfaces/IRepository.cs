using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.DAL.Interfaces
{
    public interface IRepository<Entity,EntityKey>
    {
        IEnumerable<Entity> GetEntities();
        Entity GetEntityByKey(EntityKey entityKey);
    }
}
