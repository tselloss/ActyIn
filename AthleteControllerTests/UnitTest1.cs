using Athletes.Info.Controller;
using Define.Common.Exceptions;
using Define.Common.Extension.Methods;
using FakeItEasy;
using Postgres.Context.DBContext;
using Postgres.Context.Entities;

[TestFixture]
public class AthletesControllerTests
{
    [Test]
    public void RegisterAthlete_ValidRequest_SuccessfullyRegistersAthlete()
    {
        // Arrange
        var fakeContext = A.Fake<NpgsqlContext>(); // Replace YourDbContext with the actual type of your database context
        var fakePasswordHash = A.Fake<PasswordHash>(); // Replace IPasswordHashService with the actual type of your password hashing service

        var registerRequest = new AthletesEntity
        {
            Email = "test@example.com",
            Username = "testuser",
            Password = "password123",
        };

        // Act
        athletesController.RegisterAthlete(registerRequest);

        // Assert
        A.CallTo(() => fakeContext.SaveChanges()).MustHaveHappenedOnceExactly();
    }

    [Test]
    public void RegisterAthlete_DuplicateUsername_ThrowsException()
    {
        // Arrange
        var fakeContext = A.Fake<NpgsqlContext>();
        var fakePasswordHash = A.Fake<PasswordHash>();

        // Simulate a duplicate username in the fake context
        A.CallTo(() => fakeContext.AthletesInfoEntity.Any(u => u.Username == A<string>._)).Returns(true);

        var athletesController = new AthletesController(fakeContext, fakePasswordHash);
        var registerRequest = new AthletesEntity
        {
            Email = "test@example.com",
            Username = "existinguser", // Use an existing username to simulate duplicate
            Password = "password123",
            // Set other properties as needed
        };

        // Act & Assert
        Assert.Throws<ControllerExceptionMessage>(() => athletesController.RegisterAthlete(registerRequest));
    }

    // Similar tests can be written for other scenarios (e.g., duplicate email, missing required fields, etc.)
}