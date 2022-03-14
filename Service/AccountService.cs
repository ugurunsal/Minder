using Minder.Interface;
using Minder.Model;

namespace Minder.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account ChangeIsBlockedByEmail(string email)
        {
            var account = _accountRepository.FindByEmail(email);
            if(account is null)
                throw new Exception("Girilen e-posta adresine kayıtlı kullanıcı bulunamadı.");
            account.IsBlocked = !account.IsBlocked;
            _accountRepository.Update(account);
            return account;
        }

        public Account ChangeVisibilityByEmail(string email)
        {
            var account = _accountRepository.FindByEmail(email);
            if(account is null)
                throw new Exception("Girilen e-posta adresine kayıtlı kullanıcı bulunamadı.");
            account.IsVisible = !account.IsVisible;
            _accountRepository.Update(account);
            return account;
        }

        public void Create(Account account)
        {
            var createdAccount = _accountRepository.FindByIdAndEmail(account.Id,account.Email);
            if(createdAccount is not null)
                throw new Exception("Böyle bir kullanıcı zaten var");
            _accountRepository.Create(account);
        }

        public void DeleteByEmail(string email)
        {
            var deletedAccount = _accountRepository.FindByEmail(email);
            if(deletedAccount is null)
                throw new Exception("Bu e-posta adresine kayıtlı kullanıcı bulunamadı.");
            _accountRepository.Delete(deletedAccount);
        }

        public List<Account> GetAll()
        {
            return _accountRepository.GetAll();
        }

        public Account GetByEmail(string email)
        {
            return _accountRepository.FindByEmail(email);
        }

        public Account GetById(int id)
        {
            return _accountRepository.FindById(id);
        }

        public Account Update(Account account)
        {
            var updatedAccount = _accountRepository.FindByEmail(account.Email);
            if(updatedAccount is null)
                throw new Exception("Bu e-posta adresine kayıtlı kullanıcı bulunamadı.");
            _accountRepository.Update(account);
            return account;
        }

        public Account UpdateEmail(string oldEmail, string newEmail)
        {
            var updatedAccount = _accountRepository.FindByEmail(oldEmail);
            if(updatedAccount is null)
                throw new Exception("Bu e-posta adresine kayıtlı kullanıcı bulunamadı.");
            updatedAccount.Email=newEmail;
            _accountRepository.Update(updatedAccount);
            return updatedAccount;
        }

        public Account UpdatePasswordByEmail(string email, string newPassword)
        {
            var updatedAccount = _accountRepository.FindByEmail(email);
            if(updatedAccount is null)
                throw new Exception("Bu e-posta adresine kayıtlı kullanıcı bulunamadı.");
            updatedAccount.Password=newPassword;
            _accountRepository.Update(updatedAccount);
            return updatedAccount;
        }
    }
}