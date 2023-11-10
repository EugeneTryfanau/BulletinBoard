using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net;

namespace BulletinBoard.Tests.IntegrationTests
{
    public class BasicTests
        : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public BasicTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [Theory]
        [InlineData("/api/categories")]
        [InlineData("/api/users")]
        [InlineData("/api/products/pages/%/0/8")]
        [InlineData("/api/products/pages/%/0/8/1")]
        public async Task Get_EndpointsReturnOK(string url)
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var responce = await client.GetAsync(url);

            //Assert
            responce.EnsureSuccessStatusCode();
            Assert.Equal("OK", responce.StatusCode.ToString());
        }

        [Theory]
        [InlineData("/api/logout")]
        [InlineData("/api/admin/users")]
        public async Task Get_EndpointsRequireAuthorizationReturnError(string url)
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var responce = await client.GetAsync(url);

            //Assert
            Assert.Equal("InternalServerError", responce.StatusCode.ToString());
        }
    }
}
