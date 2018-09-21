 using System.Collections.Generic;
 using System.Linq;
 using System.Threading.Tasks;
 using System;
 using AnalizeBet.Models.Matches.Basic;

 namespace AnalizeBet.Models.Matches {
     public class CurrentMatches : BasicMatches {
         public Stat statist { get; set; }
         public DateTime TimeToEnd { get; set; }

     }
 }