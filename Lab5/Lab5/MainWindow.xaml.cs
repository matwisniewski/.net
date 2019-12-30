using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace Lab5
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
        private void Serialize(object sender, RoutedEventArgs e)
        {
            string firstName = tbox_first_name.Text.ToString();
            string lastName = tbox_last_name.Text.ToString();
            string email = tbox_email.Text.ToString();
            string city = tbox_city.Text.ToString();
            string street = tbox_street.Text.ToString();
            string houseNumber = tbox_house_number.Text.ToString();
            string flatNumber = tbox_flat_number.Text.ToString();
            User user = new User(firstName, lastName, email, city, street, houseNumber, flatNumber);

            string path = tbox_path.Text.ToString();

            if (!File.Exists(path))
            {
                File.Create(path).Close();
                tbox_message.Text = "Utworzono plik";
            }

            XmlSerializer serializer = new XmlSerializer(typeof(User));
            StreamWriter streamWriter = new StreamWriter(path);

            serializer.Serialize(streamWriter, user);

            streamWriter.Close();
        }

        private void Deserialize(object sender, RoutedEventArgs e)
        {
            string path = tbox_path.Text.ToString();

            XmlSerializer serializer = new XmlSerializer(typeof(User));

            try
            {
                StreamReader streamReader = new StreamReader(path);

                User user = (User)serializer.Deserialize(streamReader);
                streamReader.Close();

                tbox_first_name.Text = user.FirstName;
                tbox_last_name.Text = user.LastName;
                tbox_email.Text = user.Email;
                tbox_city.Text = user.City;
                tbox_street.Text = user.Street;
                tbox_house_number.Text = user.HouseNumber;
                tbox_flat_number.Text = user.FlatNumber;
            }
            catch (FileNotFoundException)
            {
                tbox_message.Text = "Brak pliku o podanej nazwie";
            }
            catch (Exception)
            {
                tbox_message.Text = "Błąd";
            }
        }

        private void Tbox_path_TextChanged(object sender, TextChangedEventArgs e)
        {
            string value = ((TextBox)sender).Text.ToString().Trim();
            if (value.Length == 0) ((TextBox)sender).Text = "user.xml";
        }
    }
}
