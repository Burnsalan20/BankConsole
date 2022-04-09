using System;
using System.Collections.Generic;
using System.Text;

namespace BankConsole
{
    public class Utils
    {

        public static bool IsNumeric(string value)
        {
            int test;
           // Console.WriteLine(int.TryParse(value, out test));
            return Int32.TryParse(value, out test);
        }

        public static bool IsValidName(string name)
        {
            if(name.Length > 10) return false;

            return true;
        }

    }
}
