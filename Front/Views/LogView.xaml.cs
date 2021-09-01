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
    /// Interaction logic for LogView.xaml
    /// </summary>
    public partial class LogView : Window
    {
        private static LogView instance;

        public static LogView Instance()
        {
            if (instance == null)
                instance = new LogView();
            return instance;
        }

        public static void DeleteInstance()
        {
            instance = null;
        }

        private LogView()
        {
            InitializeComponent();

            DataContext = new LoggerViewModel();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            dataGridLog.ItemsSource = null;
            dataGridLog.ItemsSource = LoadLogger.LoadLogHistory();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            DeleteInstance();
        }
    }
}
