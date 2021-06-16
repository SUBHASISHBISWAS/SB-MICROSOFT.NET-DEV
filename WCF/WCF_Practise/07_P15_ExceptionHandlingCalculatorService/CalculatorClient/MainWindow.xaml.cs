using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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

namespace CalculatorClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CalculatorService.CalculatorServiceClient client;
        public MainWindow()
        {
            InitializeComponent();
            client= new CalculatorService.CalculatorServiceClient();
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                var numerator = Convert.ToInt32(numeratorFiled.Text);
                var denominator = Convert.ToInt32(denominatorField.Text);
                resultText.Text = client.Divide(numerator, denominator).ToString();
            }
            //catch(FaultException<CalculatorService.DivideByZeroFault> faultException)
            //{
            //    resultText.Text = faultException.Detail.Error +"-"+ faultException.Detail.Details;
            //}

            catch (FaultException faultException)
            {
                resultText.Text = faultException.Message;
            }
            
        }
    }
}
