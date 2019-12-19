using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Lab3
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            int tableSize = Convert.ToInt32(tableSizeTextBox.Text);
            int[] table = new int[tableSize];
            SortMachine sortMachine = new SortMachine(table);
            Task taskSync = new Task(() =>
            {
                Stopwatch stopwatch = new Stopwatch();
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    syncResult.Text = "Trwa generowanie tablicy";
                }));
                sortMachine.RandomTable();
                stopwatch.Start();
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    syncResult.Text = "Trwa sortowanie";
                }));
                sortMachine.Sort();
                stopwatch.Stop();
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    syncResult.Text = stopwatch.Elapsed.ToString();
                    stopwatch.Reset();
                }));
            });

            Task taskParallel = new Task(() =>
            {
                Stopwatch stopwatch = new Stopwatch();
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    parallelResult.Text = "Trwa generowanie tablicy";
                }));
                sortMachine.RandomTable();
                stopwatch.Start();
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    parallelResult.Text = "Trwa sortowanie";
                }));
                sortMachine.ParallelSort();
                stopwatch.Stop();
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    parallelResult.Text = stopwatch.Elapsed.ToString();
                    stopwatch.Reset();
                }));
            });

            taskSync.Start();
            taskParallel.Start();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Validator validator = new Validator();
            TextBox tbox = (TextBox)sender;

            if (validator.IsNumber(tbox.Text))
            {
                buttonStart.IsEnabled = true;
            }
            else
            {
                buttonStart.IsEnabled = false;
            }
        }
    }
}
