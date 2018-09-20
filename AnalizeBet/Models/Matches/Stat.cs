using AnalizeBet.Models.Matches.Basic;

namespace AnalizeBet.Models.Matches
{
    public class Stat
    {
        private readonly double ProcentToStartMatch ;
        private OrdinaryStatTeam firstTeam{get;set;}
        private OrdinaryStatTeam secondTeam{get;set;}
        public double CurrentProcent{get;private set;}
        private double _currentProcent;
        public Stat(OrdinaryStatTeam ft,OrdinaryStatTeam st, double Procent ){
            this.firstTeam  = ft;
            this.secondTeam  = st;
            ProcentToStartMatch  = Procent;
        }
        


    }
}