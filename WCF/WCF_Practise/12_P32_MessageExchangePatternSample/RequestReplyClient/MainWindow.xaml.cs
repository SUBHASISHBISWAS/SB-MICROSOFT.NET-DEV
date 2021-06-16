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

namespace RequestReplyClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SimpleService.SampleServiceClient client;
        public MainWindow()
        {
            InitializeComponent();
            client = new SimpleService.SampleServiceClient();
        }

        private void requestReplyBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listBox.Items.Add("Request Reply Operation Started At +" + DateTime.Now.ToString());
                requestReplyBtn.IsEnabled = false;
                listBox.Items.Add(client.RequestReplyOperation());
                requestReplyBtn.IsEnabled = true;
                listBox.Items.Add("Request Reply Operation Completed At +" + DateTime.Now.ToString());
                listBox.Items.Add("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void requestReplyExceptionBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listBox.Items.Add("Request Reply Operation Started At +" + DateTime.Now.ToString());
                client.RequestReplyOperation_ThrowsException();
                listBox.Items.Add("Request Reply Operation Completed At +" + DateTime.Now.ToString());
                listBox.Items.Add("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
        }

        private void onewayBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listBox.Items.Add("Request Reply Operation Started At +" + DateTime.Now.ToString());
                client.OneWayOperation();
                listBox.Items.Add("Request Reply Operation Completed At +" + DateTime.Now.ToString());
                listBox.Items.Add("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void oneWayExBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                listBox.Items.Add("Request Reply Operation Started At +" + DateTime.Now.ToString());
                onewayBtn.IsEnabled = false;
                client.OneWayOperation_ThrowsException();
                onewayBtn.IsEnabled = true;
                listBox.Items.Add("Request Reply Operation Completed At +" + DateTime.Now.ToString());
                listBox.Items.Add("");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
