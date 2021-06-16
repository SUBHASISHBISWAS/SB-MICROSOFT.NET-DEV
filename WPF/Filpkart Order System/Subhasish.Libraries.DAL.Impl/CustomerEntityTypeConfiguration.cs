using Subhasish.Libraries.SOA.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.DAL.Impl
{
    class CustomerEntityTypeConfiguration:EntityTypeConfiguration<Customer>
    {
        public CustomerEntityTypeConfiguration()
        {
            HasKey(model => model.CustomerId);
            ToTable("Customers");
        }
    }
}
