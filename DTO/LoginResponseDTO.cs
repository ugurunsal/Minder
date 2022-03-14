namespace Minder.DTO
{
    public class LoginResponseDTO
    {
        public string Access_Token { get; set; }


        public LoginResponseDTO(string token)
        {
            Access_Token = token;
        }
    }
}