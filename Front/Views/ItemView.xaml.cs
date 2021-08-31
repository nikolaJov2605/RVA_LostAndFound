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
    /// Interaction logic for ItemView.xaml
    /// </summary>
    public partial class ItemView : Window
    {
        private static ItemView instance;

        public static ItemView Instance()
        {
            if (instance == null)
                instance = new ItemView();
            return instance;
        }

        public static void DeleteInstance()
        {
            instance = null;
        }


        private ItemView()
        {
            InitializeComponent();
            DataContext = new ItemViewModel();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            DeleteInstance();
        }
    }
}
