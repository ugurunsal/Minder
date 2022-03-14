using Minder.Enum;

namespace Minder.Model
{
   public class LifeStyle
   {
       public int UserId { get; set; }
       public User User { get; set; }
       public Zodiac Zodiac { get; set; }
       public Pet Pet { get; set; }
       public bool IsSmoking { get; set; }     
    }         
}