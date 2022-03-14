using Minder.Model;

namespace Minder.Interface
{
    public interface IDiscoverySettingRepository
    {
        void Create(DiscoverySetting discoverySettings);
        DiscoverySetting Update(DiscoverySetting discoverySettings);
        void Delete(DiscoverySetting discoverySettings);
        DiscoverySetting FindByUserId(int userId);
    }
}