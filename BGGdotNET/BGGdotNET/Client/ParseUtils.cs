using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BGGdotNET.Client
{
    public static class ParseUtils
    {
        public static DateTime stringToDateTime(string input)
        {
            DateTime result = new DateTime();

            try
            {
                result = DateTime.Parse(input);
            }
            catch
            {
                result = DateTime.MinValue;
            }

            return result;
        }
    }
}
