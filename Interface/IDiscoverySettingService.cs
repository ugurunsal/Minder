using Minder.DTO;
using Minder.Model;

namespace Minder.Interface
{
    public interface IDiscoverySettingService
    {
        BaseResponse<DiscoverySetting> Create(DiscoverySetting discoverySetting);
        BaseResponse<DiscoverySetting> Update(DiscoverySetting discoverySetting);
        BaseResponse<string> Delete(DiscoverySetting discoverySetting);
        BaseResponse<DiscoverySetting> FindByUserId(int userId);
    }
}