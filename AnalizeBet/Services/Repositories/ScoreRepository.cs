
using AnalizeBet.Services.Repositories.Basic;

namespace AnalizeBet.Services.Repositories
{
    public class ScoreRepository<ScoreMatches> : IRepositories<ScoreMatches>
    {
        bool IRepositories<ScoreMatches>.AddElement(ScoreMatches element)
        {
            throw new System.NotImplementedException();
        }

        bool IRepositories<ScoreMatches>.FindElement(string[] args)
        {
            throw new System.NotImplementedException();
        }

        ScoreMatches IRepositories<ScoreMatches>.GetElement(string[] args)
        {
            throw new System.NotImplementedException();
        }
    }
}
