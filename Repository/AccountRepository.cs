using Minder.DTO;
using Minder.Interface;
using Minder.Model;

namespace Minder.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MinderDBContext _context;

        public AccountRepository(MinderDBContext context)
        {
            _context = context;
        }

        public void Create(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public void Delete(Account account)
        {
            _context.Accounts.Remove(account);
            _context.SaveChanges();
        }

        public Account FindByEmailAndPassword(LoginDTO loginDTO)
        {
            Account findedAccount = (from x in _context.Accounts
                                     where x.Email == loginDTO.Email && x.Password == loginDTO.Password
                                     select x).FirstOrDefault();
            return findedAccount;
        }

        public List<Account> GetAll()
        {
            return _context.Accounts.ToList();
        }

        public Account FindByEmail(string email)
        {
            Account findedAccount = (from account in _context.Accounts
                                where account.Email == email
                                select account).FirstOrDefault();
            return findedAccount;
        }

        public Account FindById(int id)
        {
            Account accountByID = (from x in _context.Accounts
                           where x.Id == id
                           select x).FirstOrDefault();
            return accountByID;
        }

        public Account Update(Account account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();
            return account;
        }

        public Account FindByIdAndEmail(int id, string email)
        {
            Account findedAccount = (from x in _context.Accounts
                                     where x.Email == email && x.Id == id
                                     select x).FirstOrDefault();
            return findedAccount;
        }
    }
}