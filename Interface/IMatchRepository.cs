using Minder.Model;

namespace Minder.Interface
{
    public interface IMatchRepository
    {
        void Add(Match match);
        void Update(Match match);
        void Delete(Match match);
        List<Match> GetMatchesByUserId(int userId);
        Match GetMatchByIdies(int userId,int matchedUserId);
    }
}