using Subhasish.Libraries.SOA.Contracts.Data;
using Subhasish.Libraries.SOA.Contracts.Services;
using Subhasish.Libraries.UI.Framework;
using Subhasish.Libraries.UI.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Subhasish.Libraries.UI.ViewModels.Impl
{
    public class OrderSystemDashboardViewModel:BaseOrderSystemDashboardViewModel
    {
        private ObservableCollection<Customer> customersCollection = default(ObservableCollection<Customer>);
        private ObservableCollection<Order> ordersCollection = default(ObservableCollection<Order>);
        private IOrderSystemService orderSystemService = default(IOrderSystemService);
        private IApplicationService applicationService = default(IApplicationService);
        private IUserInteractionService userInteractionService = default(IUserInteractionService);
        public OrderSystemDashboardViewModel(IOrderSystemService orderSystemService, IApplicationService applicationService, IUserInteractionService userInteractionService)
        {
            this.orderSystemService = orderSystemService;
            this.applicationService = applicationService;
            this.userInteractionService = userInteractionService;

            this.Serach = new DelegateCommand<string>(InitializeSearch);
            this.Reset = new DelegateCommand(InitializeReset);
            this.Close = new DelegateCommand<string>(InitializeClose);

            if (this.applicationService != default(IApplicationService))
                this.UserName = this.applicationService.UserName;
        }

        private  async void InitializeSearch(string searchString)
        {
            var validationStatus = this.orderSystemService != default(IOrderSystemService);

            if (validationStatus)
            {

                this.Customers = CollectionViewSource.GetDefaultView(
                   new ObservableCollection<Customer>
                   {
                        new Customer { CustomerName = "Searching ... Please Wait ..." }
                   });

                await Task.Run(() =>
                {
                    var customers = default(IEnumerable<Customer>);

                    if (string.IsNullOrEmpty(searchString) || searchString.Equals("*"))
                    {
                        customers = orderSystemService.GetAllCustomers();
                    }
                    else
                    {
                        customers = orderSystemService.GetCustomersByName(SearchString);
                    }

                    customersCollection = new ObservableCollection<Customer>(customers);
                    this.Customers = CollectionViewSource.GetDefaultView(this.customersCollection);
                    this.Customers.GroupDescriptions.Add(new PropertyGroupDescription("Address"));
                    this.Customers.CurrentChanged += (sender, args) =>
                    {
                        var currentCustomer = this.Customers.CurrentItem as Customer;

                        if (currentCustomer!=default(Customer) && 
                        this.orderSystemService!=default(IOrderSystemService))
                        {
                            var orderList = orderSystemService.GetOrdersByCustomerId(currentCustomer.CustomerId);
                            this.ordersCollection = new ObservableCollection<Order>(orderList);
                            this.Orders = CollectionViewSource.GetDefaultView(this.ordersCollection);

                        }
                    };
          
                });
            }
        }

        private void InitializeReset()
        {
            this.SearchString = string.Empty;
            this.customersCollection = default(ObservableCollection<Customer>);
            this.Customers = default(ICollectionView);
            this.ordersCollection = default(ObservableCollection<Order>);
            this.Orders = default(ICollectionView);
        }

        public void InitializeClose(string confirmationFlag)
        {
            var isConfirmationRequired = bool.Parse(confirmationFlag);
            var exitStatus = true;

            if (isConfirmationRequired && userInteractionService != default(IUserInteractionService))
            {
                var message = "Do you wish to close the application now?";

                exitStatus = userInteractionService.ShowConfirmation(message);
            }

            if (applicationService != default(IApplicationService) && exitStatus)
                applicationService.Shutdown();
        }


    }
}
