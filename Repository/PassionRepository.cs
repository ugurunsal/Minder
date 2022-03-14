using Minder.Interface;
using Minder.Model;

namespace Minder.Repository
{
    public class PassionRepository : IPassionRepository
    {
        private readonly MinderDBContext _context;

        public PassionRepository(MinderDBContext context)
        {
            _context = context;
        }
        public void Create(Passion passion)
        {
            _context.Passions.Add(passion);
            _context.SaveChanges();
        }

        public void Delete(Passion passion)
        {
            _context.Passions.Remove(passion);
            _context.SaveChanges();
        }

        public List<Passion> GetAll()
        {
            return _context.Passions.ToList();
        }

        public Passion GetByName(string name)
        {
            return _context.Passions.FirstOrDefault(p=>p.Name==name);
        }

        public Passion Update(Passion passion)
        {
            _context.Passions.Update(passion);
            _context.SaveChanges();
            return passion;
        }
    }
}