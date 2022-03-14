using Minder.Enum;
using Minder.Model;

namespace Minder.Model
{
    public class User
   {
       public int Id { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public Gender Gender { get; set; }
       public DateTime BirthDate { get; set; }
       public string? Location { get; set; }
       public string? School { get; set; }
       public string? AboutMe { get; set; }
       public string? JobTitle { get; set; }
       public string? Company { get; set; }
       public string? LivingIn { get; set; }
       //public ICollection<SexualOrientation> SexualOrientation { get; set; }
      // public ICollection<Passion> Passion { get; set; }
       //public LifeStyle LifeStyle { get; set; } 
       public int DiscoverySettingId { get; set; }
       public DiscoverySetting DiscoverySettings { get; set; }
       //public GeoCoordinate.NetStandard2.GeoCoordinate? Coordinate { get; set; }
       public int AccountId { get; set; }
       public Account Account { get; set; }
       public double Latitude { get; set; }
        public double Longtitude { get; set; }
   }         
}