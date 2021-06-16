using Subhasish.Libraries.DAL.Interfaces;
using Subhasish.Libraries.ORM.Interfaces;
using Subhasish.Libraries.SOA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.DAL.Implementation
{
    public class OrderRepository : IOrderRepository, IDisposable
    {
        private IOrderSystemContext orderSystemContext = default(IOrderSystemContext);

        public OrderRepository(IOrderSystemContext orderSystemContext )
        {
            this.orderSystemContext = orderSystemContext;
        }

        public bool Add(Order entity)
        {
            var status = default(bool);
            var validationStatus = entity != default(Order) &&
                orderSystemContext != default(IOrderSystemContext);

            if (validationStatus)
            {
                this.orderSystemContext.Orders.Add(entity);
                this.orderSystemContext.Commit();
                status = true;
            }
            return status;
        }

        public IEnumerable<Order> GetAll()
        {
            var orderlist = default(IEnumerable<Order>);

            var validationStatus = this.orderSystemContext != default(IOrderSystemContext);

            if (validationStatus)
            {

                orderlist = this.orderSystemContext.Orders.ToList();
            }

            return orderlist;
        }

        public Order GetById(int entityKey)
        {
            var filteredOrder = default(Order);
            var validationStatus = this.orderSystemContext != default(IOrderSystemContext) && entityKey != default(int);

            if (validationStatus)
            {
                filteredOrder = this.orderSystemContext.Orders.Where(order => order.OrderId.Equals(entityKey)).FirstOrDefault();
            }
            return filteredOrder;
        }

        public IEnumerable<Order> GetOrdersByCustomerId(int customerId)
        {
            var orderlist = default(IEnumerable<Order>);

            var validationStatus = this.orderSystemContext != default(IOrderSystemContext) && customerId != default(int);

            if (validationStatus)
            {
                var procedureName = "dbo.uspGetOrder @customerId";

                var parameter = new Dictionary<string, object>()
                    {
                        { "@customerId",customerId}
                    };

                orderlist = this.orderSystemContext.ExecuteRoutine<Order>(procedureName, parameter);   
            }

            return orderlist;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
