using Minder.Model;

namespace Minder.Interface
{
    public interface IUserRepository
    {
        void Create(User user);
        User Update(User user);
        void Delete(User user);
        List<User> GetAll();
        User FindById(int id);
    }
}