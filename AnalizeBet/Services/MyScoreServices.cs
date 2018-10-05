using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalizeBet.Services
{
    public static class MyScoreServices
    {
        public static string GetIdMatch(string href) {
            string[] array = href.Split("/");
            for(var i=0;i<array.Length;i++){
                if (array[i] == "match") {
                    return array[++i];
                }
            }
            return null;
        }
    }
}
