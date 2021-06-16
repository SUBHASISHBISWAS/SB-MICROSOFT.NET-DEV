using Subhasish.Libraries.UI.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Subhasish.Libraries.UI.ViewModels
{
    [Serializable]
    public  abstract class BaseOrderSystemDashboardViewModel : BaseViewModel
    {
        private const String TITLE = "Oreder System Dashboard ViewModel";

        private const String DESCRIPTION = "Viewmodel Logic for Oreder System Dashboard ViewModel";

        private string searchString = default(string);
        private ICollectionView customerView = default(ICollectionView);
        private ICollectionView orderView = default(ICollectionView);
        private string userName = default(string);

        public override string Description
        {
            get
            {
                return TITLE;
            }

           
        }

        public override string Title
        {
            get
            {
                return DESCRIPTION;
            }

            
        }

        public ICommand Serach { get; protected set; }
        public ICommand Close { get; protected set; }
        public ICommand Reset { get; protected set; }

        public ICollectionView Customers
        {
            get
            {
                return customerView;
            }
            protected set
            {
                customerView = value;
                Notify();
            }
        }

        public ICollectionView Orders
        {
            get
            {
                return orderView;
            }
            protected set
            {
                orderView = value;
                Notify();
            }
        }

        public string SearchString
        {
            get
            {
                return searchString;
            }
            set
            {
                searchString = value;
                Notify();
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
                Notify();
            }
        }
    }
}
