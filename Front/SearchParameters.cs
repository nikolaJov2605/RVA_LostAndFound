using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front
{
    public class SearchParameters
    {
        public SearchParameters(string textParameter)
        {
            TextParameter = textParameter;
        }
        public SearchParameters(DateTime param1, DateTime param2)
        {
            DateTimeParameter1 = param1;
            DateTimeParameter2 = param2;
        }
        public string TextParameter { get; set; }
        public DateTime DateTimeParameter1 { get; set; }
        public DateTime DateTimeParameter2 { get; set; }
    }
}
