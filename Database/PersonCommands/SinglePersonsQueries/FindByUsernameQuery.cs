using Common;
using Database.PersonsCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.PersonCommands.SinglePersonsQueries
{
    public class FindByUsernameQuery : SinglePersonQuery
    {
        private string username;

        public FindByUsernameQuery(string u)
        {
            username = u;
        }

        public override Person Execute()
        {
            AppDBContext context = new AppDBContext();

            try
            {
                var query = context.Persons.Where(x => x.Username == username).First<Person>();
                if (query != null)
                    return query;
            }
            catch
            {
                return null;
            }
            return null;
        }
    }
}
