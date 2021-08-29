using Common;
using Front.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front.ViewModel
{
    public class PeopleViewModel
    {
        public static ObservableCollection<PersonModel> People { get; set; }
        public static PersonModel Person { get; set; }

        public PeopleViewModel()
        {
            People = new ObservableCollection<PersonModel>(LoadPeopleInfo.LoadPeople());
        }
    }
}
