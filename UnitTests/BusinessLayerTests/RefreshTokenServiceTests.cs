using BusinessLayer.BusinessServices;
using BusinessLayer.Settings;
using Core;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Databases.Entities;
using RepositoryLayer.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using UnitTests.BusinessLayerTests.ArrangeBusinessLayerUnitTests;

namespace UnitTests.BusinessLayerTests;

[TestFixture]
public class RefreshTokenServiceTests
{
    private MockRepository mockRepository;

    private Mock<JwtSettings> _mockJwtSettings;
    private Mock<IRefreshTokenRepository> _mockRefreshTokenRepository;
    private Mock<JwtSecurityTokenHandler> _mockJwtSecurityTokenHandler;

    [SetUp]
    public void SetUp()
    {
        mockRepository = new MockRepository(MockBehavior.Strict);

        _mockJwtSettings = mockRepository.Create<JwtSettings>();
        _mockRefreshTokenRepository = mockRepository.Create<IRefreshTokenRepository>();
        _mockJwtSecurityTokenHandler = mockRepository.Create<JwtSecurityTokenHandler>();
    }

    private RefreshTokenService InitializeTestingObj()
    {
        _mockJwtSettings.Object.RefreshTokenKey = "SecretKey";
        _mockJwtSettings.Object.TokenKey = "SecretKey";

        return new RefreshTokenService(
            _mockJwtSettings.Object,
            _mockRefreshTokenRepository.Object,
            _mockJwtSecurityTokenHandler.Object);
    }

    [Test]
    public void GenerateAsync_GiveNullParam_ThrowsNullReferenceException()
    {
        // Arrange
        _mockJwtSecurityTokenHandler.Setup(m => m.CreateToken(It.IsAny<SecurityTokenDescriptor>())).Returns((SecurityToken)null);
        _mockJwtSecurityTokenHandler.Setup(m => m.WriteToken(It.IsAny<SecurityToken>())).Returns(string.Empty);

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
        _mockRefreshTokenRepository.Setup(m => m.AddRefreshTokenAsync(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(true));

        var service = InitializeTestingObj();

        AppUser user = ArrangeUsers.User();

        // Act
        var result = await service.GenerateAsync(user);

        // Assert
        Assert.NotNull(result);
    }

    [Test]
    public void GetRefreshTokenAsync_GiveNullParam_ThrowsNotFound()
    {
        // Arrange
        _mockRefreshTokenRepository.Setup(m => m.GetRefreshTokenByRequestRefreshTokenAsync(It.IsNotNull<string>())).ReturnsAsync(new RefreshToken());
        _mockRefreshTokenRepository.Setup(m => m.GetRefreshTokenByRequestRefreshTokenAsync(It.Is<string>(v => v == null))).ReturnsAsync((RefreshToken)null);

        var service = InitializeTestingObj();
        string requestRefreshToken = null;

        // Act
        var action = new Func<Task<RefreshToken>>(() => service.GetRefreshTokenAsync(requestRefreshToken));

        // Assert
        var exception = Assert.ThrowsAsync<HttpResponseException>(() => action.Invoke());

        Assert.That(exception.StatusCode.Equals(HttpStatusCode.NotFound));
    }

    [Test]
    public async Task GetRefreshTokenAsync_GiveParam_ReturnsObject()
    {
        // Arrange
        _mockRefreshTokenRepository.Setup(m => m.GetRefreshTokenByRequestRefreshTokenAsync(It.IsNotNull<string>())).ReturnsAsync(new RefreshToken());
        _mockRefreshTokenRepository.Setup(m => m.GetRefreshTokenByRequestRefreshTokenAsync(It.Is<string>(v => v == null))).ReturnsAsync((RefreshToken)null);

        var service = InitializeTestingObj();
        string requestRefreshToken = "123";

        // Act
        var result = await service.GetRefreshTokenAsync(requestRefreshToken);

        // Assert
        Assert.NotNull(result);
    }

    [Test]
    public void RemoveRefreshTokenAsyncc_GiveNullParam_ThrowsNotFound()
    {
        // Arrange
        _mockRefreshTokenRepository.Setup(m => m.RemoveRefreshTokenAsync(It.IsNotNull<RefreshToken>())).Returns(Task.FromResult(true));
        _mockRefreshTokenRepository.Setup(m => m.RemoveRefreshTokenAsync(It.Is<RefreshToken>(v => v == null))).Returns((Task)null);

        var service = InitializeTestingObj();
        RefreshToken refreshToken = null;

        // Act
        var action = new Func<Task>(() => service.RemoveRefreshTokenAsync(refreshToken));

        // Assert
        Assert.ThrowsAsync<ArgumentNullException>(() => action.Invoke());

    }

    [Test]
    public void RemoveRefreshTokenAsyncc_GiveParam_DoesntThrow()
    {
        // Arrange
        _mockRefreshTokenRepository.Setup(m => m.RemoveRefreshTokenAsync(It.IsNotNull<RefreshToken>())).Returns(Task.FromResult(true));
        _mockRefreshTokenRepository.Setup(m => m.RemoveRefreshTokenAsync(It.Is<RefreshToken>(v => v == null))).Returns((Task)null);

        var service = InitializeTestingObj();
        RefreshToken refreshToken = new();

        // Act
        var action = new Func<Task>(() => service.RemoveRefreshTokenAsync(refreshToken));

        // Assert
        Assert.DoesNotThrowAsync(() => action.Invoke());

    }

    [Test]
    public void Validate_GiveNullParam_ThrowsArgumentNullException()
    {
        // Arrange
        SecurityToken securityToken = null;
        _mockJwtSecurityTokenHandler.Setup(m => m.ValidateToken(It.IsNotNull<string>(), It.IsAny<TokenValidationParameters>(), out securityToken));
        var service = InitializeTestingObj();
        string refreshToken = null;

        // Assert
        var action = new Action(() => service.Validate(refreshToken));

        // Assert
        Assert.Throws<ArgumentNullException>(() => action.Invoke());
    }

    [Test]
    public void Validate_GiveParam_DoesntThrow()
    {
        // Arrange
        SecurityToken securityToken = null;
        _mockJwtSecurityTokenHandler.Setup(m => m.ValidateToken(It.IsNotNull<string>(), It.Is<TokenValidationParameters>(v => v == null), out securityToken)).Returns((ClaimsPrincipal)null);
        var service = InitializeTestingObj();
        string refreshToken = "";

        // Assert
        var action = new Action(() => service.Validate(refreshToken));

        // Assert
        Assert.DoesNotThrow(() => action.Invoke());
    }

    [Test]
    public void Validate_ValidateTokenThrowsArgumentNullException_ThrowsBadRequest()
    {
        // Arrange
        SecurityToken securityToken = null;
        _mockJwtSecurityTokenHandler.Setup(m => m.ValidateToken(It.IsNotNull<string>(), It.Is<TokenValidationParameters>(v => v == null), out securityToken)).Throws<ArgumentNullException>();
        var service = InitializeTestingObj();
        string refreshToken = "";

        // Assert
        var action = new Action(() => service.Validate(refreshToken));
        // Assert
        var exception = Assert.Throws<HttpResponseException>(() => action.Invoke());

        Assert.That(exception.StatusCode.Equals(HttpStatusCode.BadRequest));
    }

    [Test]
    public void Validate_ValidateTokenThrowsOtherException_ThrowsUnauthorized()
    {
        // Arrange
        SecurityToken securityToken = null;
        _mockJwtSecurityTokenHandler.Setup(m => m.ValidateToken(It.IsNotNull<string>(), It.Is<TokenValidationParameters>(v => v == null), out securityToken)).Throws<Exception>();
        var service = InitializeTestingObj();
        string refreshToken = "";

        // Assert
        var action = new Action(() => service.Validate(refreshToken));
        // Assert
        var exception = Assert.Throws<HttpResponseException>(() => action.Invoke());

        Assert.That(exception.StatusCode.Equals(HttpStatusCode.Unauthorized));
    }
}
