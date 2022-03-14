using Minder.DTO;
using Minder.Model;

namespace Minder.Interface
{
    public interface IAccountService
    {
        void Create(Account account);
        Account Update(Account account);
        Account UpdateEmail(string oldEmail, string newEmail);
        Account UpdatePasswordByEmail(string email, string newPassword);
        Account ChangeIsBlockedByEmail(string email);
        Account ChangeVisibilityByEmail(string email);
        void DeleteByEmail(string email);
        List<Account> GetAll();
        Account GetByEmail(string email);
        Account GetById(int id);
    }
}