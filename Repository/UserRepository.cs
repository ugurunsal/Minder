using Microsoft.EntityFrameworkCore;
using Minder.Interface;
using Minder.Model;

namespace Minder.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MinderDBContext _context;

        public UserRepository(MinderDBContext context)
        {
            _context = context;
        }
        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User FindById(int id)
        {
            var userByID = (from x in _context.Users.Include(e=>e.DiscoverySettings)
                           where x.Id == id
                           select x).FirstOrDefault();
            return userByID;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}