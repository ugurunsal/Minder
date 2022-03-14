using Minder.Interface;
using Minder.Model;

namespace Minder.Repository
{
    public class DiscoverySettingRepository : IDiscoverySettingRepository
    {
        private readonly MinderDBContext _context;

        public DiscoverySettingRepository(MinderDBContext context)
        {
            _context = context;
        }
        public void Create(DiscoverySetting discoverySetting)
        {
            _context.DiscoverySettings.Add(discoverySetting);
            _context.SaveChanges();
        }

        public void Delete(DiscoverySetting discoverySettings)
        {
            _context.DiscoverySettings.Remove(discoverySettings);
            _context.SaveChanges();
        }

        public DiscoverySetting FindByUserId(int userId)
        {
            DiscoverySetting discoverySettingsByUserId = (from x in _context.DiscoverySettings
                           where x.UserId == userId
                           select x).FirstOrDefault();
            return discoverySettingsByUserId;
        }

        public DiscoverySetting Update(DiscoverySetting discoverySetting)
        {
            _context.DiscoverySettings.Update(discoverySetting);
            _context.SaveChanges();
            return discoverySetting;
        }
    }
}