namespace Minder.Model
{
    public class Match
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MatchedUserId { get; set; }
        public bool IsMatch { get; set; }
        public bool IsDislike { get; set; }
        public DateTime? MatchDate { get; set; }
    }
}