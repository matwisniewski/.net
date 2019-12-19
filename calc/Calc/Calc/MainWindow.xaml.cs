using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Calc
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Jeden_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Dwa_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double x;
            double y;
            try
            {
                x = Double.Parse(jeden.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                y = Double.Parse(dwa.Text.Replace(",", "."), CultureInfo.InvariantCulture);
                double koniec;
                if (dzialanie.Text == "") wynik.Text = "Podaj znak działania";
                else if (dzialanie.Text == "+") wynik.Text = (koniec = x + y).ToString();
                else if (dzialanie.Text == "-") wynik.Text = (koniec = x - y).ToString();
                else if (dzialanie.Text == "*") wynik.Text = (koniec = x * y).ToString();
                else if (dzialanie.Text == "/") if (y == 0) wynik.Text = "Nie można dzielić przez 0";
                    else wynik.Text = (koniec = x / y).ToString();
            }
            catch (Exception)
            {
                wynik.Text = "Błędne dane";
            }
        }
    }
}
