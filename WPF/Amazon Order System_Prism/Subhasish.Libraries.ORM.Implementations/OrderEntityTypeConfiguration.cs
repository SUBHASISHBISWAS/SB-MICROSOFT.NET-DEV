using Subhasish.Libraries.SOA.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.ORM.Implementations
{
    class OrderEntityTypeConfiguration:EntityTypeConfiguration<Order>
    {
        public OrderEntityTypeConfiguration()
        {
            HasKey(model => model.OrderId);
            Property(model => model.OrderId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            ToTable("Orders");

        }
    }
}
