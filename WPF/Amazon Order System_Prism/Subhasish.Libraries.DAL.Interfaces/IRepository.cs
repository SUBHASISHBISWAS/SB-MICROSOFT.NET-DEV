using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.DAL.Interfaces
{
    public interface IRepository<TEntity,TEntityKey> where TEntity :class
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(TEntityKey entityKey);

        bool Add(TEntity entity);
    }
}
