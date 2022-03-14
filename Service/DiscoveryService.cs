using Microsoft.AspNetCore.Identity;
using Minder.DTO;
using Minder.Interface;
using Minder.Model;

namespace Minder.Service
{
    public class DiscoverySettings
    {
        private readonly IUserRepository _userRepository;

        public DiscoverySettings(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<DiscoveryUserDTO> Discovery(int userId)
        {
            List<User> users = _userRepository.GetAll();
            User activeUser = _userRepository.FindById(userId);
            List<DiscoveryUserDTO> discoveryUserList = null;
            GeoCoordinate.NetStandard2.GeoCoordinate coordinate = new GeoCoordinate.NetStandard2.GeoCoordinate(activeUser.Latitude,activeUser.Longtitude);
            foreach (var user in users)
            {
                int age =Age(user.BirthDate);
                double distance = coordinate.GetDistanceTo(new GeoCoordinate.NetStandard2.GeoCoordinate(user.Latitude,user.Longtitude));
                if(age >= activeUser.DiscoverySettings.MinAgePreference&&
                   age <= activeUser.DiscoverySettings.MaxAgePreference&&
                   user.Gender == activeUser.DiscoverySettings.GenderPreference&&
                   distance <= activeUser.DiscoverySettings.DistancePreference)
                {
                    discoveryUserList.Add(new DiscoveryUserDTO{
                        FullName = $"{user.FirstName} {user.LastName}",
                        Gender = user.Gender.ToString(),
                        Age = age,
                        Distance = distance
                    });
                }
            }

            return discoveryUserList;
        }
        private int Age(DateTime birthDate)
        {
            int today = DateTime.Today.Year;
            int age = today-birthDate.Year;
            return age;
        }
    }
}