using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalizeBet.Services.Extensions
{

    public static class StringArrayExtension
    {
        public static string[] getFromCell(this string[] sameArray, params int[] cellsNumber)
        {
            string[] returningArray = new string[cellsNumber.Length];
            for (int i = 0; i < cellsNumber.Length; i++)
            {

                returningArray[i] = sameArray[cellsNumber[i]];
            }
            return returningArray;

        }
        public static string[] DeleteAddingScores(this string[] array)
        {
            string[] scores = new string[2];
            for (int i = 0; i < 2; i++)
            {
                if (array[i].Contains("("))
                {

                    scores[i] = array[i].Split("(")[0];
                }
                else
                {
                    scores[i] = array[i];
                }
            }
            return scores;

        }
        public static int[] ToInt(this string[] array)
        {
            int[] numberArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                numberArray[i] = int.Parse(array[i]);
            }
            return numberArray;
        }
    }
}
