using System.Net.Http;
using System.Threading.Tasks;
using CurrentTimeService.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace CurrentTimeService.Tests
{
    public class CurrentTimeServiceIntegrationTests : IClassFixture<WebApplicationFactory<CurrentTimeServiceController>>
    {
        private readonly HttpClient _client;

        public CurrentTimeServiceIntegrationTests(WebApplicationFactory<CurrentTimeServiceController> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetApi_ReturnsCreatedAtDate()
        {
            // Arrange
            // Act
            var response = await _client.GetAsync("api/CurrentTimeService");

            // Assert
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            Assert.NotNull(result);
        }
    }
}
