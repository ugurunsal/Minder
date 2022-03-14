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

        public void Create(User user)
        {
            var createdUser = _userRepository.FindById(user.Id);
            if(createdUser is not null)
                throw new Exception("Böyle bir kullanıcı zaten var");
            _userRepository.Create(user);
        }

        public void Delete(User user)
        {
            var deletedUser = _userRepository.FindById(user.Id);
            if(deletedUser is null)
                throw new Exception("Kullanıcı bulunamadı.");
            _userRepository.Delete(deletedUser);
        }

        public User FindById(int id)
        {
            return _userRepository.FindById(id);
        }

        public List<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User Update(User user)
        {
            var updatedAccount = _userRepository.FindById(user.Id);
            if(updatedAccount is null)
                throw new Exception("Kullanıcı bulunamadı.");
            _userRepository.Update(user);
            return user;
        }
    }
}