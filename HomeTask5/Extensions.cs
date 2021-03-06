using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeTask5
{
    public static class Extensions
    {
        private const string Vowels = "ауыоэяюиёе";

        public static int GetVowelsCount(this string str)
        {                                    
            int count = 0;
            foreach(var c in str)
            {
                if (Vowels.Contains(c, StringComparison.OrdinalIgnoreCase))
                    count++;
            }
            
            return count;
        }

        public static int Reverse(this int source)
        {
            var charArray = source.ToString().ToCharArray();
            Array.Reverse(charArray);
            return int.Parse(new string(charArray));
        }

        public static bool IsPolindrom(this string str)
        {
            var charArray = str.ToCharArray();
            Array.Reverse(charArray);
            var result=new string(charArray);

            str = str.Replace(" ", "");
            result = result.Replace(" ", "");
            if (str.Equals(result, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            else 
                return false;
        }

        public static string Remove(this string str, string[] toRemoveStrings)
        {            
            foreach(var toRemove in toRemoveStrings)
            {
                str = str.Replace(toRemove, "");
            }

            return str;
        }
    }
}
