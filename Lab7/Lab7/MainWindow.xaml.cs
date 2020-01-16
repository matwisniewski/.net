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

namespace Lab7
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

        private void Login1_Click(object sender, RoutedEventArgs e)
        {
            tbox_message.Text = "";
            var klient1 = new Login();
            klient1.login = "matwis";
            klient1.haslo = "kochamC#";
            klient1.stanKonta = 2004.45;
            klient1.oszczednosci = 12345.12;
            klient1.zdolnoscKredyt = 100000;

            var klient2 = new Login();
            klient2.login = "dawpol";
            klient2.haslo = "kocham.NET";
            klient2.stanKonta = 98765.43;
            klient2.oszczednosci = 987654321.12;
            klient2.zdolnoscKredyt = 100000000;

            if (login.Text == klient1.login)
                if (haslo.Text == klient1.haslo)
                {
                    stan_konto.Text = klient1.stanKonta.ToString();
                    stan_oszczednosci.Text = klient1.oszczednosci.ToString();
                    zdolnosc.Text = klient1.zdolnoscKredyt.ToString();
                    haslo.Text = "";
                    kredyt.IsEnabled = true;
                    login.IsEnabled = false;
                    haslo.IsEnabled = false;
                    przelew.IsEnabled = true;
                }
                else if (login.Text == klient2.login)
                    if (haslo.Text == klient2.haslo)
                    {
                        stan_konto.Text = klient2.stanKonta.ToString();
                        stan_oszczednosci.Text = klient2.oszczednosci.ToString();
                        zdolnosc.Text = klient2.zdolnoscKredyt.ToString();
                        login.IsEnabled = false;
                        haslo.IsEnabled = false;
                        kredyt.IsEnabled = true;
                        przelew.IsEnabled = true;
                    }
                    else
                        tbox_message.Text = "Błędne dane";
                
        }

        private void Kredyt_Click(object sender, RoutedEventArgs e)
        {
            kwota_przelew.IsEnabled = true;
        }

        private void Przelew_Click(object sender, RoutedEventArgs e)
        {
            odbiorca.IsEnabled = true;
            tytul.IsEnabled = true;
            numer_konta.IsEnabled = true;
            kwota_przelew.IsEnabled = true;
        }
    }
}
