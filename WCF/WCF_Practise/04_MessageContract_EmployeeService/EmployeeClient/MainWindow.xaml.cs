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
            EmployeeService.IEmployeeService client = new EmployeeService.EmployeeServiceClient("BasicHttpBinding_IEmployeeService");
            EmployeeService.EmployeeRequest request = new EmployeeService.EmployeeRequest()
            {
                EmployeeId = Int32.Parse(Id.Text),
                LicenseKey="ABCDEFG"
            };

            var employee = client.GetEmployee(request);

            if (employee.Type==EmployeeService.EmployeeType.FullTimeEmployee)
            {
                AnnualSalryText.Visibility = Visibility.Visible;
                AnnualSalary.Visibility = Visibility.Visible;
                HourlyPaid.Visibility = Visibility.Hidden;
                HoursWorked.Visibility = Visibility.Hidden;
                HourlyPaidText.Visibility = Visibility.Hidden;
                HoursWorkedText.Visibility = Visibility.Hidden;
                AnnualSalary.Text = employee.AnnualSalary.ToString();
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

                HourlyPaid.Text = employee.HourlyPay.ToString();
                HoursWorked.Text = employee.HoursWorked.ToString();
                comboBox.SelectedValue = "PartTime Employee";
            }

            Gender.Text = employee.Gender;
            Name.Text = employee.Name;
            Dob.Text = employee.DOB.ToString();

        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            EmployeeService.IEmployeeService client = new EmployeeService.EmployeeServiceClient("BasicHttpBinding_IEmployeeService");
            EmployeeService.EmployeeInfo emp = new EmployeeService.EmployeeInfo();
           
            

            
            var selectedItem = comboBox.SelectedValue as ComboBoxItem;
            if (selectedItem != null)
            {
                var content = selectedItem.Content;
                if (content != null)
                {
                    emp.Id = Int32.Parse(Id.Text);
                    emp.Name = Name.Text;
                    emp.Gender = Gender.Name;
                    emp.DOB = Convert.ToDateTime(Dob.Text);

                    content = content.ToString();
                    if (content.Equals("Fulltime Employee"))
                    {
                        emp.AnnualSalary = Int32.Parse(AnnualSalary.Text);
                        emp.Type = EmployeeService.EmployeeType.FullTimeEmployee;
                    }

                    if (content.Equals("Select Employee Type"))
                    {


                    }

                    if (content.Equals("PartTime Employee"))
                    {
                        emp.HoursWorked = Int32.Parse(HoursWorked.Text);
                        emp.HourlyPay = Int32.Parse(HourlyPaid.Text);
                        emp.Type = EmployeeService.EmployeeType.PartTimeEmployee;
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
