using Subhasish.Libraries.SOA.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.ORM.Interfaces
{
    public interface IOrderSystemContext:ISystemContext
    {
        IDbSet<Order> Orders { get; set; }
    }
}
