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
    /// Interaction logic for ModifyUser.xaml
    /// </summary>
    public partial class ModifyUser : Window
    {
        private static ModifyUser instance;
        private MainWindow mainWindow;

        private ModifyUser()
        {
            InitializeComponent();
        }

        private ModifyUser(string username, MainWindow mw) : base()
        {
            InitializeComponent();
            DataContext = new MainDataViewModel(username);
            mainWindow = mw;
        }

        public static ModifyUser Instance(string username, MainWindow mw)
        {
            if (instance == null)
                instance = new ModifyUser(username, mw);
            return instance;
        }

        public static void DeleteInstance()
        {
            instance = null;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            DeleteInstance();
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

            if (isValid == true)
            {
                ChannelFactory<ILoadPersonInfo> factory = new ChannelFactory<ILoadPersonInfo>("PersonInfo");
                ILoadPersonInfo proxy = factory.CreateChannel();

                Person loadedPerson = proxy.Load(lbUsername.Content.ToString());

                Command modifyUserInfoCommand = new ModifyPersonCommand(loadedPerson, tbIme.Text, tbPrezime.Text, mainWindow);
                CommandExecutor.Invoker.AddAndExecuteCommand(modifyUserInfoCommand, mainWindow);

                DeleteInstance();
                this.Close();
            }
            else
                return;
        }
    }
}
