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
using Lab1.Model;

namespace Lab1
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User user = new User("Mateusz", "Wiśniewski", 1997, "Gliwice", "Gliwicka", 2, "44-100", "");

            PeselValidator peselValidator = new PeselValidator(user);
            this.Message.Text = "Imie: " + user.FirstName + "\nNazwisko: " + user.LastName + "\nRok urodzienia: " + user.YearOfBirth + "\nLat:" + user.GetAge() + "\nMiasto: " + user.City + "\nAdres: " + user.Street + " " + user.HouseNumber + "\nKod pocztowy: " + user.PostalCode;
            if (peselValidator.IsValid())
            {
                this.Message.Text += "\nPodany PESEL: \n" + peselValidator.User.PESEL;
            }
            else
            {
                this.Message.Text += "\nBrak numeru PESEL \nWygenerowany PESEL: \n" + peselValidator.GeneratePesel();
            }
        }
    }
}
