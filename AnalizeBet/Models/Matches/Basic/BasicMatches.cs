using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalizeBet.Models.Matches.Basic
{
    public class BasicMatches
    {
        [Key]
        public string ID { get; set; }
        public string League { get; set; }
        public int FirstScore { get; set; }
        public int SecondScore { get; set; }
        public string FirstTeam { get; set; }
        public string SecondTeam { get; set; }
        public double ProcentToWin { get; set; }
    }
}
