namespace Minder.Model
{
   public class Account
   {
       public int Id { get; set; }
       public string Email { get; set; }
       public string Password { get; set; }
       public bool IsBlocked { get; set; }
       public bool IsVisible { get; set; }
       public int UserId { get; set; }
       public User User { get; set; }
   }         
}