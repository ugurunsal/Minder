using Minder.DTO;
using Minder.Interface;
using Minder.Model;


namespace Minder.Service
{
    public class DiscoveryService : IDiscoveryService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMatchRepository _matchRepository;

        public DiscoveryService(IUserRepository userRepository, IMatchRepository matchRepository)
        {
            _userRepository = userRepository;
            _matchRepository = matchRepository;
        }

        public DiscoveryUserDTO Like(int userId, int likedUserId)
        {
            var likedUser = _userRepository.FindById(likedUserId);
            var activeUser = _userRepository.FindById(userId);
            double distance = DistanceInKM(activeUser.Latitude, activeUser.Longtitude, likedUser.Latitude, likedUser.Longtitude);
            var match = _matchRepository.GetMatchByIdies(likedUserId,userId);
            if (match is not null)
            {
                DateTime matchDate = DateTime.Today;
                _matchRepository.Add(new Match{
                    UserId = userId,
                    MatchedUserId = likedUserId,
                    IsMatch = true,
                    IsDislike = false,
                    MatchDate = matchDate
                });
                match.IsMatch = true;
                match.MatchDate = matchDate;
                _matchRepository.Update(match);
                return new DiscoveryUserDTO
                {
                    Result = "MATCH!!!",
                    FullName = $"{likedUser.FirstName} {likedUser.LastName}",
                    Gender = likedUser.Gender.ToString(),
                    Age = (DateTime.Today.Year - likedUser.BirthDate.Year),
                    Distance = $"{distance} KM"
                };
            }
            _matchRepository.Add(
                new Match
                {
                    UserId = userId,
                    MatchedUserId = likedUserId,
                    IsMatch = false,
                    IsDislike = false
                });
                return new DiscoveryUserDTO
                {
                    Result = "Not Matched",
                    FullName = $"{likedUser.FirstName} {likedUser.LastName}",
                    Gender = likedUser.Gender.ToString(),
                    Age = (DateTime.Today.Year - likedUser.BirthDate.Year),
                    Distance = $"{distance} KM"
                };
        }

        public List<DiscoveryUserDTO> Discovery(int userId)
        {
            List<User> users = _userRepository.GetAll();
            User activeUser = _userRepository.FindById(userId);
            List<DiscoveryUserDTO> discoveryUserList = new List<DiscoveryUserDTO>();
            foreach (var user in users)
            {
                int age = Age(user.BirthDate);
                double distance = DistanceInKM(activeUser.Latitude, activeUser.Longtitude, user.Latitude, user.Longtitude);
                if (age >= activeUser.DiscoverySettings.MinAgePreference &&
                   age <= activeUser.DiscoverySettings.MaxAgePreference &&
                   user.Gender == activeUser.DiscoverySettings.GenderPreference &&
                   distance <= activeUser.DiscoverySettings.DistancePreference)
                {
                    discoveryUserList.Add(new DiscoveryUserDTO
                    {
                        Result = "Not Matched",
                        FullName = $"{user.FirstName} {user.LastName}",
                        Gender = user.Gender.ToString(),
                        Age = age,
                        Distance = $"{distance} KM"
                    });
                }
            }

            return discoveryUserList;
        }
        private int Age(DateTime birthDate)
        {
            int today = DateTime.Today.Year;
            int age = today - birthDate.Year;
            return age;
        }

        private double DistanceInKM(double mainLat, double mainLong, double targetLat, double targetLong)
        {
            GeoCoordinate.NetStandard2.GeoCoordinate coordinate = new GeoCoordinate.NetStandard2.GeoCoordinate(mainLat, mainLong);
            double distance = coordinate.GetDistanceTo(new GeoCoordinate.NetStandard2.GeoCoordinate(targetLat, targetLong)) / 1000;
            return distance;
        }
    }
}