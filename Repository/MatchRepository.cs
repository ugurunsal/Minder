using Minder.Interface;
using Minder.Model;

namespace Minder.Repository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly MinderDBContext _context;

        public MatchRepository(MinderDBContext context)
        {
            _context = context;
        }

        public void Add(Match match)
        {
            _context.Matches.Add(match);
            _context.SaveChanges();
        }

        public void Update(Match match)
        {
            _context.Matches.Update(match);
            _context.SaveChanges();
        }

        public void Delete(Match match)
        {
            _context.Matches.Remove(match);
            _context.SaveChanges();
        }

        public List<Match> GetMatchesByUserId(int userId)
        {
            return _context.Matches.Where(u=>u.UserId==userId).ToList();
        }

        public Match GetMatchByIdies(int userId, int matchedUserId)
        {
            return _context.Matches.FirstOrDefault(u=>u.UserId==userId&&u.MatchedUserId==matchedUserId);
        }
    }
}