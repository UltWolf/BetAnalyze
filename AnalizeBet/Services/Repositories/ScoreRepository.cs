
using AnalizeBet.Services.Repositories.Basic;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System.Net;
using System.Text;
using AnalizeBet.Models;
using AnalizeBet.Models.Authorization.UnLocal.MyScore;
using System.Linq;
using RestSharp;
using System.Collections.Generic;
using AngleSharp.Dom;

namespace AnalizeBet.Services.Repositories
{
    public class ScoreRepository<  ScoreMatches  > : IRepositories< ScoreMatches>
    {
        public bool  AddElement(ScoreMatches element)
        {
            throw new System.NotImplementedException();
        }

        public bool  FindElement(string[] args)
        {
            throw new System.NotImplementedException();
        }
        public Dictionary<string,List<Models.ScoreMatches>> GetScores(MyScoreRequest requestData)
        {

             
            WebClient wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.Cookie, requestData.Cookie);
            wc.Headers.Add("X-Fsign", requestData.X_Fsign);
 
            wc.Headers.Add ("Accept-Language", "ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3");
            wc.Headers.Add ("Content-Type", "application/x-www-form-urlencoded");
             
            wc.Headers.Add ("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            string html = wc.DownloadString( requestData.href);
          
            IHtmlDocument angle = new HtmlParser().Parse(html);
            
            List<Models.ScoreMatches> liHomeScores = new List<Models.ScoreMatches>();
            var scores = angle.getScoresTemplate(".h2h_home");
            liHomeScores = GetListScoreFromTemplate(scores);

            List<Models.ScoreMatches> liGuestScores = new List<Models.ScoreMatches>();
            var scoresGuest = angle.getScoresTemplate(" .h2h_away");
            liGuestScores = GetListScoreFromTemplate(scoresGuest);

            List<Models.ScoreMatches> ListMutualSccores = new List<Models.ScoreMatches>();
            var mutualScores = angle.getScoresTemplate(" .h2h_mutual");
            ListMutualSccores = GetListScoreFromTemplate(mutualScores);

            Dictionary<string, List<Models.ScoreMatches>> resultDict = new Dictionary<string, List<Models.ScoreMatches>>();
            resultDict.Add("Home",liHomeScores);
            resultDict.Add("Guest", liGuestScores);
            resultDict.Add("Mutual ",ListMutualSccores);
 
            // var trs =  tables[0].Children[0].Children[0].Children[0].TextContent;
            // var trs2 = tables[0].Children[0].Children[0].Children[2].TextContent;
 
            return resultDict;
            
        }


        public float getTotalProcentForWin(float[] procents ) {
            if (procents[0] < procents[1])
            {
                procents[0] -= 10;
            }
            else
            {
                procents[0] += 10;
            }
            if (procents.Length  >= 3)
            {
                if (procents[0] > procents[2])
                {

                    procents[0] += 10;
                }
            }
            return procents[0];

            }
        private List<Models.ScoreMatches> GetListScoreFromTemplate( IElement template) {

            List<Models.ScoreMatches> ListResult = new List<Models.ScoreMatches>(); 
            for (int i = 0; i < template.ChildElementCount - 2; i++)
            {
                Models.ScoreMatches SM = new Models.ScoreMatches();
                var matches = template.Children[i];
                string League = matches.Children[1].TextContent;
                string HomeTeam = matches.Children[2].TextContent;
                string EnemyTeam = matches.Children[3].TextContent;
                int[] result = matches.Children[4].TextContent.Split(":").DeleteAddingScores().ToInt();
                 
                SM.SetTeam(HomeTeam, EnemyTeam);
                SM.SetScore(result);
                ListResult.Add(SM);

            }
            return ListResult;

        }
        
        public float GetProcent (List<Models.ScoreMatches> scores,string nameTeam ){
 
            float win = 0;
            float draw = 0;
            float loose = 0;
            foreach (var score in scores)
            {
                if (score.FirstTeam == nameTeam)
                {
                    if (score.FirstScore > score.SecondScore)
                    {
                        win += 1;
                    }
                    else if (score.FirstScore == score.SecondScore)
                    {

                        draw += 1;
                    }
                    else {

                        loose += 1;
                    }
                     
                }
                else {
                    if (score.FirstScore > score.SecondScore)
                    {
                       loose += 1;
                    }
                    else if (score.FirstScore == score.SecondScore)
                    {

                        draw += 1;
                    }
                    else
                    {

                        win += 1;
                    }
                }
            }
            float procentToWin = (win / scores.Count) * 100  ;
            return procentToWin;
        }
        public  ScoreMatches GetElement(string[] args)
        {
            throw new System.NotImplementedException();
        }

       
    }
public static class IDocumentExtension {
    public static IElement getScoresTemplate(this IDocument angle, string element)
    {
        return angle.QuerySelectorAll(element)[1].Children[2];

    }
}
    public static class StringExtension {

        public static string Delete( this string sameWord,  string nameDeleteWord) {
            return sameWord.Replace(nameDeleteWord, "");

        }
    }

    public static class StringArrayExtension {
        public static string[] getFromCell(this string[] sameArray, params int[] cellsNumber)
        {
            string[] returningArray = new string[cellsNumber.Length ];
            for(int i = 0;i<cellsNumber.Length;i++){

                returningArray[i] = sameArray[cellsNumber[i]];
            }
            return returningArray;

        }
        public static string[] DeleteAddingScores(this string[] array) {
            string[] scores = new  string[2]   ;
            for (int i = 0; i < 2; i++)
            {
                if (array[i].Contains("("))
                {

                    scores[i] = array[i].Split("(")[0];
                }
                else
                {
                    scores[i] = array[i];
                }
            }
            return scores;

        }
        public static int[] ToInt(this string[] array) {
            int[] numberArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++) {
                numberArray[i] = int.Parse(array[i]);
            }
            return numberArray;
        }
    }
}
