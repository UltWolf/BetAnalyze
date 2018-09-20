using System;
using System.ComponentModel.DataAnnotations;
using AnalizeBet.Models.Matches.Basic;

namespace AnalizeBet.Models
{
    public class ScoreMatches:BasicMatches
    {
        public ScoreMatches() { }
        
        public DateTime Time { get; set; }
      
        public Data.EnumResult Result { get; set; }
        
    }
}
