using Minder.DTO;
using Minder.Enum;
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

        public BaseResponse<DiscoverySetting> Create(DiscoverySetting discoverySetting)
        {
            BaseResponse<DiscoverySetting> response = new BaseResponse<DiscoverySetting>();
            var user = _userRepository.FindById(discoverySetting.UserId);
            if (user is not null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountNotFound;
                return response;
            }
            _discoverySettingRepository.Create(discoverySetting);
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            response.Data = discoverySetting;
            return response;
        }

        public BaseResponse<string> Delete(DiscoverySetting discoverySetting)
        {
            BaseResponse<string> response = new BaseResponse<string>();
            var user = _userRepository.FindById(discoverySetting.UserId);
            if (user is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountNotFound;
                return response;
            }
            _discoverySettingRepository.Delete(discoverySetting);
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            return response;
        }

        public BaseResponse<DiscoverySetting> FindByUserId(int userId)
        {
            BaseResponse<DiscoverySetting> response = new BaseResponse<DiscoverySetting>();
            try
            {
                response.Data = _discoverySettingRepository.FindByUserId(userId);
                response.ResponseStatusCodes = ResponseStatusCodes.Success;
                return response;
            }
            catch (Exception e)
            {
                response.Data = null;
                response.ResponseStatusCodes = ResponseStatusCodes.DataNotFound;
                return response;
            }
        }

        public BaseResponse<DiscoverySetting> Update(DiscoverySetting discoverySetting)
        {
            BaseResponse<DiscoverySetting> response = new BaseResponse<DiscoverySetting>();
            var user = _userRepository.FindById(discoverySetting.UserId);
            if (user is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountNotFound;
                return response;
            }
            _discoverySettingRepository.Update(discoverySetting);
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            response.Data = discoverySetting;
            return response;
        }
    }
}