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
    /// Interaction logic for ModifyUser.xaml
    /// </summary>
    public partial class ModifyUser : Window
    {
        private static ModifyUser instance;
        private ModifyUser()
        {
            InitializeComponent();
        }

        private ModifyUser(string username) : base()
        {
            InitializeComponent();
            DataContext = new MainDataViewModel(username);
        }

        public static ModifyUser Instance(string username)
        {
            if (instance == null)
                instance = new ModifyUser(username);
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
    }
}
