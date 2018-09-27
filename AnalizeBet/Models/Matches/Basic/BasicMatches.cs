using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnalizeBet.Models.Matches.Basic
{
    public abstract class BasicMatches
    {
        [Key]
        public string ID { get; set; }
        public string League { get; private set; }
        public int FirstScore { get; private set; }
        public int SecondScore { get; private set; }
        public string FirstTeam { get; private set; }
        public  string SecondTeam { get;private  set; }
 

        public void SetScore(int[] args)
        {
            this.FirstScore = args[0];
            this.SecondScore = args[1];
        }
        public void SetTeam(string firstTeam, string secondTeam)
        {
            this.FirstTeam = firstTeam;
            this.SecondTeam = secondTeam;
 
        }
    }
}
