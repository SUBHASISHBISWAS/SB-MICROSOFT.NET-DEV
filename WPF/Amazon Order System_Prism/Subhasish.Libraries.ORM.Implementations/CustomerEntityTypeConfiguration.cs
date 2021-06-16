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
    class CustomerEntityTypeConfiguration:EntityTypeConfiguration<Customer>
    {
        public CustomerEntityTypeConfiguration()
        {
            HasKey(model => model.CustomerId);

            Property(model => model.CustomerId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ToTable("Customers");
        }
    }
}
