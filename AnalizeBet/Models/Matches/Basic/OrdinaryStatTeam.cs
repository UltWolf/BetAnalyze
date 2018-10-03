using AnalizeBet.Services.Extensions;

namespace AnalizeBet.Models.Matches.Basic
{
    public struct OrdinaryStatTeam
    {
        #region parametress
        public double _procentToHavingTimeBall;
        public double? _hitsOnGoal;
        private double? _hitsInGoal;
        private double? _hitsMiss;
        private double? _standarts;
        private double? _saves;
        private double? _falls;
        private double? _corners;
        private double? _offsides;
        private double? _yellowCards;
        public double? _redCards;
        #endregion
        #region Sets
        public void SetHitsInGoadByArray(string[] array, int number_team)
        {
            if (array[0] != null)
            {
                this._hitsInGoal = array[number_team].ToInt();
            }
        }
        public void SetProcentToHavingBallByArray(string[] array, int number_team)
        {
            if (array[0] != null)
            {
                this._procentToHavingTimeBall = array[number_team].ToInt();
            }
        }
        public void SetHitsByArray(string[] array, int number_team)
        {
            if (array[0] != null)
            {
                this._hitsOnGoal = array[number_team].ToInt();
            }
        }
        public void SetHitsMissByArray(string[] array, int number_team)
        {
            if (array[0] != null)
            {
                this._hitsMiss = array[number_team].ToInt();
            }
        }
        public void SetSavesByArray(string[] array, int number_team)
        {
            if (array[0] != null)
            {
                this._saves = array[number_team].ToInt();
            }
        }
        public void SetFallsByArray(string[] array, int number_team)
        {
            if (array[0] != null)
            {
                this._falls = array[number_team].ToInt();
            }
        }
        public void SetCornersByArray(string[] array, int number_team)
        {
            if (array[0] != null)
            {
                this._corners = array[number_team].ToInt();
            }
        }
        public void SetOffsidesByArray(string[] array, int number_team)
        {
            if (array[0] != null)
            {
                this._offsides = array[number_team].ToInt();
                }
        }
        public void SetYellowCardByArray(string[] array, int number_team)
        {
            if (array[0] != null)
            {
                this._yellowCards = array[number_team].ToInt();
            }
        }
        public void SetRedCardsByArray(string[] array, int number_team)
        {
            if (array[0] != null)
            {
                this._redCards = array[number_team].ToInt();
            }
        }
        public void SetStandartsByArray(string[] array, int number_team)
        {
            if (array[0] != null)
            {
                this._standarts = array[number_team].ToInt();
            }
            }

        #endregion
        //experimental method
        public double EqualingForExecuteProcent(double? firstArgue, double? secondArgue, string statement)
        {

            switch (statement)
            {
                case "HaveBall":
                    if (firstArgue - secondArgue <= -20)
                    {
                        return -2;
                    }
                    else if (firstArgue - secondArgue <= -10)
                    {
                        return -1;
                    }
                    else if ((firstArgue - secondArgue <= -10) && (firstArgue - secondArgue <= 10))
                    {
                        return 0;
                    }
                    else if (firstArgue - secondArgue <= 10)
                    {
                        return 1;
                    }
                    else
                    {
                        return 2;
                    }

                case "HitsOnGoal":
                    try
                    {
                        if (firstArgue / secondArgue < 1)
                        {
                            return 0;
                        }
                        else if (firstArgue / secondArgue < 2)
                        {
                            return 1;
                        }
                        else { return 2; }
                    }
                    catch (System.DivideByZeroException er)
                    {
                        return 1;
                    };

                case "HitsInGoal":
                    if (firstArgue / secondArgue < 1)
                    {
                        return 0;
                    }
                    else if (firstArgue / secondArgue < 2)
                    {
                        return 1;
                    }
                    else { return 2; }

                case "redCards":
                    if (firstArgue > secondArgue)
                    {
                        return 2;
                    }
                    else if (firstArgue == secondArgue)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }

            }
            return 0;
        }
        public OrdinaryStatTeam(double procentToHavingTimeBall, double? hitsInGoal,
            double? hitsMiss, double? hitsOnGoal,
            double? corners, double? saves, double? falls,
            double? yellowCards, double? redCards,double? standarts, double? offsides)
        {
            _procentToHavingTimeBall = procentToHavingTimeBall;
            _yellowCards = yellowCards ?? 0;
            _redCards = redCards ?? 0;
            _corners = corners ?? 0;
            _falls = falls ?? 0;
            _hitsInGoal = hitsInGoal ?? 0;
            _hitsMiss = hitsMiss ?? 0;
            _hitsOnGoal = hitsMiss ?? 0;
            _offsides = offsides ?? 0;
            _saves = offsides ?? 0;
            _standarts = standarts ?? 0;

        }
       

    }
    public static class OrdinaryStatTeamExtension
    {
        private static double procentToWinCurrent = 0;
        private readonly static string _statementBall = "HaveBall";
        private readonly static string _statementHits = "HitsInGoal";
        private readonly static string _statementRedCards = "redCards";

        public static double GetProcentToWin(this OrdinaryStatTeam firstTeam, OrdinaryStatTeam secondTeam)
        {
            procentToWinCurrent += firstTeam.EqualingForExecuteProcent(firstTeam._procentToHavingTimeBall, secondTeam._procentToHavingTimeBall, _statementBall);
            procentToWinCurrent += firstTeam.EqualingForExecuteProcent(firstTeam._hitsOnGoal, secondTeam._hitsOnGoal, _statementHits);
            procentToWinCurrent += firstTeam.EqualingForExecuteProcent(firstTeam._redCards, secondTeam._redCards, _statementRedCards);
            return procentToWinCurrent;
        }
    }
}