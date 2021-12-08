using Microsoft.Extensions.Configuration;
using ShareMyPaper.Domain.Entities;
using ShareMyPaper.Infraestructure.Services;
using System.Collections.Generic;
using Xunit;

namespace Unit.Tests;
public class TokenServiceTests
{

    [Fact]
    public void ShouldGenerateAToken()
    {
        //Arrange
        var inMemorySettings = new Dictionary<string, string> {
                {"Jwt:Secret", "um-segredoQualquer"},
                {"Jwt:Issuer", "teste-issuer"},
            };

        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

        var tokenService = new TokenService(configuration);

        var institutionFake = new Institution
        {
            Id = 1
        };

        var fakeUser = new ApplicationUser()
        {
            Email = "teste@teste1.com",
            UserName = "madas",
            DocumentId = "www.google.com",
            DocumentExtension = "jpeg",
            Institution = institutionFake,
            Role = "student"
        };
        // act
        var token = tokenService.BuildToken(fakeUser);
        // assert
        Assert.True(!string.IsNullOrWhiteSpace(token));
    }
}