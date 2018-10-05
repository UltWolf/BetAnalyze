using AnalizeBet.Services;
using Xunit;

namespace TestsAnalyzeBest.TestsServices
{
    public class MyScoreServiceTests
    {
        [Fact]
        public static void GetHrefFromServices() {
            Assert.Equal( "QNFzlSzS", MyScoreServices.GetIdMatch("https://www.myscore.com.ua/match/QNFzlSzS/#match-summary") );
        }

    }
}
