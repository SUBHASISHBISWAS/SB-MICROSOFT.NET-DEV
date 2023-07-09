using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace CustomSchedulerExample
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

        private SingleThreadTaskScheduler _sts = new SingleThreadTaskScheduler();
        private TaskScheduler _ss = TaskScheduler.FromCurrentSynchronizationContext();

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
                {
                    Debug.WriteLine("First method");
                    Thread.Sleep(2000);
                    Debug.WriteLine("First done");
                    return "Result";
                },
                CancellationToken.None,
                TaskCreationOptions.None,
                _sts)
            .ContinueWith(t =>
                {
                    Debug.WriteLine("Second method");
                    return t.Result + ", more";
                },
                CancellationToken.None,
                TaskContinuationOptions.ExecuteSynchronously,
                _sts)
            .ContinueWith(t =>
                {
                    textBlock1.Text = t.Result;
                }, _ss);
        }
    }
}
