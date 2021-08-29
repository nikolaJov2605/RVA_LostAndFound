using Common;
using Common.Services;
using Front.ViewModel;
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
using System.Windows.Shapes;

namespace Front.Views
{
    /// <summary>
    /// Interaction logic for Registracija.xaml
    /// </summary>
    public partial class Registracija : Window
    {
        public Registracija()
        {
            InitializeComponent();

            tbIme.Text = "Unesite ime";
            tbIme.Foreground = Brushes.LightSlateGray;

            tbPrezime.Text = "Unesite prezime";
            tbPrezime.Foreground = Brushes.LightSlateGray;

            dpDate.Text = "Unesite datum";
            dpDate.Foreground = Brushes.LightSlateGray;

            tbUsername.Text = "Unesite korisničko ime";
            tbUsername.Foreground = Brushes.LightSlateGray;

            passwordBox.PasswordChar = '*';
            passwordBox.Foreground = Brushes.Black;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            if (!FieldValidation.Validate(tbIme.Text, "Unesite ime"))
            {
                isValid = false;
                tbIme.Text = "Unesite ime";
                tbIme.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (!FieldValidation.Validate(tbPrezime.Text, "Unesite prezime"))
            {
                isValid = false;
                tbPrezime.Text = "Unesite prezime";
                tbPrezime.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (!FieldValidation.Validate(dpDate.Text, "Unesite datum"))
            {
                isValid = false;
                lblDateErr.Content = "Unesite datum";
                lblDateErr.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (!FieldValidation.Validate(tbUsername.Text, "Unesite korisničko ime"))
            {
                isValid = false;
                tbUsername.Text = "Unesite korisničko ime";
                tbUsername.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (passwordBox.Password == null || passwordBox.Password == "")
            {
                isValid = false;
                passwordBox.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (isValid == true)
            {
                Person person = new Person(tbUsername.Text, passwordBox.Password, tbIme.Text, tbPrezime.Text, dpDate.Text, Role.USER);

                ChannelFactory<IRegistration> factory = new ChannelFactory<IRegistration>("UserRegistration");
                IRegistration proxy = factory.CreateChannel();

                if(proxy.Register(person) == true)
                {
                    /*MainWindow mainWindow = new MainWindow();
                    this.Close();
                    mainWindow.Show();*/
                    Console.WriteLine("User " + person.Username + " registered");
                    this.Close();
                }
                
            }
            else
                return;
        }

        private void tbIme_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbIme.Text.Trim().Equals("Unesite ime"))
            {
                tbIme.Text = "";
                tbIme.Foreground = Brushes.Black;
            }
        }

        private void tbIme_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbIme.Text.Trim().Equals(string.Empty))
            {
                tbIme.Text = "Unesite ime";
                tbIme.Foreground = Brushes.LightSlateGray;
            }
        }

        private void tbPrezime_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbPrezime.Text.Trim().Equals("Unesite prezime"))
            {
                tbPrezime.Text = "";
                tbPrezime.Foreground = Brushes.Black;
            }
        }

        private void tbPrezime_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbPrezime.Text.Trim().Equals(string.Empty))
            {
                tbPrezime.Text = "Unesite prezime";
                tbPrezime.Foreground = Brushes.LightSlateGray;
            }
        }


        private void tbUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text.Trim().Equals("Unesite korisničko ime"))
            {
                tbUsername.Text = "";
                tbUsername.Foreground = Brushes.Black;
            }
        }

        private void tbUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text.Trim().Equals(string.Empty))
            {
                tbUsername.Text = "Unesite korisničko ime";
                tbUsername.Foreground = Brushes.LightSlateGray;
            }
        }

    }
}
