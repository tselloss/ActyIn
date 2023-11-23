using Athletes.Info.Controller;
using Athletes.Info.Interface;
using Athletes.Info.Model;
using Athletes.Info.Repository;
using AutoMapper;
using Define.Common;
using Define.Common.Exceptions;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Postgres.Context.DBContext;
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
        NpgsqlContext _context;


        [SetUp]
        public void Setup()
        {
            _athletesService = A.Fake<IAthletes>();
            _logger = A.Fake<ILogger<AthletesController>>();
            _mapper = A.Fake<IMapper>();
            _athleteInfoService = A.Fake<AthleteInfoService>();
            _context = A.Fake<NpgsqlContext>();

            _controller = new AthletesController(_athletesService, _logger, _mapper, _athleteInfoService);
        }

        [Test]
        public async Task GetAllUsersAsync_Test()
        {
            // Arrange
           

            // Act
            var response = await _controller.GetAllUsersAsync();

            // Assert
            Assert.IsInstanceOf<OkResult>(response.Result);
            var okResult = response.Result as OkResult;

            okResult.Should().NotBeNull();
        }
    }
}