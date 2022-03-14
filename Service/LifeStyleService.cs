using Minder.Interface;
using Minder.Model;

namespace Minder.Service
{
    public class LifeStyleService : ILifeStyleService
    {
        private readonly ILifeStyleRepository _lifeStyleRepository;
        private readonly IUserRepository _userRepository;

        public LifeStyleService(ILifeStyleRepository lifeStyleRepository, IUserRepository userRepository)
        {
            _lifeStyleRepository = lifeStyleRepository;
            _userRepository = userRepository;
        }

        public void Create(LifeStyle lifeStyle)
        {
            var user = _userRepository.FindById(lifeStyle.UserId);
            if(user is null)
                throw new Exception("Kullanıcı Bulunamadı");
            _lifeStyleRepository.Create(lifeStyle);
        }

        public void Delete(LifeStyle lifeStyle)
        {
            var user = _userRepository.FindById(lifeStyle.UserId);
            if(user is null)
                throw new Exception("Kullanıcı Bulunamadı");
            _lifeStyleRepository.Delete(lifeStyle);
        }

        public LifeStyle FindByUserId(int userId)
        {
            return _lifeStyleRepository.FindByUserId(userId);
        }

        public LifeStyle Update(LifeStyle lifeStyle)
        {
            var user = _userRepository.FindById(lifeStyle.UserId);
            if(user is null)
                throw new Exception("Kullanıcı Bulunamadı");
            _lifeStyleRepository.Update(lifeStyle);
            return lifeStyle;
        }
    }
}