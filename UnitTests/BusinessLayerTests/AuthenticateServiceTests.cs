using BusinessLayer.BusinessServices;
using BusinessLayer.DTOs;
using BusinessLayer.Interfaces;
using Core;
using Microsoft.AspNetCore.Identity;
using Moq;
using NUnit.Framework;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;
using UnitTests.BusinessLayerTests.ArrangeBusinessLayerUnitTests;

namespace UnitTests.BusinessLayerTests
{
    [TestFixture]
    public class AuthenticateServiceTests
    {
        private MockRepository mockRepository;

        private Mock<IAccessTokenService> _mockAccessTokenService;
        private Mock<IRefreshTokenService> _mockRefreshTokenService;
        private Mock<IUserRepository> _mockUserRepository;

        [SetUp]
        public void SetUp()
        {
            mockRepository = new MockRepository(MockBehavior.Strict);

            _mockAccessTokenService = mockRepository.Create<IAccessTokenService>();
            _mockRefreshTokenService = mockRepository.Create<IRefreshTokenService>();
            _mockUserRepository = mockRepository.Create<IUserRepository>();
        }

        private AuthenticateService CreateService()
        {
            return new AuthenticateService(
                _mockAccessTokenService.Object,
                _mockRefreshTokenService.Object,
                _mockUserRepository.Object);
        }

        [Test]
        public void LoginAsync_GiveParams_DoesntThrow()
        {
            // Arrange
            _mockUserRepository.Setup(m => m.GetUserByEmailAsync(It.IsAny<string>())).ReturnsAsync(ArrangeUsers.User);
            _mockUserRepository.Setup(m => m.SignInUserByPasswordAsync(It.IsAny<AppUser>(), It.IsAny<string>())).ReturnsAsync(SignInResult.Success);
            _mockAccessTokenService.Setup(m => m.GenerateAsync(It.IsAny<AppUser>())).ReturnsAsync(string.Empty);
            _mockRefreshTokenService.Setup(m => m.GenerateAsync(It.IsAny<AppUser>())).ReturnsAsync(string.Empty);
            var service = CreateService();

            string email = "test@test.test";
            string password = "P@44woRd123";

            // Act
            var action = new Func<Task<AuthenticateResponseDTO>>(() => service.LoginAsync(email, password));

            // Assert
            Assert.DoesNotThrowAsync(() => action.Invoke());
        }

        [Test]
        public void LoginAsync_GiveBadLogin_ThrowUnauthorized()
        {
            // Arrange
            _mockUserRepository.Setup(m => m.GetUserByEmailAsync(It.IsAny<string>())).ReturnsAsync(ArrangeUsers.User);
            _mockUserRepository.Setup(m => m.SignInUserByPasswordAsync(It.IsAny<AppUser>(), It.IsAny<string>())).ReturnsAsync(SignInResult.Failed);

            var service = CreateService();

            string email = "test@test.test";
            string password = "P@44woRd123";

            // Act
            var action = new Func<Task<AuthenticateResponseDTO>>(() => service.LoginAsync(email, password));

            // Assert
            var exception = Assert.ThrowsAsync<HttpResponseException>(() => action.Invoke());

            Assert.That(exception.StatusCode.Equals(HttpStatusCode.Unauthorized));
        }

        [Test]
        public async Task RefreshTokenAsync_GiveParam_ReturnsObject()
        {
            // Arrange
            _mockRefreshTokenService.Setup(m => m.Validate(It.IsNotNull<string>())).Verifiable();
            _mockRefreshTokenService.Setup(m => m.GetRefreshTokenAsync(It.IsNotNull<string>())).ReturnsAsync(ArrangeRefreshToken.refreshToken);
            _mockRefreshTokenService.Setup(m => m.RemoveRefreshTokenAsync(It.IsNotNull<RefreshToken>())).Returns(Task.FromResult(true));
            _mockUserRepository.Setup(m => m.GetUserByIdAsync(It.IsNotNull<string>())).ReturnsAsync(ArrangeUsers.User);
            _mockAccessTokenService.Setup(m => m.GenerateAsync(It.IsNotNull<AppUser>())).ReturnsAsync(string.Empty);
            _mockRefreshTokenService.Setup(m => m.GenerateAsync(It.IsNotNull<AppUser>())).ReturnsAsync(string.Empty);

            var service = CreateService();
            string requestRefreshToken = "";

            // Act
            var result = await service.RefreshTokenAsync(requestRefreshToken);

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public async Task RefreshTokenAsync_GiveParam_DoesntThrow()
        {
            // Arrange
            _mockRefreshTokenService.Setup(m => m.Validate(It.IsNotNull<string>())).Verifiable();
            _mockRefreshTokenService.Setup(m => m.GetRefreshTokenAsync(It.IsNotNull<string>())).ReturnsAsync(ArrangeRefreshToken.refreshToken);
            _mockRefreshTokenService.Setup(m => m.RemoveRefreshTokenAsync(It.IsNotNull<RefreshToken>())).Returns(Task.FromResult(true));
            _mockUserRepository.Setup(m => m.GetUserByIdAsync(It.IsNotNull<string>())).ReturnsAsync(ArrangeUsers.User);
            _mockAccessTokenService.Setup(m => m.GenerateAsync(It.IsNotNull<AppUser>())).ReturnsAsync(string.Empty);
            _mockRefreshTokenService.Setup(m => m.GenerateAsync(It.IsNotNull<AppUser>())).ReturnsAsync(string.Empty);

            var service = CreateService();
            string requestRefreshToken = "";

            // Act
            var action = new Func<Task<AuthenticateResponseDTO>>(() => service.RefreshTokenAsync(requestRefreshToken));

            // Assert
            Assert.DoesNotThrowAsync(() => action.Invoke());
        }
    }
}
