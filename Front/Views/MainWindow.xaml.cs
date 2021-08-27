using Common;
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
    public partial class MainWindow : Window
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

        private void dataGridItems_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            dataGridItems.ItemsSource = MainDataViewModel.Items;
        }
    }
}
