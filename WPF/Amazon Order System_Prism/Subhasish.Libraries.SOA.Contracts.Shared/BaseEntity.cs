using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Subhasish.Libraries.SOA.Contracts.Shared
{
    [Serializable]
    [DataContract(Name = "BaseEntity", Namespace = NamespaceConstants.CONTRACTS)]
    public abstract class BaseEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void Notify([CallerMemberName] string propertyName = default(string))
        {
            if (!string.IsNullOrEmpty(propertyName) 
                && PropertyChanged!= default(PropertyChangedEventHandler))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
