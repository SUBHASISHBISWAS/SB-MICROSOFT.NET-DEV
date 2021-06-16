using Subhasish.Libraries.SOA.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.SOA.Contracts.Faults
{
    [Serializable]
    [DataContract(
        Name = "ServiceError",
        Namespace = NamespaceConstants.FAULTS)]
    public class ServiceError : BaseEntity
    {
        private int errorId;
        private string message;
        private string source;

        #region Public Properties

        [DataMember]
        public int ErrorId
        {
            get { return errorId; }
            set { errorId = value; }
        }

        [DataMember]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        [DataMember]
        public string Source
        {
            get { return source; }
            set { source = value; }
        }

        #endregion

        public override string ToString()
        {
            return string.Format(@"{0}, {1}, {2}",
                this.errorId, this.source, this.message);
        }
    }
}
