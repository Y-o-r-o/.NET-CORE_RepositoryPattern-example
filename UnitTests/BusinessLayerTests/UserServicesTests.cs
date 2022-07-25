using BusinessLayer.BusinessServices;
using BusinessLayer.DTOs;
using Core;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Interfaces;
using System.Net;
using UnitTests.BusinessLayerTests.ArrangeBusinessLayerUnitTests;

namespace UnitTests.BusinessLayerTests
{
    [TestFixture]
    public class UserServicesTests
    {
        private MockRepository mockRepository;

        private Mock<IUserRepository> _mockUserRepository;

        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            _mockUserRepository = mockRepository.Create<IUserRepository>();
        }

        private UserServices InitializeTestingObj()
        {
            return new UserServices(
                _mockUserRepository.Object
            );
        }

        [Test]
        public void GetUserAsync_GiveNullIdParam_ExpectNotFoundException()
        {
            // Arrange
            _mockUserRepository.Setup(m => m
                .GetUserByIdAsync(It.Is<string>(str => str == null)))
                .ReturnsAsync((AppUser)null);
            var userServices = InitializeTestingObj();
            string id = null;

            // Act
            var action = new Func<Task<UserDTO>>(() => userServices.GetUserAsync(id));

            // Assert
            var exception = Assert.ThrowsAsync<HttpResponseException>(() => action.Invoke());

            Assert.That(exception.StatusCode.Equals(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task GetUsersAsync_CallMethod_GivesExpectedValues()
        {
            // Arrange
            _mockUserRepository.Setup(m => m.GetUsersAsync()).ReturnsAsync(ArrangeUsers.Users());
            var userServices = InitializeTestingObj();

            // Act
            var result = await userServices.GetUsersAsync();

            // Assert
            Assert.IsTrue(result.Any(u => u.DisplayName.Equals("TomTom")));
            Assert.IsTrue(result.Any(u => u.DisplayName.Equals("DziugDziug")));
            Assert.IsTrue(result.Any(u => u.DisplayName.Equals("LukLuk")));
        }
    }
}