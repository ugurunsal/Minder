using Minder.DTO;
using Minder.Enum;
using Minder.Interface;
using Minder.Model;

namespace Minder.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public BaseResponse<User> Create(User user)
        {
            BaseResponse<User> response = new BaseResponse<User>();
            var createdUser = _userRepository.FindById(user.Id);
            if (createdUser is not null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountFound;
                return response;
            }
            _userRepository.Create(user);
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            response.Data = user;
            return response;
        }

        public BaseResponse<string> Delete(User user)
        {
            BaseResponse<string> response = new BaseResponse<string>();
            var deletedUser = _userRepository.FindById(user.Id);
            if (deletedUser is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountNotFound;
                return response;
            }
            _userRepository.Delete(deletedUser);
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            return response;
        }

        public BaseResponse<User> FindById(int id)
        {
            BaseResponse<User> response = new BaseResponse<User>();
            try
            {
                response.Data = _userRepository.FindById(id);
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

        public BaseResponse<List<User>> GetAll()
        {
            BaseResponse<List<User>> response = new BaseResponse<List<User>>();
            try
            {
                response.Data = _userRepository.GetAll();
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

        public BaseResponse<User> Update(User user)
        {
            BaseResponse<User> response = new BaseResponse<User>();
            var updatedAccount = _userRepository.FindById(user.Id);
            if (updatedAccount is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountNotFound;
                return response;
            }
            _userRepository.Update(updatedAccount);
            response.Data = user;
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            return response;
        }
    }
}