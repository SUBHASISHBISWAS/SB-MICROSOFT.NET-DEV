using Subhasish.Libraries.SOA.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.UI.Framework
{
    [Serializable]
    public abstract class BaseViewModel:BaseEntity
    {
        public abstract string Title { get;  }

        public abstract string Description { get; }

        public override string ToString()
        {
            return string.Format(@"{0}, {1}",
                this.Title, this.Description);
        }
    }
}
