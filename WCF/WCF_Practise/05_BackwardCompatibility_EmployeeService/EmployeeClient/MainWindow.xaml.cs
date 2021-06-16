using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HourlyPaid.Visibility = Visibility.Hidden;
            HoursWorked.Visibility = Visibility.Hidden;
            AnnualSalary.Visibility = Visibility.Hidden;
            HourlyPaidText.Visibility = Visibility.Hidden;
            AnnualSalryText.Visibility = Visibility.Hidden;
            HoursWorkedText.Visibility = Visibility.Hidden;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            EmployeeService.EmployeeServiceClient client = new EmployeeService.EmployeeServiceClient("BasicHttpBinding_IEmployeeService");
            var employee = client.GetEmployee(Int32.Parse(Id.Text));

            if (employee.Type==EmployeeService.EmployeeType.FullTimeEmployee)
            {
                AnnualSalryText.Visibility = Visibility.Visible;
                AnnualSalary.Visibility = Visibility.Visible;
                HourlyPaid.Visibility = Visibility.Hidden;
                HoursWorked.Visibility = Visibility.Hidden;
                HourlyPaidText.Visibility = Visibility.Hidden;
                HoursWorkedText.Visibility = Visibility.Hidden;
                AnnualSalary.Text = ((EmployeeService.FullTimeEmployee)employee).AnnualSalary.ToString();
                comboBox.SelectedValue = "Fulltime Employee";

            }
            else
            {
                AnnualSalryText.Visibility = Visibility.Hidden;
                AnnualSalary.Visibility = Visibility.Hidden;

                HourlyPaid.Visibility = Visibility.Visible;
                HoursWorked.Visibility = Visibility.Visible;
                HourlyPaidText.Visibility = Visibility.Visible;
                HoursWorkedText.Visibility = Visibility.Visible;

                HourlyPaid.Text = ((EmployeeService.PartTimeEmployee)employee).HourlyPay.ToString();
                HoursWorked.Text = ((EmployeeService.PartTimeEmployee)employee).HoursWorked.ToString();
                comboBox.SelectedValue = "PartTime Employee";
            }

            Gender.Text = employee.Gender;
            Name.Text = employee.Name;
            Dob.Text = employee.DateOfBirth.ToString();

        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            EmployeeService.EmployeeServiceClient client = new EmployeeService.EmployeeServiceClient("BasicHttpBinding_IEmployeeService");
            EmployeeService.Employee emp = null;
           
            

            
            var selectedItem = comboBox.SelectedValue as ComboBoxItem;
            if (selectedItem != null)
            {
                var content = selectedItem.Content;
                if (content != null)
                {
                    content = content.ToString();
                    if (content.Equals("Fulltime Employee"))
                    {
                        emp = new EmployeeService.FullTimeEmployee()
                        {
                            ID = Int32.Parse(Id.Text),
                            Name = Name.Text,
                            Gender = Gender.Name,
                            DateOfBirth = Convert.ToDateTime(Dob.Text),
                            AnnualSalary = Int32.Parse(AnnualSalary.Text),
                            Type=EmployeeService.EmployeeType.FullTimeEmployee
                        };

                    }

                    if (content.Equals("Select Employee Type"))
                    {


                    }

                    if (content.Equals("PartTime Employee"))
                    {
                        emp = new EmployeeService.PartTimeEmployee()
                        {
                            ID = Int32.Parse(Id.Text),
                            Name = Name.Text,
                            Gender = Gender.Name,
                            DateOfBirth = Convert.ToDateTime(Dob.Text),
                            HoursWorked = Int32.Parse(HoursWorked.Text),
                            HourlyPay = Int32.Parse(HourlyPaid.Text),
                            Type = EmployeeService.EmployeeType.PartTimeEmployee
                        };
                    }
                }

                client.SaveEmployee(emp);

            }
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combobox = (ComboBox)sender;
            var selectedItem = combobox.SelectedValue as ComboBoxItem;
            if (selectedItem!=null)
            {
                var content = selectedItem.Content;
                if (content!=null)
                {
                    content = content.ToString();
                    if (content.Equals("Fulltime Employee"))
                    {

                        AnnualSalary.Visibility = Visibility.Visible;
                        AnnualSalryText.Visibility = Visibility.Visible;

                        HourlyPaid.Visibility = Visibility.Hidden;
                        HoursWorked.Visibility = Visibility.Hidden;
                        HourlyPaidText.Visibility = Visibility.Hidden;
                        HoursWorkedText.Visibility = Visibility.Hidden;
                    }

                    if (content.Equals("Select Employee Type"))
                    {

                        AnnualSalary.Visibility = Visibility.Hidden;
                        AnnualSalryText.Visibility = Visibility.Hidden;

                        HourlyPaid.Visibility = Visibility.Hidden;
                        HoursWorked.Visibility = Visibility.Hidden;
                        HourlyPaidText.Visibility = Visibility.Hidden;
                        HoursWorkedText.Visibility = Visibility.Hidden;
                    }

                    if (content.Equals("PartTime Employee"))
                    {
                        AnnualSalryText.Visibility = Visibility.Hidden;
                        AnnualSalary.Visibility = Visibility.Hidden;

                        HourlyPaid.Visibility = Visibility.Visible;
                        HoursWorked.Visibility = Visibility.Visible;
                        HourlyPaidText.Visibility = Visibility.Visible;
                        HoursWorkedText.Visibility = Visibility.Visible;
                    }
                }
                
                
            }
            


            
        }
    }
}
