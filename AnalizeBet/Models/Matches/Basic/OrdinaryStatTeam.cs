namespace AnalizeBet.Models.Matches.Basic {
        public struct OrdinaryStatTeam {
            #region parametress
            public readonly double _procentToHavingTimeBall;
            public readonly double? _hitsOnGoal;
            private readonly double? _hitsInGoal;
            private readonly double? _hitsMiss;
            private readonly double? _saves;
            private readonly double? _falls;
            private readonly double? _corners;
            private readonly double? _offsides;
            private double? _yellowCards;
            public double? _redCards;
            #endregion
            //experimental method
            public double EqualingForExecuteProcent (double? firstArgue, double? secondArgue, string statement) {

                switch (statement) {
                    case HaveBall:
                        if (firstArgue - secondArgue <= -20) {
                            return -2;
                        } else if (firstArgue - secondArgue <= -10) {
                            return -1;
                        } else if ((firstArgue - secondArgue <= -10) && (firstArgue - secondArgue <= 10)) {
                            return 0;
                        } else if (firstArgue - secondArgue <= 10) {
                            return 1;
                        } else {
                            return 2;
                        }

                    case HitsOnGoal:
                        try {
                            if (firstArgue / secondArgue < 1) {
                                return 0;
                            } else if (firstArgue / secondArgue < 2) {
                                return 1;
                            } else { return 2; } catch (System.DivideByZeroException er) {
                                return 1
                            };

                            case HitsInGoal:
                                if (firstArgue / secondArgue < 1) {
                                    return 0;
                                } else if (firstArgue / secondArgue < 2) {
                                    return 1;
                                } else { return 2; } catch (System.DivideByZeroException er) {
                                    return 1
                                };

                            case redCards:
                                if (firstArgue > secondArgue) {
                                    return 2;
                                } else if { firstArgue == secondArgue } {
                                    return 1;
                                } else {
                                    return 0;
                                }

                        }
                }
                public OrdinaryStatTeam (double procentToHavingTimeBall, double? hitsInGoal,
                    double? hitsMiss, double? hitsOnGoal,
                    double? corners, double? saves, double? falls,
                    double? yellowCards, double? redCards, double? offsides) {
                    _procentToHavingTimeBall = procentToHavingTimeBall;
                    _yellowCards = yellowCards?? 0;
                    _redCards = redCards??0;
                    _corners = corners??0;
                    _falls = falls??0;
                    _hitsInGoal = hitsInGoal??0;
                    _hitsMiss = hitsMiss??0;
                    _hitsOnGoal = hitsMiss??0;
                    _offsides = offsides??0;
                    _saves = offsides ?? 0;

                }

            }
            public static class OrdinaryStatTeamExtension {
                private static double procentToWinCurrent = 0;
                private readonly static string _statementBall = "HaveBall";
                private readonly static string _statementHits = "HitsInGoal";
                private readonly static string _statementRedCards = "redCards";

                public static double GetProcentToWin (this OrdinaryStatTeam firstTeam, OrdinaryStatTeam secondTeam) {
                    procentToWinCurrent += firstTeam.EqualingForExecuteProcent (firstTeam._procentToHavingTimeBall, secondTeam._procentToHavingTimeBall, statementBall);
                    procentToWinCurrent += firstTeam.EqualingForExecuteProcent (firstTeam._hitsOnGoal, secondTeam._hitsOnGoal, _statementHits);
                    procentToWinCurrent += firstTeam.EqualingForExecuteProcent (firstTeam._redCards, secondTeam._redCardsl, _statementRedCards);
                    return procentToWinCurrent;
                }
            }
        }