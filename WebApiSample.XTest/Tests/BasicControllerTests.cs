using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace WebApiSample.XTest
{
    [Collection("Integration Tests")]
    public class BasicControllerTests
    {
        private readonly WebApplicationFactory<Startup> factory;

        public BasicControllerTests(WebApplicationFactory<Startup> factory)
        {
            this.factory = factory;
        }

        [Theory]
        [InlineData("/", "Up")]
        [InlineData("/health", "Healthy")]
        public async Task GetPath_ReturnsSuccessAndExpectedStatus(string path, string expectedStatus)
        {
            // Arrange
            var client = factory.CreateClient();

            // Act
            var response = await client.GetAsync(path);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);
            var responseObject = JsonSerializer.Deserialize<ResponseType>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            Assert.Equal(expectedStatus, responseObject?.Status);
        }

        private class ResponseType
        {
            public string Status { get; set; }
        }
    }
}