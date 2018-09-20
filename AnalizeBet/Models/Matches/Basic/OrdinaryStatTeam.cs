namespace AnalizeBet.Models.Matches.Basic
{
    public struct OrdinaryStatTeam
    {
        #region parametress
        private readonly double _procentToHavingTimeBall;
        private readonly double? _hitsOnGoal;
        private readonly double? _hitsInGoal;
        private readonly double? _hitsMiss;
        private readonly double? _saves;
        private readonly double? _falls;
        private readonly double? _corners;
        private readonly double? _offsides;
        private   double? _yellowCards;
        private   double? _redCards;
        #endregion

        public OrdinaryStatTeam(double procentToHavingTimeBall,double?  hitsInGoal, 
                                double? hitsMiss,    double?  hitsOnGoal,
                                double? corners,     double?  saves,    double?  falls,
                                double?  yellowCards,double?  redCards, double?  offsides ){
            _procentToHavingTimeBall  =procentToHavingTimeBall  ;
             _yellowCards =  yellowCards?? 0;
             _redCards  = redCards??0;
             _corners = corners??0;
             _falls = falls??0;
             _hitsInGoal = hitsInGoal??0;
             _hitsMiss = hitsMiss??0;
             _hitsOnGoal =  hitsMiss??0;
             _offsides =  offsides??0;
             _saves = offsides ??0;
            
       }
 
    }
    public static class OrdinaryStatTeamExtension{
         public static double GetProcentToWin(this OrdinaryStatTeam firstTeam, OrdinaryStatTeam secondTeam ){
            throw new System.NotImplementedException();
        }
    }
}