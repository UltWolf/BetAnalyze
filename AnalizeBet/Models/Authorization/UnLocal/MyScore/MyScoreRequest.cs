using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalizeBet.Models.Authorization.UnLocal.MyScore
{
    public class MyScoreRequest
    {
        public MyScoreRequest(string href,
                              string cookie,
                               string sign) {
            this.href = href;
            this.X_Fsign = sign;
            this.Cookie = cookie;
        }
        public readonly string href;
        public readonly string Cookie;
        public readonly string X_Fsign;
    }
}
