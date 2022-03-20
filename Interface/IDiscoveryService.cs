using Minder.DTO;

namespace Minder.Interface
{
    public interface IDiscoveryService
    {
        List<DiscoveryUserDTO> Discovery(int userId);
        DiscoveryUserDTO Like(int userId, int likedUserId);
    }
}