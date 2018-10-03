using AnalizeBet.Models.Authorization.UnLocal.MyScore;
using AnalizeBet.Services.Repositories.Basic;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AnalizeBet.Services
{
    public class CurrentScoreRepository<CurrentMatches> : IRepositories<CurrentMatches>
    {
        bool IRepositories<CurrentMatches>.AddElement(CurrentMatches element)
        {
            throw new NotImplementedException();
        }

        bool IRepositories<CurrentMatches>.FindElement(string[] args)
        {
            throw new NotImplementedException();
        }

        CurrentMatches IRepositories<CurrentMatches>.GetElement(string[] args)
        {
            throw new NotImplementedException();
        }
        public Models.Matches.CurrentMatches ParseFromTemplate(MyScoreRequest requestData) {
            WebClient wc = new WebClient();
            wc.Headers.Add(HttpRequestHeader.Cookie, requestData.Cookie);
            wc.Headers.Add("X-Fsign", requestData.X_Fsign);

            wc.Headers.Add("Accept-Language", "ru-RU,ru;q=0.8,en-US;q=0.5,en;q=0.3");
            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            string html = wc.DownloadString(requestData.href);

            IHtmlDocument angle = new HtmlParser().Parse(html);
            var statContent = angle.QuerySelectorAll(" .statContent")[0];
            StatisticAnalizeService.GetStatistic(statContent);

            return new Models.Matches.CurrentMatches();
        }
         
    }
}
