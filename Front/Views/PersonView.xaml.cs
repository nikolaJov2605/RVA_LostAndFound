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
    /// Interaction logic for PersonView.xaml
    /// </summary>
    public partial class PersonView : Window
    {
        private static PersonView instance;

        public static PersonView Instance()
        {
            if (instance == null)
                instance = new PersonView();
            return instance;
        }

        public static void DeleteInstance()
        {
            instance = null;
        }

        private PersonView()
        {
            InitializeComponent();
            DataContext = new PeopleViewModel();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            DeleteInstance();
        }
    }
}
