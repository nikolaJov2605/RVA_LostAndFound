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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        MainWindow mainWindow;
        public Login()
        {
            InitializeComponent();

            tbUsername.Text = "Unesite korisničko ime";
            tbUsername.Foreground = Brushes.LightSlateGray;

            passwordBox.PasswordChar = '*';
            passwordBox.Foreground = Brushes.Black;

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;
            
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

                ChannelFactory<ISignIn> factory = new ChannelFactory<ISignIn>("UserSignIn");
                ISignIn proxy = factory.CreateChannel();

                /*DuplexChannelFactory<ISubscription> channelFactory = new DuplexChannelFactory<ISubscription>("UserSubscription");
                ISubscription subscriptionProxy = channelFactory.CreateChannel();*/

                /*var uri = "net.tcp://localhost:4000/ISubscription";
                var binding = new NetTcpBinding(SecurityMode.None);*/

                //MainWindow mw = MainWindow.MainWindowInstance();

                if (proxy.SignIn(tbUsername.Text, passwordBox.Password) == true)
                {
                    mainWindow = MainWindow.MainWindowInstance(tbUsername.Text);

                    InstanceContext callback = new InstanceContext(mainWindow);
                    var channel = new DuplexChannelFactory<ISubscription>(callback, "UserSubscription");
                    ISubscription subscriptionProxy = channel.CreateChannel();

                    subscriptionProxy.Subscribe();

                    this.Close();
                    mainWindow.Show();
                }
            }
            else
                return;
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


        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Registracija registrationWindow = new Registracija();
            registrationWindow.Show();
        }
    }
}
