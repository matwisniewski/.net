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
using System.Xml;
using System.Xml.Serialization;

namespace Lab6
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

            try
            {
                if (!File.Exists(path))
                {
                    XmlSerializer xSeriz = new XmlSerializer(typeof(List<User>));
                    FileStream fs = File.Open(path, FileMode.Append);
                    List<User> userAsList = new List<User>
                    {
                        user
                    };
                    xSeriz.Serialize(fs, userAsList);
                    fs.Close();
                    tbox_message.Text = "Utworzono nowy plik";
                }
                else
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    XmlNode xnode = doc.CreateNode(XmlNodeType.Element, "serialize", null);
                    XmlSerializer xSeriz = new XmlSerializer(typeof(User));
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    XmlWriterSettings writtersetting = new XmlWriterSettings
                    {
                        OmitXmlDeclaration = true
                    };
                    StringWriter stringwriter = new StringWriter();
                    using (XmlWriter xmlwriter = XmlWriter.Create(stringwriter, writtersetting))
                    {
                        xSeriz.Serialize(xmlwriter, user, ns);
                    }
                    xnode.InnerXml = stringwriter.ToString();
                    XmlNode bindxnode = xnode.SelectSingleNode("User");
                    doc.DocumentElement.AppendChild(bindxnode);
                    doc.Save(path);
                    tbox_message.Text = "Dodano użytkownika";
                }
            }
            catch (Exception)
            {
                tbox_message.Text = "ERROR";
            }
        }

        public static XmlElement SerializeToXmlElement(object o)
        {
            XmlDocument doc = new XmlDocument();
            using (XmlWriter writer = doc.CreateNavigator().AppendChild())
            {
                new XmlSerializer(o.GetType()).Serialize(writer, o);
            }
            return doc.DocumentElement;
        }

        private void Tbox_path_TextChanged(object sender, TextChangedEventArgs e)
        {
            string value = ((TextBox)sender).Text.ToString().Trim();
            if (value.Length == 0) ((TextBox)sender).Text = "users.xml";
        }
    }
}

