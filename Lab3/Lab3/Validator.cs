using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Validator
    {
        public bool IsNumber(string text)
        {
            bool result = false;
            try
            {
                Convert.ToInt32(text);
                result = true;
            }
            catch (Exception exc) { }

            return result;
        }
    }
}
