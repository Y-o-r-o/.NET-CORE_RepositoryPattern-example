using Moq;
using NUnit.Framework;
using RepositoryLayer.RepositoryServices;
using ServiceClientLayer.ServiceClients.OpenWeatherService;
using System;
using System.Threading.Tasks;

namespace UnitTests.Repositories
{
    [TestFixture]
    public class WeatherForecastRepositoryTests
    {
        private MockRepository mockRepository;

        private Mock<IOpenWeatherServiceClient> mockOpenWeatherServiceClient;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockOpenWeatherServiceClient = this.mockRepository.Create<IOpenWeatherServiceClient>();
        }

        private WeatherForecastRepository CreateWeatherForecastRepository()
        {
            return new WeatherForecastRepository(
                this.mockOpenWeatherServiceClient.Object);
        }

        [Test]
        public async Task GetWeatherAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var weatherForecastRepository = this.CreateWeatherForecastRepository();
            double latitude = 0;
            double longtitude = 0;

            // Act
            var result = await weatherForecastRepository.GetWeatherAsync(
                latitude,
                longtitude);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
