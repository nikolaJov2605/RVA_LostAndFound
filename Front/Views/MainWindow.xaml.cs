using Common.Services;
using Front.Commands;
using Front.Model;
using Front.SearchCriterias;
using Front.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;

namespace Front.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IClientNotification
    {
        private static MainWindow mainWindowInstance;
        private bool busy = false;

        private MainWindow()
        {
            InitializeComponent();
            DataContext = new MainDataViewModel();
            dataGridItems.ItemsSource = LoadItemsInfo.LoadItems();
        }

        private MainWindow(string username) : base()
        {
            InitializeComponent();
            DataContext = new MainDataViewModel(username);
            dataGridItems.ItemsSource = LoadItemsInfo.LoadItems();
            
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
            mainWindowInstance.dataGridItems.ItemsSource = null;
            mainWindowInstance.dataGridItems.ItemsSource = MainDataViewModel.Items;
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
    }
}
