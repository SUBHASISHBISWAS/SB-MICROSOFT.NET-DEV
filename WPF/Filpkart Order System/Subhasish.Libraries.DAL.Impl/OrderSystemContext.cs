using Subhasish.Libraries.SOA.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.DAL.Impl
{
    public class OrderSystemContext:DbContext
    {
        private static string CONNECTION_STRING =
                   ConfigurationManager.ConnectionStrings["SubhasishPracticeDB"].ConnectionString;

        public OrderSystemContext():base(CONNECTION_STRING)
        {

        }

        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add<Customer>(new CustomerEntityTypeConfiguration());
            modelBuilder.Configurations.Add<Order>(new OrderEntityTypeConfiguration());
        }
    }
}
