using System;
using System.ComponentModel.DataAnnotations;
using AnalizeBet.Models.Matches.Basic;

namespace AnalizeBet.Models {
    public class ScoreMatches : BasicMatches,IScoreInterface {
        public ScoreMatches () { }

        public DateTime Time { get; set; }

        public Data.EnumResult Result { get; set; }

        public decimal GetProcentFromBetService(string Href)
        {
            throw new NotImplementedException();
        }

        public decimal GetProcentToWin(string  nameTeam)
        {
            throw new NotImplementedException();
            decimal procent = 0;
            if (this.FirstTeam == nameTeam)
            {
                return (FirstScore - SecondScore) % 5;
            }
            else {
                return (SecondScore - FirstScore) % 5;
            }

             
        }

    

    }
}