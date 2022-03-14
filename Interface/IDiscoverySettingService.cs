using Minder.Model;

namespace Minder.Interface
{
    public interface IDiscoverySettingService
    {
        void Create(DiscoverySetting discoverySetting);
        DiscoverySetting Update(DiscoverySetting discoverySetting);
        void Delete(DiscoverySetting discoverySetting);
        DiscoverySetting FindByUserId(int userId);
    }
}