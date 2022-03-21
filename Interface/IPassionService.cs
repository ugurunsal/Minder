using Minder.DTO;
using Minder.Model;

namespace Minder.Interface
{
    public interface IPassionService
    {
        BaseResponse<Passion> Create(Passion passion);
        BaseResponse<Passion> Update(Passion passion);
        BaseResponse<string> Delete(Passion passion);
        BaseResponse<List<Passion>> GetAll();
        BaseResponse<Passion> GetByName(string name);
    }
}