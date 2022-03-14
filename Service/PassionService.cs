using Minder.Interface;
using Minder.Model;

namespace Minder.Service
{
    public class PassionService : IPassionService
    {
        private readonly IPassionRepository _passionRepository;

        public PassionService(IPassionRepository passionRepository)
        {
            _passionRepository = passionRepository;
        }

        public void Create(Passion passion)
        {
            Passion createdPassion = _passionRepository.GetByName(passion.Name);
            if(createdPassion is not null)
                throw new Exception("Bu isimde mevcut bir veri zaten var");
            _passionRepository.Create(passion);
        }

        public void Delete(Passion passion)
        {
            Passion createdPassion = _passionRepository.GetByName(passion.Name);
            if(createdPassion is null)
                throw new Exception("Bu isimde bir veri bulunamadı");
            _passionRepository.Delete(passion);
        }

        public List<Passion> GetAll()
        {
            return _passionRepository.GetAll();
        }

        public Passion GetByName(string name)
        {
            return _passionRepository.GetByName(name);
        }
        
        public Passion Update(Passion passion)
        {
            Passion createdPassion = _passionRepository.GetByName(passion.Name);
            if(createdPassion is null)
                throw new Exception("Bu isimde bir veri bulunamadı");
            _passionRepository.Update(passion);
            return passion;
        }
    }
}