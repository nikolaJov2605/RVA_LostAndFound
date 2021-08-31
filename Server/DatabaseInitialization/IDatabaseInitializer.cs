using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DatabaseInitialization
{
    public interface IDatabaseInitializer
    {
        void InitializeTable();
    }
}
