using Minder.Interface;
using Minder.Model;

namespace Minder.Service
{
    public class DiscoverySettingService : IDiscoverySettingService
    {
        private readonly IDiscoverySettingRepository _discoverySettingRepository;
        private readonly IUserRepository _userRepository;

        public DiscoverySettingService(IDiscoverySettingRepository discoverySettingRepository, IUserRepository userRepository)
        {
            _discoverySettingRepository = discoverySettingRepository;
            _userRepository = userRepository;
        }

        public void Create(DiscoverySetting discoverySetting)
        {
            var user = _userRepository.FindById(discoverySetting.UserId);
            if(user is null)
                throw new Exception("Kullanıcı Bulunamadı");
            _discoverySettingRepository.Create(discoverySetting);
        }

        public void Delete(DiscoverySetting discoverySetting)
        {
            var user = _userRepository.FindById(discoverySetting.UserId);
            if(user is null)
                throw new Exception("Kullanıcı Bulunamadı");
            _discoverySettingRepository.Delete(discoverySetting);
        }

        public DiscoverySetting FindByUserId(int userId)
        {
            return _discoverySettingRepository.FindByUserId(userId);
        }

        public DiscoverySetting Update(DiscoverySetting discoverySetting)
        {
            var user = _userRepository.FindById(discoverySetting.UserId);
            if(user is null)
                throw new Exception("Kullanıcı Bulunamadı");
            _discoverySettingRepository.Update(discoverySetting);
            return discoverySetting;
        }
    }
}