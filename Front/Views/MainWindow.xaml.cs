using Common.Services;
using Front.Commands;
using Front.Commands.LocalCommands;
using Front.Model;
using Front.SearchCriterias;
using Front.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace Front.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IClientNotification
    {
        private static MainWindow mainWindowInstance;
        private bool busy = false;
        public ItemModel selectedItem;

        private MainWindow()
        {
            InitializeComponent();
            DataContext = new MainDataViewModel();
            dataGridItems.ItemsSource = LoadItemsInfo.LoadItems();

            buttonRegister.Visibility = Visibility.Hidden;
            buttonPeople.Visibility = Visibility.Hidden;
        }

        private MainWindow(string username) : base()
        {
            InitializeComponent();
            DataContext = new MainDataViewModel(username);
            dataGridItems.ItemsSource = LoadItemsInfo.LoadItems();

            buttonRegister.Visibility = Visibility.Hidden;
            buttonPeople.Visibility = Visibility.Hidden;

        }

        public static MainWindow MainWindowInstance()
        {
            if (mainWindowInstance == null)
                mainWindowInstance = new MainWindow();
            return mainWindowInstance;
        }

        public static MainWindow MainWindowInstance(string username)
        {
            if (mainWindowInstance == null)
                mainWindowInstance = new MainWindow(username);
            return mainWindowInstance;
        }

        public static void DeleteInstance()
        {
            mainWindowInstance = null;
        }

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItemWindow = AddItem.Instance(lblUsername.Content.ToString(), mainWindowInstance);
            addItemWindow.Show();
        }

        private void btnUndo_Click(object sender, RoutedEventArgs e)
        {
            CommandExecutor.Invoker.Undo();
        }

        private void btnRedo_Click(object sender, RoutedEventArgs e)
        {
            CommandExecutor.Invoker.Redo();
        }

        public void NotifyForChanges()
        {
            if (busy == true)
                return;
            MainDataViewModel.Items = LoadItemsInfo.LoadItems();
            PeopleViewModel.People = LoadPeopleInfo.LoadPeople();
            mainWindowInstance.dataGridItems.ItemsSource = null;
            mainWindowInstance.dataGridItems.ItemsSource = MainDataViewModel.Items;

            PeopleView.Instance().dataGridPeople.ItemsSource = null;
            PeopleView.Instance().dataGridPeople.ItemsSource = PeopleViewModel.People;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            DeleteInstance();
        }

        private void btnUpdateUser_Click_1(object sender, RoutedEventArgs e)
        {
            ModifyUser modifyUser = ModifyUser.Instance(lblUsername.Content.ToString(), mainWindowInstance);
            modifyUser.Show();
        }


        private void buttonUndo_Click(object sender, RoutedEventArgs e)
        {
            dataGridItems.ItemsSource = null;
            dataGridItems.ItemsSource = LoadItemsInfo.LoadItems();
            mainWindowInstance.dP1.Text = String.Empty;
            mainWindowInstance.dP2.Text = String.Empty;
            mainWindowInstance.tbNaziv.Text = String.Empty;
            mainWindowInstance.tbLokacija.Text = String.Empty;
            mainWindowInstance.tbVlasnik.Text = String.Empty;
            mainWindowInstance.tbPronalazac.Text = String.Empty;
            mainWindowInstance.buttonUndo.Visibility = Visibility.Hidden;
            mainWindowInstance.buttonSearch.Visibility = Visibility.Visible;

            busy = false;
        }

        private void buttonSearch_Click(object sender, RoutedEventArgs e)
        {
            List<ItemModel> source = new List<ItemModel>();
            foreach (ItemModel item in dataGridItems.Items)
                source.Add(item);
            dataGridItems.ItemsSource = null;
            dataGridItems.ItemsSource = SearchCommandExecutor.ExecuteSearch(source, dP1.Text, dP2.Text, tbNaziv.Text, tbLokacija.Text, tbVlasnik.Text, tbPronalazac.Text);

            mainWindowInstance.buttonSearch.Visibility = Visibility.Hidden;
            mainWindowInstance.buttonUndo.Visibility = Visibility.Visible;

            busy = true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Registracija registrationWindow = Registracija.Instance();
            registrationWindow.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if(lblRole.Content.ToString() == "ADMIN")
            {
                buttonRegister.Visibility = Visibility.Visible;
                buttonPeople.Visibility = Visibility.Visible;
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();

            AddItem addItem = AddItem.Instance(lblUsername.Content.ToString(), mainWindowInstance);
            addItem.Close();
            AddItem.DeleteInstance();

            ModifyItem modifyItem = ModifyItem.Instance();
            modifyItem.Close();
            ModifyItem.DeleteInstance();

            ModifyUser modifyUser = ModifyUser.Instance(lblUsername.Content.ToString(), mainWindowInstance);
            modifyUser.Close();
            ModifyUser.DeleteInstance();

            Registracija registracija = Registracija.Instance();
            registracija.Close();
            Registracija.DeleteInstance();

            UnsubscribeUser.Unsubscribe();

            this.Close();
            DeleteInstance();
        }

        private void buttonModifyItem_Click(object sender, RoutedEventArgs e)
        {
            if(mainWindowInstance.dataGridItems.SelectedItem == null)
            {
                return;
            }

            ModifyItemViewModel.Item = selectedItem;

            ModifyItem modifyItemWindow = ModifyItem.Instance();
            modifyItemWindow.Show();

        }

        private void dataGridItems_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(dataGridItems.SelectedItems.Count > 0)
            {
                selectedItem = (ItemModel)mainWindowInstance.dataGridItems.SelectedItem;

                mainWindowInstance.buttonDetails.IsHitTestVisible = true;
                mainWindowInstance.buttonDetails.Background = Brushes.LightGray;

                if (lblRole.Content.ToString() == "USER")
                {
                    if (selectedItem.OwnerUsername == lblUsername.Content.ToString())
                    {
                        mainWindowInstance.buttonModifyItem.IsHitTestVisible = true;
                        mainWindowInstance.buttonModifyItem.Background = Brushes.LightGray;

                        mainWindowInstance.buttonDelete.IsHitTestVisible = true;
                        mainWindowInstance.buttonDelete.Background = Brushes.LightGray;

                        mainWindowInstance.buttonDuplicate.IsHitTestVisible = true;
                        mainWindowInstance.buttonDuplicate.Background = Brushes.LightGray;

                        mainWindowInstance.buttonFound.IsHitTestVisible = false;
                        mainWindowInstance.buttonFound.Background = Brushes.Gray;

                    }
                    else
                    {
                        mainWindowInstance.buttonModifyItem.IsHitTestVisible = false;
                        mainWindowInstance.buttonModifyItem.Background = Brushes.Gray;

                        mainWindowInstance.buttonDelete.IsHitTestVisible = false;
                        mainWindowInstance.buttonDelete.Background = Brushes.Gray;

                        mainWindowInstance.buttonDuplicate.IsHitTestVisible = false;
                        mainWindowInstance.buttonDuplicate.Background = Brushes.Gray;

                        if(!selectedItem.IsFound)
                        {
                            mainWindowInstance.buttonFound.IsHitTestVisible = true;
                            mainWindowInstance.buttonFound.Background = Brushes.Green;
                        }
                    }
                }
                else
                {
                    mainWindowInstance.buttonModifyItem.IsHitTestVisible = true;
                    mainWindowInstance.buttonModifyItem.Background = Brushes.LightGray;

                    mainWindowInstance.buttonDelete.IsHitTestVisible = true;
                    mainWindowInstance.buttonDelete.Background = Brushes.LightGray;

                    mainWindowInstance.buttonDuplicate.IsHitTestVisible = true;
                    mainWindowInstance.buttonDuplicate.Background = Brushes.LightGray;

                    if (!selectedItem.IsFound)
                    {
                        mainWindowInstance.buttonFound.IsHitTestVisible = true;
                        mainWindowInstance.buttonFound.Background = Brushes.Green;
                    }
                }
            }
            else
            {
                mainWindowInstance.buttonModifyItem.IsHitTestVisible = false;
                mainWindowInstance.buttonModifyItem.Background = Brushes.Gray;

                mainWindowInstance.buttonDelete.IsHitTestVisible = false;
                mainWindowInstance.buttonDelete.Background = Brushes.Gray;

                mainWindowInstance.buttonDuplicate.IsHitTestVisible = false;
                mainWindowInstance.buttonDuplicate.Background = Brushes.Gray;

                mainWindowInstance.buttonFound.IsHitTestVisible = false;
                mainWindowInstance.buttonFound.Background = Brushes.Gray;

                mainWindowInstance.buttonDetails.IsHitTestVisible = false;
                mainWindowInstance.buttonDetails.Background = Brushes.Gray;
            }
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            mainWindowInstance.dataGridItems.SelectedItem = null;
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            selectedItem = (ItemModel)mainWindowInstance.dataGridItems.SelectedItem;
            Command deleteCommand = new DeleteItemCommand(selectedItem.Id);
            CommandExecutor.Invoker.AddAndExecuteCommand(deleteCommand, mainWindowInstance);
        }

        private void buttonDuplicate_Click(object sender, RoutedEventArgs e)
        {
            selectedItem = (ItemModel)mainWindowInstance.dataGridItems.SelectedItem;

            Command duplicateCommand = new DuplicateCommand(selectedItem);
            CommandExecutor.Invoker.AddAndExecuteCommand(duplicateCommand, mainWindowInstance);

        }

        private void buttonPeople_Click(object sender, RoutedEventArgs e)
        {
            PeopleView peopleView = PeopleView.Instance();
            peopleView.Show();
        }

        private void buttonFound_Click(object sender, RoutedEventArgs e)
        {
            selectedItem = (ItemModel)mainWindowInstance.dataGridItems.SelectedItem;
            Command foundCommand = new FoundItemCommand(selectedItem.Id, lblUsername.Content.ToString());
            CommandExecutor.Invoker.AddAndExecuteCommand(foundCommand, mainWindowInstance);
        }

        private void buttonDetails_Click(object sender, RoutedEventArgs e)
        {
            selectedItem = (ItemModel)mainWindowInstance.dataGridItems.SelectedItem;
            ItemViewModel.Item = selectedItem;
            ItemView itemView = ItemView.Instance();
            itemView.Show();
        }
    }
}
