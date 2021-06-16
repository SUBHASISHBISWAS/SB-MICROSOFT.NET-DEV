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
    [DataContract(Name ="Customer",Namespace =NamespaceConstants.CONTRACTS)]
    public class Customer:BaseEntity
    {
        private int customerId;
        private string customerName;
        private string address;
        private int creditLimit;
        private bool activeStatus;

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
        public string CustomerName
        {
            get
            {
                return customerName;
            }

            set
            {
                customerName = value;
                Notify();
            }
        }

        [DataMember]
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
                Notify();
            }
        }

        [DataMember]
        public int CreditLimit
        {
            get
            {
                return creditLimit;
            }

            set
            {
                creditLimit = value;
                Notify();
            }
        }

        [DataMember]
        public bool ActiveStatus
        {
            get
            {
                return activeStatus;
            }

            set
            {
                activeStatus = value;
                Notify();
            }
        }

        public override string ToString()
        {
            return string.Format(@"{0},{1},{2},{3},{4}",this.customerId,this.customerName,
                this.address,this.creditLimit,this.activeStatus);
        }
    }
}
