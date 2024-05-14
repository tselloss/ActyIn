using Athletes.Info.Controller;
using Athletes.Info.Interface;
using Athletes.Info.Model;
using Athletes.Info.Repository;
using AutoMapper;
using Define.Common;
using FakeItEasy;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Postgres.Context.DBContext;
using Postgres.Context.Entities;

namespace AthletesTests
{
    public class AthletesControllerTests
    {
        AthletesController _controller;
        IAthletes _athletesInfo;
        ILogger<AthletesController> _logger;
        IMapper _mapper;
        AthleteInfoService _athleteInfoService;
        NpgsqlContext _context;
        IConfiguration _configuration;


        [SetUp]
        public void Setup()
        {
            _athletesInfo = A.Fake<IAthletes>();
            _logger = A.Fake<ILogger<AthletesController>>();
            _mapper = A.Fake<IMapper>();
            _athleteInfoService = A.Fake<AthleteInfoService>();
            _context = A.Fake<NpgsqlContext>();

            _controller = new AthletesController(_athletesInfo, _logger, _mapper, _athleteInfoService);
        }


        [Test]
        public async Task GetAllUsersAsync_Test()
        {
            var username = "Test";
            // Arrange          
            var responseAthlete = new AthleteInfoDTO
            {
                Address = "Test Address 18",
                City = "TestCity",
                Email = "Nikos@nikos.com",
                FavoriteActivity = "TestAct",
                PostalCode = 1234,
                Username = "Test",
            };
            var responseEntity = new AthletesEntity
            {
                Address = "Test Address 18",
                City = "TestCity",
                Email = "Nikos@nikos.com",
                FavoriteActivity = "TestAct",
                PostalCode = 1234,
                Username = "Test",
            };

            // Act


            // Assert
        }

        [Test]
        public void CanSaveAndRetrieveData()
        {
            // Arrange
            var serviceProvider = new ServiceCollection()
                .AddDbContext<NpgsqlContext>(options =>
                    options.UseNpgsql("Server=localhost;Database=ActyInV100;Username=postgres;Password=admin;"))
                .BuildServiceProvider();

            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<NpgsqlContext>();

                // Act
                // Perform actions that involve saving or retrieving data from the database
                var athlete = new AthletesEntity
                {
                    Username = "user1",
                    Email = "user1@example.com",
                    Password = "password1",
                    Address = "123 Main St",
                    City = "City1",
                    PostalCode = 12345,
                    FavoriteActivity = "Running",
                    Role = Roles.User
                };

                dbContext.AthletesInfo.Add(athlete);
                dbContext.SaveChanges();

                // Assert
                // Verify that the data was saved and can be retrieved
                var retrievedAthlete = dbContext.AthletesInfo.FirstOrDefault(a => a.AthletesId == 1);
                Assert.NotNull(retrievedAthlete);
                // Additional assertions as needed
            }
        }
    }
}