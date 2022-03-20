using Microsoft.EntityFrameworkCore;
using Minder.Enum;

namespace Minder.Model
{
    public class MinderDBContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DiscoverySetting> DiscoverySettings { get; set; }
        public DbSet<Match> Matches { get; set; }
        //public DbSet<LifeStyle> LifeStyles { get; set; }
        //public DbSet<Passion> Passions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
            optionsBuilder.UseMySql("server=localhost;database=minder;user=root;port=3306;password=toortoor", serverVersion);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.Email).IsRequired();
                    entity.Property(e => e.Password).IsRequired();
                    entity.Property(e => e.IsBlocked);
                    entity.Property(e => e.IsVisible);
                    entity.HasOne(e=>e.User).WithOne(e=>e.Account).HasForeignKey<Account>(e=>e.UserId);
                });

            modelBuilder.Entity<User>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.FirstName).IsRequired();
                    entity.Property(e => e.LastName).IsRequired();
                    entity.Property(e => e.Gender);
                    entity.Property(e => e.BirthDate);
                    entity.Property(e => e.Location);
                    entity.Property(e => e.School);
                    entity.Property(e => e.AboutMe);
                    entity.Property(e => e.JobTitle);
                    entity.Property(e => e.Company);
                    entity.Property(e => e.LivingIn);
                    entity.HasOne(e=>e.DiscoverySettings).WithOne(e=>e.User).HasForeignKey<DiscoverySetting>(e=>e.UserId);
                });

            modelBuilder.Entity<DiscoverySetting>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.DistancePreference).IsRequired();
                    entity.Property(e => e.MinAgePreference).IsRequired();
                    entity.Property(e => e.MaxAgePreference).IsRequired();
                    entity.Property(e => e.GenderPreference).IsRequired();
                    entity.HasOne(e=>e.User).WithOne(e=>e.DiscoverySettings).HasForeignKey<DiscoverySetting>(e=>e.UserId);
                });

            modelBuilder.Entity<Match>(entity =>
                {
                    entity.HasKey(e => e.Id);
                    entity.Property(e => e.MatchedUserId).IsRequired();
                    entity.Property(e => e.IsMatch).IsRequired();
                });

            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = 1,
                    Email = "ugurunsal@gmail.com",
                    Password = "123456",
                    IsBlocked = false,
                    IsVisible = true,
                    UserId = 1
                },
                new Account
                {
                    Id = 2,
                    Email = "onurunsal@gmail.com",
                    Password = "123456",
                    IsBlocked = false,
                    IsVisible = true,
                    UserId = 2
                },
                new Account
                {
                    Id = 3,
                    Email = "utkudemir@gmail.com",
                    Password = "123456",
                    IsBlocked = false,
                    IsVisible = true,
                    UserId = 3
                },
                new Account
                {
                    Id = 4,
                    Email = "ersenuncu@gmail.com",
                    Password = "123456",
                    IsBlocked = false,
                    IsVisible = true,
                    UserId = 4
                },
                new Account
                {
                    Id = 5,
                    Email = "ozgurozturk@gmail.com",
                    Password = "123456",
                    IsBlocked = false,
                    IsVisible = true,
                    UserId = 5
                },
                new Account
                {
                    Id = 6,
                    Email = "idilnihan@gmail.com",
                    Password = "654321",
                    IsBlocked = false,
                    IsVisible = true,
                    UserId = 6
                },
                new Account
                {
                    Id = 7,
                    Email = "setenay@gmail.com",
                    Password = "654321",
                    IsBlocked = false,
                    IsVisible = true,
                    UserId = 7
                },
                new Account
                {
                    Id = 8,
                    Email = "goksenbakay@gmail.com",
                    Password = "654321",
                    IsBlocked = false,
                    IsVisible = true,
                    UserId = 8
                },
                new Account
                {
                    Id = 9,
                    Email = "seymadeveci@gmail.com",
                    Password = "654321",
                    IsBlocked = false,
                    IsVisible = true,
                    UserId = 9
                },
                new Account
                {
                    Id = 10,
                    Email = "alarasakarya@gmail.com",
                    Password = "654321",
                    IsBlocked = false,
                    IsVisible = true,
                    UserId = 10
                });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    AccountId = 1,
                    //DiscoverySettingId=1,
                    FirstName = "Ugur",
                    LastName = "Unsal",
                    Gender = Gender.Man,
                    BirthDate = new DateTime(1999,02,04),
                    Latitude = 41.065006179484264,
                    Longtitude = 28.99362576838913
                },
                new User
                {
                    Id = 2,
                    AccountId = 2,
                    //DiscoverySettingId=2,
                    FirstName = "Onur",
                    LastName = "Unsal",
                    Gender = Gender.Man,
                    BirthDate = new DateTime(1997,02,04),
                    Latitude = 40.99127193709408, 
                    Longtitude = 28.83275948060281
                },
                new User
                {
                    Id = 3,
                    AccountId = 3,
                    //DiscoverySettingId=3,
                    FirstName = "Utku",
                    LastName = "Demir",
                    Gender = Gender.Man,
                    BirthDate = new DateTime(1990,02,04),
                    Latitude = 41.08601137075478, 
                    Longtitude = 28.27675576244503
                },
                new User
                {
                    Id = 4,
                    AccountId = 4,
                    //DiscoverySettingId=4,
                    FirstName = "Ersen",
                    LastName = "Uncu",
                    Gender = Gender.Man,
                    BirthDate = new DateTime(1980,02,04),
                    Latitude = 41.2138464361844, 
                    Longtitude = 28.765439420948827
                },
                new User
                {
                    Id = 5,
                    AccountId = 5,
                    //DiscoverySettingId=5,
                    FirstName = "Ozgur",
                    LastName = "Ozturk",
                    Gender = Gender.Man,
                    BirthDate = new DateTime(2004,02,04),
                    Latitude = 40.806779694918674, 
                    Longtitude = 29.35884100723468
                },
                new User
                {
                    Id = 6,
                    AccountId = 6,
                    //DiscoverySettingId=6,
                    FirstName = "İdil",
                    LastName = "Nihan",
                    Gender = Gender.Women,
                    BirthDate = new DateTime(2003,02,04),
                    Latitude = 41.06150009946095,
                    Longtitude = 28.999743808045224
                },
                new User
                {
                    Id = 7,
                    AccountId = 7,
                    //DiscoverySettingId=7,
                    FirstName = "Setenay",
                    LastName = "Eyigun",
                    Gender = Gender.Women,
                    BirthDate = new DateTime(1995,02,04),
                    Latitude = 40.976113655976135, 
                    Longtitude = 28.730090714252068,
                },
                new User
                {
                    Id = 8,
                    AccountId = 8,
                    //DiscoverySettingId=8,
                    FirstName = "Goksen",
                    LastName = "Bakay",
                    Gender = Gender.Women,
                    BirthDate = new DateTime(1990,02,04),
                    Latitude = 41.07879195450351, 
                    Longtitude = 28.302878176490744,
                },
                new User
                {
                    Id = 9,
                    AccountId = 9,
                    //DiscoverySettingId=9,
                    FirstName = "Seyma",
                    LastName = "Deveci",
                    Gender = Gender.Women,
                    BirthDate = new DateTime(1985,02,04),
                    Latitude = 40.136680128545606, 
                    Longtitude = 29.04677986003154
                },
                new User
                {
                    Id = 10,
                    AccountId = 10,
                    //DiscoverySettingId=10,
                    FirstName = "Alara",
                    LastName = "Sakarya",
                    Gender = Gender.Women,
                    BirthDate = new DateTime(1970,02,04),
                    Latitude = 40.85082202530039,
                    Longtitude =  30.115398352304844
                }
            );
            modelBuilder.Entity<DiscoverySetting>().HasData(
                new DiscoverySetting
                {
                    Id = 1,
                    UserId = 1,
                    DistancePreference = 100,
                    MinAgePreference = 18,
                    MaxAgePreference = 28,
                    GenderPreference = Gender.Women,
                },
                new DiscoverySetting
                {
                    Id = 2,
                    UserId = 2,
                    DistancePreference = 100,
                    MinAgePreference = 18,
                    MaxAgePreference = 28,
                    GenderPreference = Gender.Women,
                },
                new DiscoverySetting
                {
                    Id = 3,
                    UserId = 3,
                    DistancePreference = 100,
                    MinAgePreference = 18,
                    MaxAgePreference = 28,
                    GenderPreference = Gender.Women,
                },
                new DiscoverySetting
                {
                    Id = 4,
                    UserId = 4,
                    DistancePreference = 100,
                    MinAgePreference = 18,
                    MaxAgePreference = 28,
                    GenderPreference = Gender.Women,
                },
                new DiscoverySetting
                {
                    Id = 5,
                    UserId = 5,
                    DistancePreference = 100,
                    MinAgePreference = 18,
                    MaxAgePreference = 28,
                    GenderPreference = Gender.Women,
                },
                new DiscoverySetting
                {
                    Id = 6,
                    UserId = 6,
                    DistancePreference = 100,
                    MinAgePreference = 18,
                    MaxAgePreference = 28,
                    GenderPreference = Gender.Man,
                },
                new DiscoverySetting
                {
                    Id = 7,
                    UserId = 7,
                    DistancePreference = 100,
                    MinAgePreference = 18,
                    MaxAgePreference = 28,
                    GenderPreference = Gender.Man,
                },
                new DiscoverySetting
                {
                    Id = 8,
                    UserId = 8,
                    DistancePreference = 100,
                    MinAgePreference = 18,
                    MaxAgePreference = 28,
                    GenderPreference = Gender.Man,
                },
                new DiscoverySetting
                {
                    Id = 9,
                    UserId = 9,
                    DistancePreference = 100,
                    MinAgePreference = 18,
                    MaxAgePreference = 28,
                    GenderPreference = Gender.Man,
                },
                new DiscoverySetting
                {
                    Id = 10,
                    UserId = 10,
                    DistancePreference = 100,
                    MinAgePreference = 18,
                    MaxAgePreference = 28,
                    GenderPreference = Gender.Man,
                }
            );
        }
    }
}