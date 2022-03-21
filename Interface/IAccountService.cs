using Minder.DTO;
using Minder.Model;

namespace Minder.Interface
{
    public interface IAccountService
    {
        BaseResponse<Account> Create(Account account);
        BaseResponse<Account> Update(Account account);
        BaseResponse<Account> UpdateEmail(string oldEmail, string newEmail);
        BaseResponse<Account> UpdatePasswordByEmail(string email, string newPassword);
        BaseResponse<Account> ChangeIsBlockedByEmail(string email);
        BaseResponse<Account> ChangeVisibilityByEmail(string email);
        BaseResponse<string> DeleteByEmail(string email);
        BaseResponse<List<Account>> GetAll();
        BaseResponse<Account> GetByEmail(string email);
        BaseResponse<Account> GetById(int id);
    }
}