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

        [SetUp]
        public void Setup()
        {
            _athletesInfo = A.Fake<IAthletes>();
            _logger = A.Fake<ILogger<AthletesController>>();
            _mapper = A.Fake<IMapper>();

            var options = new DbContextOptionsBuilder<NpgsqlContext>()
                              .UseInMemoryDatabase(databaseName: "TestDatabase")
                              .Options;
            _context = new NpgsqlContext(options);

            _athleteInfoService = new AthleteInfoService(_context);
            _controller = new AthletesController(_athletesInfo, _logger, _mapper, _athleteInfoService);
        }

        [Test]
        public void CanSaveAndRetrieveData()
        {
            // Arrange
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

            // Act
            var dbContext = _context;
            dbContext.AthletesInfo.Add(athlete);
            dbContext.SaveChanges();

            // Assert
            var retrievedAthlete = dbContext.AthletesInfo.FirstOrDefault(a => a.AthletesId == 1);
            retrievedAthlete.Username.Should().Be(athlete.Username);
            retrievedAthlete.Should().NotBeNull();
        }


        [Test]
        public void Constructor_Should_Throw_Exception_When_Logger_Is_Null()
        {
            // Act
            Action act = () => new AthletesController(_athletesInfo, null, _mapper, _athleteInfoService);

            // Assert
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("logger");
        }

        [Test]
        public void Constructor_Should_Throw_Exception_When_IAthletesInfo_Is_Null()
        {
            // Act
            Action act = () => new AthletesController(null, _logger, _mapper, _athleteInfoService);

            // Assert
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("athleteInfo");
        }

        [Test]
        public void Constructor_Should_Throw_Exception_When_AthleteInfoService_Is_Null()
        {
            // Act
            Action act = () => new AthletesController(_athletesInfo, _logger, _mapper, null);

            // Assert
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("athletesInfoService");
        }

        [Test]
        public void Constructor_Should_Throw_Exception_When_mapper_Is_Null()
        {
            // Act
            Action act = () => new AthletesController(_athletesInfo, _logger, null, _athleteInfoService);

            // Assert
            act.Should().Throw<ArgumentNullException>().And.ParamName.Should().Be("mapper");
        }
    }
}