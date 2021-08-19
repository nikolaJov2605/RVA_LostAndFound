using Common;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.ViewModel
{
    public class MainDataViewModel
    {
        public PersonModel Person { get; set; }
        public ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>(LoadItemsInfo.LoadItems());

        public MainDataViewModel(string username)
        {
            PersonModel person = LoadLoggedPerson.LoadPerson(username);
            Person = person;

            //Items = new ObservableCollection(LoadItemsInfo.LoadItems());
        }
    }
}
