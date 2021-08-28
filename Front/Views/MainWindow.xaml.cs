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
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(string username) : base()
        {
            InitializeComponent();
            DataContext = new MainDataViewModel(username);
            
        }


        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            AddItem addItemWindow = new AddItem(lblUsername.Content.ToString());
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
            //dataGridItems.ItemsSource = MainDataViewModel.Items;
            //dataGridItems.Items.Refresh();
            dataGridItems.ItemsSource = MainDataViewModel.Items;
            dataGridItems.Items.Refresh();
           // dataGridItems.Items.Refresh();
        }
    }
}
