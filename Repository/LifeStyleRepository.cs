using Minder.Interface;
using Minder.Model;

namespace Minder.Repository
{
    public class LifeStyleRepository : ILifeStyleRepository
    {
        private readonly MinderDBContext _context;

        public LifeStyleRepository(MinderDBContext context)
        {
            _context = context;
        }
        public void Create(LifeStyle lifeStyle)
        {
            _context.LifeStyles.Add(lifeStyle);
            _context.SaveChanges();
        }

        public void Delete(LifeStyle lifeStyle)
        {
            _context.LifeStyles.Remove(lifeStyle);
            _context.SaveChanges();
        }

        public LifeStyle FindByUserId(int userId)
        {
            LifeStyle lifeStyleByUserId = (from x in _context.LifeStyles
                           where x.UserId == userId
                           select x).FirstOrDefault();
            return lifeStyleByUserId;
        }

        public LifeStyle Update(LifeStyle lifeStyle)
        {
            _context.LifeStyles.Update(lifeStyle);
            _context.SaveChanges();
            return lifeStyle;
        }
    }
}