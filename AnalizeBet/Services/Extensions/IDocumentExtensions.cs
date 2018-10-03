using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalizeBet.Services.Extensions
{
    public static class IDocumentExtension
    {
        public static IElement getScoresTemplate(this IDocument angle, string element)
        {
            return angle.QuerySelectorAll(element)[1].Children[2];

        }
        public static IElement[] getInArrayFromDoc(  this IElement angle, params int[] cells ){

            IElement[] resultArray = new IElement[cells.Length];
            
            for  (var i = 0;i<cells.Length;i++) { 

               resultArray[i] =  angle.Children[cells[i]];
                
                    }
            return resultArray;
         }
        public static string[] toStringArray(this IElement[] elements)
        {
             
            string[] resultArray = new string[elements.Length];
            for (var i = 0; i < elements.Length; i++)
            {
                resultArray[i] = elements[i].TextContent;
            }
            return resultArray;
        }

    }
}
