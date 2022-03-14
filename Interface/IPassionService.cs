using Minder.Model;

namespace Minder.Interface
{
    public interface IPassionService
    {
        void Create(Passion passion);
        Passion Update(Passion passion);
        void Delete(Passion passion);
        List<Passion> GetAll();
        Passion GetByName(string name);
    }
}