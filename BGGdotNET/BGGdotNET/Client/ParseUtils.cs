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
                result = DateTime.Parse(input);  //FORMAT:  Tue, 03 Nov 2009 17:11:22 +0000
            }
            catch(Exception e)
            {
                result = DateTime.MinValue;
            }

            return result;
        }
    }
}
