using Common;
using Common.Services;
using Front.Commands;
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
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        private static AddItem instance;
        private MainWindow mainWindow;

        private AddItem(string username, MainWindow mw) : base()
        {
            InitializeComponent();

            DataContext = new MainDataViewModel(username);

            dpDate.Text = "Unesite datum";
            dpDate.Foreground = Brushes.LightSlateGray;

            tbNaziv.Text = "Unesite naziv";
            tbNaziv.Foreground = Brushes.LightSlateGray;

            tbLokacija.Text = "Unesite lokaciju";
            tbLokacija.Foreground = Brushes.LightSlateGray;

            tbOpis.Text = "Unesite opis";
            tbOpis.Foreground = Brushes.LightSlateGray;

            tbVlasnik.Text = "Unesite korisničko ime vlasnika";
            tbVlasnik.Foreground = Brushes.LightSlateGray;

            mainWindow = mw;

        }

        public static AddItem Instance(string username, MainWindow mw)
        {
            if (instance == null)
                instance = new AddItem(username, mw);
            return instance;
        }

        public static void DeleteInstance()
        {
            instance = null;
        }

        private void btnRegisterAdd_Click(object sender, RoutedEventArgs e)
        {
            bool isValid = true;

            if (!FieldValidation.Validate(dpDate.Text, "Unesite datum"))
            {
                isValid = false;
                lblDateErr.Content = "Unesite datum";
                lblDateErr.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (!FieldValidation.Validate(tbNaziv.Text, "Unesite naziv"))
            {
                isValid = false;
                tbNaziv.Text = "Unesite naziv";
                tbNaziv.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (!FieldValidation.Validate(tbLokacija.Text, "Unesite lokaciju"))
            {
                isValid = false;
                tbLokacija.Text = "Unesite lokaciju";
                tbLokacija.Foreground = new SolidColorBrush(Colors.Red);
            }
            
            if (!FieldValidation.Validate(tbOpis.Text, "Unesite opis"))
            {
                isValid = false;
                tbOpis.Text = "Unesite opis";
                tbOpis.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (!FieldValidation.Validate(tbVlasnik.Text, "Unesite korisničko ime vlasnika"))
            {
                isValid = false;
                tbVlasnik.Text = "Unesite korisničko ime vlasnika";
                tbVlasnik.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (isValid == true)
            {
                Command addItem = new AddItemCommand(tbVlasnik.Text, dpDate.Text, tbNaziv.Text, tbLokacija.Text, tbOpis.Text);

                CommandExecutor.Invoker.AddAndExecuteCommand(addItem, mainWindow);

                this.Close();

                DeleteInstance();
                
            }
            else
                return;
        }

        private void tbNaziv_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbNaziv.Text.Trim().Equals("Unesite naziv"))
            {
                tbNaziv.Text = "";
                tbNaziv.Foreground = Brushes.Black;
            }
        }

        private void tbNaziv_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbNaziv.Text.Trim().Equals(string.Empty))
            {
                tbNaziv.Text = "Unesite naziv";
                tbNaziv.Foreground = Brushes.LightSlateGray;
            }
        }

        private void tbLokacija_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbLokacija.Text.Trim().Equals("Unesite lokaciju"))
            {
                tbLokacija.Text = "";
                tbLokacija.Foreground = Brushes.Black;
            }
        }

        private void tbLokacija_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbLokacija.Text.Trim().Equals(string.Empty))
            {
                tbLokacija.Text = "Unesite lokaciju";
                tbLokacija.Foreground = Brushes.LightSlateGray;
            }
        }

        private void tbOpis_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbOpis.Text.Trim().Equals("Unesite opis"))
            {
                tbOpis.Text = "";
                tbOpis.Foreground = Brushes.Black;
            }
        }

        private void tbOpis_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbOpis.Text.Trim().Equals(string.Empty))
            {
                tbOpis.Text = "Unesite opis";
                tbOpis.Foreground = Brushes.LightSlateGray;
            }
        }

        private void tbVlasnik_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbVlasnik.Text.Trim().Equals("Unesite korisničko ime vlasnika"))
            {
                tbVlasnik.Text = "";
                tbVlasnik.Foreground = Brushes.Black;
            }
        }

        private void tbVlasnik_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbVlasnik.Text.Trim().Equals(string.Empty))
            {
                tbVlasnik.Text = "Unesite korisničko ime vlasnika";
                tbVlasnik.Foreground = Brushes.LightSlateGray;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            DeleteInstance();
        }
    }
}
