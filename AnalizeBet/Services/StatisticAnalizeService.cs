using AnalizeBet.Models.Matches;
using AnalizeBet.Models.Matches.Basic;
using AnalizeBet.Services.Extensions;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalizeBet.Services
{
    public class StatisticAnalizeService
    {
        #region ArrayParametres
        private static string[] HitsInGoal = new string[2];
        private static string[] HaveBall = new string[2];
        private static string[] Hits = new string[2];
        private static string[] Standarts = new string[2];
        private static string[] Corners = new string[2];
        private static string[] OffSides = new string[2];
        private static string[] Throwing = new string[2];
        private static string[] Saves = new string[2];
        private static string[] Fols = new string[2];
        private static string[] Yellow_Card = new string[2];
        private static string[] RedCard = new string[2];
        #endregion
        public static Stat GetStatistic(IElement template)
        {

            HitsInGoal = getValueByStatName(template, "Удары в створ");
            HaveBall = getValueByStatName(template, "Владение мячом");
            Hits = getValueByStatName(template, "Удары");
            Standarts = getValueByStatName(template, "Штрафные");
            Corners = getValueByStatName(template, "Угловые");
            OffSides = getValueByStatName(template, "Офсайды");
            Throwing = getValueByStatName(template, "Вбрасывания");
            Saves = getValueByStatName(template, "Сэйвы");
            Fols = getValueByStatName(template, "Фолы");
            Yellow_Card = getValueByStatName(template, "Желтые карточки");
            RedCard = getValueByStatName(template, "Красные карточки");
            //Statistic home team
            OrdinaryStatTeam FOST = new OrdinaryStatTeam();
            FOST = SetForTeam(FOST, 0);
            // Statistic guest team
            OrdinaryStatTeam SOST = new OrdinaryStatTeam();
            SOST = SetForTeam(SOST, 1);
            return new Stat(FOST, SOST);
        }

        private static OrdinaryStatTeam SetForTeam(OrdinaryStatTeam teamstat, int number)
        {
            teamstat.SetCornersByArray(Corners, number);
            teamstat.SetFallsByArray(Fols, number);
            teamstat.SetHitsByArray(Hits, number);
            teamstat.SetHitsInGoadByArray(HitsInGoal, number);
            teamstat.SetOffsidesByArray(OffSides, number);
            teamstat.SetStandartsByArray(Standarts, number);
            teamstat.SetYellowCardByArray(Yellow_Card, number);
            teamstat.SetProcentToHavingBallByArray(HaveBall, number);
            teamstat.SetRedCardsByArray(RedCard, number);
            return teamstat;

        }
        private static string[] getValueByStatName(IElement template, string statName)
        {
            foreach (var chil in template.Children)
            {

                var result = chil.Children[0].getInArrayFromDoc(1).toStringArray();
                if (result[0] == statName)
                {

                    return chil.Children[0].getInArrayFromDoc(0, 2).toStringArray();
                }
            }

            return new string[1];
        }

    }
}
