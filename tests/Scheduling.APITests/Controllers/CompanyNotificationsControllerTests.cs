using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace SchedulingAPI.Controllers.Tests
{
    public class CompanyNotificationsControllerTests(WebApplicationFactory<Program> factory) 
        : IClassFixture<WebApplicationFactory<Program>>
    {
        [Fact()]
        public async void Index_ValidRequest_200Ok()
        {
            // arrange
            var client = factory.CreateClient();

            // act
            var result = await client.GetAsync("/CompanyNotifications?index=2F8BF01A-20A1-4FA9-B050-81FE66807159");

            // assert
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact()]
        public async void Index_InValidRequest_400BadRequest()
        {
            // arrange
            var client = factory.CreateClient();

            // act
            var result = await client.GetAsync("/CompanyNotifications?index=2F8BF01A");

            // assert
            result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
        }
    }
}