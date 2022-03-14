using Minder.DTO;
using Minder.Model;

namespace Minder.Interface
{
    public interface IAccountRepository
    {
        void Create(Account account);
        Account Update(Account account);
        void Delete(Account account);
        List<Account> GetAll();
        Account FindByEmail(string email);
        Account FindById(int id);
        Account FindByIdAndEmail(int id, string email);
        Account FindByEmailAndPassword(LoginDTO loginDTO);
    }
}