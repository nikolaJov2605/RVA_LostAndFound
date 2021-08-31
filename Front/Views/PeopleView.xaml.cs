using Common;
using Common.Services;
using Front.Commands;
using Front.Model;
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
    /// Interaction logic for PeopleView.xaml
    /// </summary>
    public partial class PeopleView : Window
    {
        private static PeopleView instance;
        private PersonModel selectedPerson;

        public static PeopleView Instance()
        {
            if(instance == null)
                instance = new PeopleView();
            return instance;
        }

        public static void DeleteInstance()
        {
            instance = null;
        }

        public PeopleView()
        {
            InitializeComponent();
            DataContext = new PeopleViewModel();
            dataGridPeople.ItemsSource = LoadPeopleInfo.LoadPeople();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            DeleteInstance();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Registracija registracija = Registracija.Instance();
            registracija.Show();
        }

        private void dataGridPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPerson = (PersonModel)instance.dataGridPeople.SelectedItem;

            if (dataGridPeople.SelectedItems.Count > 0)
            {
                instance.btnModify.IsHitTestVisible = true;
                instance.btnModify.Background = Brushes.LightGray;

                instance.btnDelete.IsHitTestVisible = true;
                instance.btnDelete.Background = Brushes.LightGray;

                instance.buttonDetails.IsHitTestVisible = true;
                instance.buttonDetails.Background = Brushes.LightGray;
            }
            else
            {
                instance.btnModify.IsHitTestVisible = false;
                instance.btnModify.Background = Brushes.Gray;

                instance.btnDelete.IsHitTestVisible = false;
                instance.btnDelete.Background = Brushes.Gray;

                instance.buttonDetails.IsHitTestVisible = false;
                instance.buttonDetails.Background = Brushes.Gray;
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            instance.dataGridPeople.SelectedItem = null;
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            if (instance.dataGridPeople.SelectedItem == null)
            {
                return;
            }

            PeopleViewModel.Person = selectedPerson;

            ModifyPerson modifyPersonWindow = ModifyPerson.Instance();
            modifyPersonWindow.Show();
           
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            PersonModel selectedItem = (PersonModel)instance.dataGridPeople.SelectedItem;

            Command deletePerson = new DeletePersonAutorisedCommand(selectedItem);
            CommandExecutor.Invoker.AddAndExecuteCommand(deletePerson, MainWindow.MainWindowInstance());


        }

        private void buttonDetails_Click(object sender, RoutedEventArgs e)
        {

            PeopleViewModel.Person = (PersonModel)instance.dataGridPeople.SelectedItem;

            ChannelFactory<ILoadPersonInfo> factory = new ChannelFactory<ILoadPersonInfo>("PersonInfo");
            ILoadPersonInfo proxy = factory.CreateChannel();
            Person person = proxy.Load(PeopleViewModel.Person.Username);

            PeopleViewModel.Person.Password = person.Password;

            PersonView personView = PersonView.Instance();
            personView.Show();
        }
    }
}
