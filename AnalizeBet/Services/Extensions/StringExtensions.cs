using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalizeBet.Services.Extensions
{
    public static class StringExtension
    {

        public static string Delete(this string sameWord, string nameDeleteWord)
        {
            return sameWord.Replace(nameDeleteWord, "");

        }
        public static int ToInt(this string word)
        {
            if (word != null)
            {
                if (word.Contains("%")) {

                    return int.Parse(word.Delete("%"));
                }
                return int.Parse(word);
            }
            else
            {
                return 0;
            }
        }
    }
}
