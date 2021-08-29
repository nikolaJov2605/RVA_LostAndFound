using Common;
using Common.Services;
using Front.Commands;
using Front.Model;
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
    /// Interaction logic for ModifyItem.xaml
    /// </summary>
    public partial class ModifyItem : Window
    {
        private static ModifyItem instance;
        private MainWindow mw;

        public static ModifyItem Instance()
        {
            if (instance == null)
                instance = new ModifyItem();
            return instance;
        }

        public static void DeleteInstance()
        {
            instance = null;
        }

        private ModifyItem()
        {
            InitializeComponent();

            DataContext = new ModifyItemViewModel();

            mw = MainWindow.MainWindowInstance();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            DeleteInstance();
        }

        private void btnModifyItem_Click(object sender, RoutedEventArgs e)
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

            if (isValid == true)
            {
                Command modifyItemCommand = new ModifyItemCommand(dpDate.Text, tbOpis.Text, tbNaziv.Text, tbLokacija.Text, 
                    ModifyItemViewModel.Item.IsFound, ModifyItemViewModel.Item.OwnerUsername, ModifyItemViewModel.Item.FinderUsername);

                CommandExecutor.Invoker.AddAndExecuteCommand(modifyItemCommand, mw);

                this.Close();

                DeleteInstance();

            }
            else
                return;



            this.Close();
            DeleteInstance();
        }
    }
}
