using Minder.DTO;
using Minder.Enum;
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

        public BaseResponse<Account> ChangeIsBlockedByEmail(string email)
        {
            BaseResponse<Account> response = new BaseResponse<Account>();
            var account = _accountRepository.FindByEmail(email);
            if (account is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountNotFound;
                return response;
            }
            account.IsBlocked = !account.IsBlocked;
            _accountRepository.Update(account);
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            response.Data = account;
            return response;
        }

        public BaseResponse<Account> ChangeVisibilityByEmail(string email)
        {
            BaseResponse<Account> response = new BaseResponse<Account>();
            var account = _accountRepository.FindByEmail(email);
            if (account is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountNotFound;
                return response;
            }
            account.IsVisible = !account.IsVisible;
            _accountRepository.Update(account);
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            response.Data = account;
            return response;
        }

        public BaseResponse<Account> Create(Account account)
        {
            BaseResponse<Account> response = new BaseResponse<Account>();
            var createdAccount = _accountRepository.FindByIdAndEmail(account.Id,account.Email);
            if (createdAccount is not null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountFound;
                return response;
            }
            _accountRepository.Create(account);
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            response.Data = account;
            return response;
        }

        public BaseResponse<string> DeleteByEmail(string email)
        {
            BaseResponse<string> response = new BaseResponse<string>();
            var deletedAccount = _accountRepository.FindByEmail(email);
            if (deletedAccount is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountNotFound;
                return response;
            }
            _accountRepository.Delete(deletedAccount);
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            return response;
        }

        public BaseResponse<List<Account>> GetAll()
        {
            BaseResponse<List<Account>> response = new BaseResponse<List<Account>>();
            try
            {
                response.Data = _accountRepository.GetAll();
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

        public BaseResponse<Account> GetByEmail(string email)
        {
            BaseResponse<Account> response = new BaseResponse<Account>();
            try
            {
                response.Data = _accountRepository.FindByEmail(email);
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

        public BaseResponse<Account> GetById(int id)
        {
            BaseResponse<Account> response = new BaseResponse<Account>();
            try
            {
                response.Data = _accountRepository.FindById(id);
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

        public BaseResponse<Account> Update(Account account)
        {
            BaseResponse<Account> response = new BaseResponse<Account>();
            var updatedAccount = _accountRepository.FindByEmail(account.Email);
            if (updatedAccount is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountNotFound;
                return response;
            }
            _accountRepository.Update(account);
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            response.Data = updatedAccount;
            return response;
        }

        public BaseResponse<Account> UpdateEmail(string oldEmail, string newEmail)
        {
            BaseResponse<Account> response = new BaseResponse<Account>();
            var updatedAccount = _accountRepository.FindByEmail(oldEmail);
            if (updatedAccount is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountNotFound;
                return response;
            }
            updatedAccount.Email=newEmail;
            _accountRepository.Update(updatedAccount);
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            response.Data = updatedAccount;
            return response;
        }

        public BaseResponse<Account> UpdatePasswordByEmail(string email, string newPassword)
        {
            BaseResponse<Account> response = new BaseResponse<Account>();
            var updatedAccount = _accountRepository.FindByEmail(email);
            if (updatedAccount is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountNotFound;
                return response;
            }
            updatedAccount.Password=newPassword;
            _accountRepository.Update(updatedAccount);
            response.ResponseStatusCodes = ResponseStatusCodes.Success;
            response.Data = updatedAccount;
            return response;
        }
    }
}