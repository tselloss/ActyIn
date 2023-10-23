using Athletes.Info.Controller;
using Athletes.Info.Interface;
using Athletes.Info.Model;
using Athletes.Info.Repository;
using AutoMapper;
using Define.Common;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Postgres.Context.Entities;
using System.Net;

namespace AthletesTests
{
    public class AthletesControllerTests
    {
        AthletesController _controller;
        IAthletes _athletesService;
        ILogger<AthletesController> _logger;
        IMapper _mapper;
        AthleteInfoService _athleteInfoService;

        [SetUp]
        public void Setup()
        {
            _athletesService = A.Fake<IAthletes>();
            _logger = A.Fake<ILogger<AthletesController>>();
            _mapper = A.Fake<IMapper>();
            _athleteInfoService = A.Fake<AthleteInfoService>();

            _controller = new AthletesController(_athletesService, _logger, _mapper, _athleteInfoService);
        }

        [Test]
        public async Task GetAllUsersAsync_Test()
        {
            // Arrange
            var athletesList = new List<AthletesEntity>
            {
                new AthletesEntity
                {
                    AthletesId = 1,
                    Username = "user1",
                    Email = "user1@example.com",
                    Password = "password1",
                    Address = "123 Main St",
                    City = "City1",
                    PostalCode = 12345,
                    FavoriteActivity = "Running",
                    Role = Roles.User
                },
                new AthletesEntity
                {
                    AthletesId = 2,
                    Username = "user2",
                    Email = "user2@example.com",
                    Password = "password2",
                    Address = "456 Oak St",
                    City = "City2",
                    PostalCode = 67890,
                    FavoriteActivity = "Swimming",
                    Role = Roles.User
                }
            };

            A.CallTo(() => _athletesService.GetAllAthletesAsync()).Returns(athletesList);

            // Act
            var response = await _controller.GetAllUsersAsync();

            // Assert
            Assert.IsInstanceOf<OkResult>(response.Result);
            var okResult = response.Result as OkResult;

            okResult.Should().NotBeNull();
            okResult.StatusCode.Should().Be((int)HttpStatusCode.OK);    
        }
    }
}