using Common;
using Front.Commands;
using Front.ViewModel;
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
using System.Windows.Shapes;

namespace Front.Views
{
    /// <summary>
    /// Interaction logic for ModifyPerson.xaml
    /// </summary>
    public partial class ModifyPerson : Window
    {
        private static ModifyPerson instance;

        public static ModifyPerson Instance()
        {
            if (instance == null)
                instance = new ModifyPerson();
            return instance;
        }

        public static void DeleteInstance()
        {
            instance = null;
        }

        private ModifyPerson()
        {
            InitializeComponent();

            DataContext = new PeopleViewModel();

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

            cbRole.Foreground = Brushes.Black;

        }


        private void btnModify_Click(object sender, RoutedEventArgs e)
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

            if (passwordBox.Password == null || passwordBox.Password == "")
            {
                isValid = false;
                passwordBox.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (cbRole.Text == "Izaberite ulogu")
            {
                isValid = false;
                cbRole.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (isValid == true)
            {
                Role userRole = Role.ADMIN;

                if (cbRole.Text == "Administrator")
                    userRole = Role.ADMIN;
                else if (cbRole.Text == "Korisnik")
                    userRole = Role.USER;

                Person person = new Person(tbUsername.Text, passwordBox.Password, tbIme.Text, tbPrezime.Text, dpDate.Text, userRole);

                Command autorisedPersonModification = new AutorisedModifyPersonCommand(person);
                CommandExecutor.Invoker.AddAndExecuteCommand(autorisedPersonModification, MainWindow.MainWindowInstance());

                
                this.Close();
                DeleteInstance();
               

            }
            else
                return;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            DeleteInstance();
        }
    }
}
