using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalizeBet.Models.Matches.Basic
{
    public interface IScoreInterface
    {
        decimal GetProcentToWin(string NameTeam);
        decimal GetProcentFromBetService(string Href);
    }
}
