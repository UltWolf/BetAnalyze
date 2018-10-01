using AnalizeBet.Models;
using AnalizeBet.Services.Repositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace TestsAnalyzeBest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            ScoreRepository<ScoreMatches> SP = new ScoreRepository<ScoreMatches>();
            SP.GetScores(new AnalizeBet.Models.Authorization.UnLocal.MyScore.MyScoreRequest("https://d.myscore.com.ua/x/feed/d_hh_4p5YZuip_ru_1 ", "_ga = GA1.3.2111981245.1536354321; _gid = GA1.3.1507145647.1537804137; _dc_gtm_UA - 821699 - 48 = 1", "SW9D1eZo"));
        }
        [Fact]
        public void GetProcentToWinHome()
        {
            ScoreRepository<ScoreMatches> SP = new ScoreRepository<ScoreMatches>();
            Dictionary<string, List<ScoreMatches>> dict =  SP.GetScores(new AnalizeBet.Models.Authorization.UnLocal.MyScore.MyScoreRequest("https://d.myscore.com.ua/x/feed/d_hh_hpx9xJhF_ru_1 ", "_ga = GA1.3.2111981245.1536354321; _gid = GA1.3.1507145647.1537804137; _dc_gtm_UA - 821699 - 48 = 1", "SW9D1eZo"));
            Assert.Equal("68.42",SP.GetProcent(dict["Home"], "Лион").ToString());
             
        }
        [Fact]
        public void GetProcentToWinGuest()
        {
            ScoreRepository<ScoreMatches> SP = new ScoreRepository<ScoreMatches>();
            Dictionary<string, List<ScoreMatches>> dict = SP.GetScores(new AnalizeBet.Models.Authorization.UnLocal.MyScore.MyScoreRequest("https://d.myscore.com.ua/x/feed/d_hh_hpx9xJhF_ru_1 ", "_ga = GA1.3.2111981245.1536354321; _gid = GA1.3.1507145647.1537804137; _dc_gtm_UA - 821699 - 48 = 1", "SW9D1eZo"));
            Assert.Equal("68.42", SP.GetProcent(dict["Guest"], "Шахтер Донецк").ToString());
            
        }
        [Fact]
        public void GetAllProcentToWin() {
            ScoreRepository<ScoreMatches> SP = new ScoreRepository<ScoreMatches>();
            Dictionary<string, List<ScoreMatches>> dict = SP.GetScores(new AnalizeBet.Models.Authorization.UnLocal.MyScore.MyScoreRequest("https://d.myscore.com.ua/x/feed/d_hh_hpx9xJhF_ru_1 ", "_ga = GA1.3.2111981245.1536354321; _gid = GA1.3.1507145647.1537804137; _dc_gtm_UA - 821699 - 48 = 1", "SW9D1eZo"));
            if (dict.ContainsKey("Mutual"))
            {
                float[] allscoresProcent = new float[] { SP.GetProcent(dict["Guest"], "Шахтер Донецк"), SP.GetProcent(dict["Home"], "Лион"), SP.GetProcent(dict["Mutual"] , "Лион") };
                Assert.Equal(SP.getTotalProcentForWin(allscoresProcent) > 50, true);
            }
            else {
                float[] allscoresProcent = new float[] {  SP.GetProcent(dict["Home"], "Лион") ,SP.GetProcent(dict["Guest"], "Шахтер Донецк")  };
                Assert.Equal(SP.getTotalProcentForWin(allscoresProcent) > 50, true);
            }

        }
    }
}
