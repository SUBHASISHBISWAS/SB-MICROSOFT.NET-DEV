using Subhasish.Libraries.ORM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subhasish.Libraries.SOA.Data;
using System.Data.Entity;

namespace Subhasish.Libraries.ORM.Implementations
{
    public class OrderSystemContext : BaseSystemContext, IOrderSystemContext
    {
        public IDbSet<Order> Orders
        {
            get; set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add<Order>(new OrderEntityTypeConfiguration());
        }
    }
}
