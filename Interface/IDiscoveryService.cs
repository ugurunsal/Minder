using Minder.DTO;

namespace Minder.Interface
{
    public interface IDiscoveryService
    {
        BaseResponse<List<DiscoveryUserDTO>> Discovery(int userId);
        BaseResponse<DiscoveryUserDTO> Like(int userId, int likedUserId);
    }
}