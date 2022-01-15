using Auth.Test;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Functional.Tests;
public class PostTests
{
    private readonly PostFixtureAPI _factory;
    public PostTests()
    {
        _factory = new PostFixtureAPI();
    }

    [Fact]
    public async Task StudentShouldBeAbleToCreatePost()
    {
        // Arrange
        var httpClient = _factory.CreateClient();
        var payload = "{\"email\": \"teste@teste2.com\", \"password\": \"SecurePass!123\"}";
        var response = await httpClient.PostAsync("/api/auth/login", new StringContent(payload, Encoding.UTF8, "application/json"));
        var responseContent = await response.Content.ReadAsStreamAsync();
        var authResult = await JsonSerializer.DeserializeAsync<ApplicationUserOutputDTOFake>(responseContent);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.Token);

        var document = File.OpenRead("WIN_20210413_15_23_53_Pro.jpg");

        HttpContent fileStreamContent = new StreamContent(document);
        fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
        var requestContent = new MultipartFormDataContent();
        requestContent.Add(fileStreamContent, "UploadedFile", document.Name);
        requestContent.Add(new StringContent("Fake Title"), "Title");
        requestContent.Add(new StringContent("Fake Text"), "Text");
        requestContent.Add(new StringContent("true"), "IsPublic");
        requestContent.Add(new StringContent("1"), "KnowledgeAreaId");
        // Act
        response = await httpClient.PostAsync("api/post", requestContent);

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

    }
    [Fact]
    public async Task InvalidPostShouldReturnBadRequest()
    {
        // Arrange
        var httpClient = _factory.CreateClient();
        var payload = "{\"email\": \"teste@teste2.com\", \"password\": \"SecurePass!123\"}";
        var response = await httpClient.PostAsync("/api/auth/login", new StringContent(payload, Encoding.UTF8, "application/json"));
        var responseContent = await response.Content.ReadAsStreamAsync();
        var authResult = await JsonSerializer.DeserializeAsync<ApplicationUserOutputDTOFake>(responseContent);
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.Token);

        var document = File.OpenRead("WIN_20210413_15_23_53_Pro.jpg");

        HttpContent fileStreamContent = new StreamContent(document);
        fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
        var requestContent = new MultipartFormDataContent();
        requestContent.Add(fileStreamContent, "UploadedFile", document.Name);
        requestContent.Add(new StringContent("Fake Text"), "Text");
        requestContent.Add(new StringContent("true"), "IsPublic");
        requestContent.Add(new StringContent("1"), "KnowledgeAreaId");
        // Act
        response = await httpClient.PostAsync("api/post", requestContent);

        // Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    [Fact]
    public async Task TestIfPostGetEndpointReturnsPagedResult()
    {

        // Arrange
        var httpClient = _factory.CreateClient();
        var response = await httpClient.GetAsync("api/post?pageSize=10&currentPage=1");
        Console.WriteLine(await response.Content.ReadAsStringAsync());
        response.EnsureSuccessStatusCode();

    }
}
