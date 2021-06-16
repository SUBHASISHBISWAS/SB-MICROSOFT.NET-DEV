using Subhasish.Libraries.SOA.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.SOA.Data
{
    [Serializable]
    [DataContract(Name ="Order",Namespace = NamespaceConstants.CONTRACTS)]
    public class Order:BaseEntity
    {
        private int orderId;
        private DateTime orderDate;
        private int customerId;
        private int units;
        private int amount;

        [DataMember]
        public int OrderId
        {
            get
            {
                return orderId;
            }

            set
            {
                orderId = value;
                Notify();
                
            }
        }

        [DataMember]
        public DateTime OrderDate
        {
            get
            {
                return orderDate;
            }

            set
            {
                orderDate = value;
                Notify();
            }
        }

        [DataMember]
        public int CustomerId
        {
            get
            {
                return customerId;
            }

            set
            {
                customerId = value;
                Notify();
            }
        }

        [DataMember]
        public int Units
        {
            get
            {
                return units;
            }

            set
            {
                units = value;
                Notify();
            }
        }
        [DataMember]
        public int Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
                Notify();
            }
        }

        public override string ToString()
        {
            return string.Format(@"{0},{1},{2},{3},{4}", this.orderId, this.orderDate, 
                this.customerId, this.units, this.amount);
        }
    }
}
