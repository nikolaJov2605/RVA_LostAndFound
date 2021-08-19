using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Front
{
    public static class FieldValidation
    {
        public static bool Validate(string field, string defaultVal)
        {
            bool isValid = true;
            if(String.IsNullOrEmpty(field) || field == defaultVal)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
