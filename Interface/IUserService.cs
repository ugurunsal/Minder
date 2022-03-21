using Minder.DTO;
using Minder.Model;

namespace Minder.Interface
{
    public interface IUserService
    {
        BaseResponse<User> Create(User user);
        BaseResponse<User> Update(User user);
        BaseResponse<string> Delete(User user);
        BaseResponse<List<User>> GetAll();
        BaseResponse<User> FindById(int id);
    }
}