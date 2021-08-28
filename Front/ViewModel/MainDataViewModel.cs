using Common;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Front.ViewModel
{
    public class MainDataViewModel
    {
        public PersonModel Person { get; set; }
        private static ObservableCollection<ItemModel> items;

        public static ObservableCollection<ItemModel> Items
        {
            get { return items; }
            set { items = value; }
        }

        public MainDataViewModel()
        {
            items = new ObservableCollection<ItemModel>(LoadItemsInfo.LoadItems());
        }
        
        public MainDataViewModel(string username)
        {
            PersonModel person = LoadLoggedPerson.LoadPerson(username);
            Person = person;
            //items = new ObservableCollection<ItemModel>(LoadItemsInfo.LoadItems());
           // UpdateGrid();
        }

       /* public static void UpdateGrid()
        {
            items = new ObservableCollection<ItemModel>(LoadItemsInfo.LoadItems());
        }*/

    }
}
