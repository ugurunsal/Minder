using Minder.DTO;
using Minder.Model;

namespace Minder.Interface
{
    public interface ILifeStyleService
    {
        BaseResponse<LifeStyle> Create(LifeStyle lifeStyle);
        BaseResponse<LifeStyle> Update(LifeStyle lifeStyle);
        BaseResponse<string> Delete(LifeStyle lifeStyle);
        BaseResponse<LifeStyle> FindByUserId(int userId);
    }
}