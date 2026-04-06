using Microsoft.AspNetCore.Mvc.Testing;

namespace WebAPITests
{
    public class CalcControllerTests(WebApplicationFactory<Program> factory) : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory = factory;

        [Theory]
        [InlineData("/api/calc/add", 1, 2, 3)]
        [InlineData("/api/calc/add", -1, 1, 0)]
        [InlineData("/api/calc/reduce", 3, 1, 2)]
        [InlineData("/api/calc/reduce", 5, 2, 3)]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url, int paramA, int paramB, int expectedResult)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync($"{url}?a={paramA}&b={paramB}");
            string actualResult = await response.Content.ReadAsStringAsync();

            // Assert
            response.EnsureSuccessStatusCode();// Status Code 200-299
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType?.ToString());
            Assert.Equal(expectedResult, int.Parse(actualResult));
        }
    }
}
