using Common;
using Common.Services;
using Front.Commands;
using Front.Model;
using Front.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IClientNotification
    {
        private static MainWindow mainWindowInstance;

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
            MainDataViewModel.Items = LoadItemsInfo.LoadItems();
            mainWindowInstance.dataGridItems.ItemsSource = null;
            mainWindowInstance.dataGridItems.ItemsSource = MainDataViewModel.Items;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            DeleteInstance();
        }
    }
}
