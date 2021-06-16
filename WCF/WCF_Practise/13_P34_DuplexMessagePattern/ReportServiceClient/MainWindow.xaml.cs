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
using System.Windows.Threading;

namespace ReportServiceClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [CallbackBehavior(UseSynchronizationContext = false)]
    public partial class MainWindow : Window,MyReportService.IReportServiceCallback
    {
        MyReportService.ReportServiceClient client;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Process(int percentageCompleted)
        {
            Console.WriteLine(percentageCompleted);
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background,
                new Action(() => textBox.Text = percentageCompleted.ToString() + " % Completed"));
            //textBox.Text = percentageCompleted.ToString() + " % Completed";
        }
        

        delegate void update();
        private void btnMessage_Click(object sender, RoutedEventArgs e)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            client = new MyReportService.ReportServiceClient(instanceContext);
            client.ProcessReport();
        }
    }
}
