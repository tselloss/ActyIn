using Athletes.Info.Controller;
using Athletes.Info.Interface;
using Athletes.Info.Repository;
using Athletes.Info.Request;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Postgres.Context.DBContext;
using Postgres.Context.Entities;

namespace AthletesTests
{
    public class IAthletesTests
    {
        [TestCase]
        public void RegisterUser_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var registerRequest = new AthletesRegisterRequest
            {
                Email = "test@example.com",
                Username = "testuser",
                Password = "testpassword",
                Address = "testAddress",
                City = "testCity",
                FavoriteActivity = "test",
                PostalCode = 10000,
                Role = Define.Common.Roles.User                
            };

            var mappedEntity = new AthletesEntity
            {
                Email = registerRequest.Email,
                Username = registerRequest.Username,
                Password = registerRequest.Password,
                Role = registerRequest.Role,    
                PostalCode=registerRequest.PostalCode,
                City=registerRequest.City,  
                Address=registerRequest.Address,
                ChoosenActivity = "testChoosenActivity",
            };

            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<AthletesEntity>(registerRequest))
                      .Returns(mappedEntity);

            var athleteInfoServiceMock = new Mock<IAthletes>();
            athleteInfoServiceMock.Setup(s => s.RegisterAthlete(mappedEntity))
                                 .Verifiable();

            var controller = new AthletesController((IAthletes)mapperMock.Object, (IMapper)athleteInfoServiceMock.Object);

            // Act
            var result = controller.CreateUserAsync(registerRequest);

            // Assert
            Assert.NotNull(result);
            athleteInfoServiceMock.Verify();
        }
    }
}