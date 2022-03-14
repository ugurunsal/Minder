using Minder.DTO;
using Minder.Model;

namespace Minder.Interface
{
    public interface ILoginService
    {
        LoginResponseDTO Authenticate(LoginDTO model);
        Account findAccountById(int id);
    }
}