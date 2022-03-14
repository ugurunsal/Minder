using Minder.Model;

namespace Minder.Interface
{
    public interface ILifeStyleRepository
    {
        void Create(LifeStyle lifeStyle);
        LifeStyle Update(LifeStyle lifeStyle);
        void Delete(LifeStyle lifeStyle);
        LifeStyle FindByUserId(int userId);
    }
}