using Minder.Enum;

namespace Minder.Model
{
    public class DiscoverySetting
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int DistancePreference { get; set; }
        public int MinAgePreference { get; set; }
        public int MaxAgePreference { get; set; }
        public Gender GenderPreference { get; set; }
    }
}