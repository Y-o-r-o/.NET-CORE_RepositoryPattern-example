using BusinessLayer.BusinessServices;
using BusinessLayer.Settings;
using Core.Extensions;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Databases.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UnitTests.BusinessLayerTests.ArrangeBusinessLayerUnitTests;

namespace UnitTests.BusinessLayerTests
{
    [TestFixture]
    public class AccessTokenServiceTests
    {
        private MockRepository mockRepository;

        private Mock<JwtSettings> _mockJwtSettings;
        private Mock<JwtSecurityTokenHandler> _mockJwtSecurityTokenHandler;

        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            _mockJwtSettings = mockRepository.Create<JwtSettings>();
            _mockJwtSecurityTokenHandler = mockRepository.Create<JwtSecurityTokenHandler>();
        }

        private AccessTokenService InitializeTestingObj()
        {
            _mockJwtSettings.Object.RefreshTokenKey = "SecretKey";
            _mockJwtSettings.Object.TokenKey = "SecretKey";
            
            return new AccessTokenService(
                _mockJwtSettings.Object,
                _mockJwtSecurityTokenHandler.Object);
        }

        [Test]
        public async Task GenerateAsync_GiveNullParam_ThrowsNullReferenceException()
        {
            // Arrange
            var service = InitializeTestingObj();
            AppUser user = null;

            // Act
            var action = new Func<Task<string>>(() => service.GenerateAsync(user));

            // Assert
            Assert.ThrowsAsync<NullReferenceException>(() => action.Invoke());

        }

        [Test]
        public async Task GenerateAsync_GiveUser_Returns()
        {
            // Arrange
            _mockJwtSecurityTokenHandler.Setup(m => m.CreateToken(It.IsAny<SecurityTokenDescriptor>())).Returns((SecurityToken)null);
            _mockJwtSecurityTokenHandler.Setup(m => m.WriteToken(It.IsAny<SecurityToken>())).Returns(string.Empty);

            var service = InitializeTestingObj();

            AppUser user = ArrangeUsers.User();

            // Act
            var result = await service.GenerateAsync(user);

            // Assert
            Assert.NotNull(result);
        }
    }
}
