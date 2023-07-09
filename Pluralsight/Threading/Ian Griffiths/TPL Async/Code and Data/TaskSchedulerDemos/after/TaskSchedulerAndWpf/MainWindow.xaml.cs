using System.Net;
using System.Windows;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSchedulerAndWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private WebClient _w = new WebClient();
        private TaskScheduler _syncSched =
            TaskScheduler.FromCurrentSynchronizationContext();

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            btn1.IsEnabled = false;
            _w.DownloadStringTaskAsync("http://www.pluralsight-training.net/")
                .ContinueWith(t =>
                    {
                        tb1.Text = t.Result;
                        btn1.IsEnabled = true;
                    },
                    _syncSched);

        }
    }
}
