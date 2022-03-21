using Minder.DTO;
using Minder.Enum;
using Minder.Interface;
using Minder.Model;

namespace Minder.Service
{
    public class LifeStyleService : ILifeStyleService
    {
        private readonly ILifeStyleRepository _lifeStyleRepository;
        private readonly IUserRepository _userRepository;

        public LifeStyleService(ILifeStyleRepository lifeStyleRepository, IUserRepository userRepository)
        {
            _lifeStyleRepository = lifeStyleRepository;
            _userRepository = userRepository;
        }

        public BaseResponse<LifeStyle> Create(LifeStyle lifeStyle)
        {
            BaseResponse<LifeStyle> response = new BaseResponse<LifeStyle>();
            var user = _userRepository.FindById(lifeStyle.UserId);
            if (user is not null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountFound;
                return response;
            }
            _lifeStyleRepository.Create(lifeStyle);
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            response.Data = lifeStyle;
            return response;
        }

        public BaseResponse<string> Delete(LifeStyle lifeStyle)
        {
            BaseResponse<string> response = new BaseResponse<string>();
            var user = _userRepository.FindById(lifeStyle.UserId);
            if (user is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountNotFound;
                return response;
            }
            _lifeStyleRepository.Delete(lifeStyle);
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            return response;
        }

        public BaseResponse<LifeStyle> FindByUserId(int userId)
        {
            BaseResponse<LifeStyle> response = new BaseResponse<LifeStyle>();
            try
            {
                response.Data = _lifeStyleRepository.FindByUserId(userId);
                response.ResponseStatusCodes = ResponseStatusCodes.Success;
                return response;
            }
            catch (Exception e)
            {
                response.Data = null;
                response.ResponseStatusCodes = ResponseStatusCodes.AccountNotFound;
                return response;
            }
        }

        public BaseResponse<LifeStyle> Update(LifeStyle lifeStyle)
        {
            BaseResponse<LifeStyle> response = new BaseResponse<LifeStyle>();
            var user = _userRepository.FindById(lifeStyle.UserId);
            if (user is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountNotFound;
                return response;
            }
            _lifeStyleRepository.Update(lifeStyle);
            response.Data = lifeStyle;
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            return response;
        }
    }
}