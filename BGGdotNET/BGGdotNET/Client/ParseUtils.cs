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

        public static bool stringToBool(string input)
        {
            bool result = false;

            try
            {
                result = Boolean.Parse(input);
            }
            catch
            {
                result = false;
            }
            
            return true;
        }

        public static float setingToFloat(string p)
        {
            float result = 0;

            try
            {
                result = float.Parse(p);
            }
            catch
            {
                result = 0;
            }

            return result;
        }

        public static int stringToInt(string p)
        {
            int result = 0;

            try
            {
                result = int.Parse(p);
            }
            catch
            {
                result = 0;
            }

            return result;
        }
    }
}
