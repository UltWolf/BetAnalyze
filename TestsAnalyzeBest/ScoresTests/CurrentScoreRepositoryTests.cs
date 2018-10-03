using AnalizeBet.Models.Matches;
using AnalizeBet.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestsAnalyzeBest.ScoresTests
{
    public class CurrentScoreRepositoryTests
    {
        [Fact]
        public void GetStat() {
            CurrentScoreRepository<CurrentMatches> CSP = new CurrentScoreRepository<CurrentMatches>();
             CSP.ParseFromTemplate(new AnalizeBet.Models.Authorization.UnLocal.MyScore.MyScoreRequest("https://d.myscore.com.ua/x/feed/d_st_bTwPSkPs_ru_1", "_ga=GA1.3.2111981245.1536354321; _gid=GA1.3.1135452817.1538327369; _dc_gtm_UA-821699-48=1; _gat_UA-821699-48=1", "SW9D1eZo"));
        }
    }
}
