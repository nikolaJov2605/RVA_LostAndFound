using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class AppDBContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Item> Objects { get; set; }
    }
}
