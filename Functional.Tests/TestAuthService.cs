using Functional.Tests;
using ShareMyPaper.Application.Dtos.Output;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Auth.Test;

public class TestAuthService
{
    private readonly ApiTestFixture _factory;
    public TestAuthService()
    {
        _factory = new ApiTestFixture();
    }
    [Fact]
    public async Task InstitutionModeratorShouldBeAbleToRegisterNewInstMod()
    {

        var httpClient = _factory.CreateClient();
        var payload = "{\"email\": \"teste@instmod.com\", \"password\": \"SecurePass!123\"}";
        var response = await httpClient.PostAsync("/api/auth/login", new StringContent(payload, Encoding.UTF8, "application/json"));

        Assert.True(response.IsSuccessStatusCode);
        // Assert
        using (var stream = await response.Content.ReadAsStreamAsync())
        {
            var r = await JsonSerializer.DeserializeAsync<ApplicationUserOutputDTOFake>(stream);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", r.Token);
            payload = "{\"email\": \"teste@instmodnew.com\", \"password\": \"SecurePass!123\"}";
            var resp = await httpClient.PostAsync("/api/auth/institution-moderator/register", new StringContent(payload, Encoding.UTF8, "application/json"));
            Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
        }


        httpClient = _factory.CreateClient();
        response = await httpClient.PostAsync("/api/auth/login", new StringContent(payload, Encoding.UTF8, "application/json"));

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    [Fact]
    public async Task UnverifiedStudentShouldNotBeAbleToLogin()
    {
        var httpClient = _factory.CreateClient();
        var document = File.OpenRead("WIN_20210413_15_23_53_Pro.jpg");

        HttpContent fileStreamContent = new StreamContent(document);
        fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
        var requestContent = new MultipartFormDataContent();
        requestContent.Add(fileStreamContent, "UploadedFile", document.Name);
        requestContent.Add(new StringContent("1"), "InstitutionId");
        requestContent.Add(new StringContent("SecurePass!123"), "Password");
        requestContent.Add(new StringContent("teste@teste1.com"), "Email");
        await httpClient.PostAsync("/api/auth/student/register", requestContent);

        // Act
        var payload = "{\"email\": \"teste@teste1.com\", \"password\": \"SecurePass!123\"}";
        var response = await httpClient.PostAsync("/api/auth/login", new StringContent(payload, Encoding.UTF8, "application/json"));

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
    [Fact]
    public async Task VerifiedStudentShouldBeAbleToLogin()
    {
        var httpClient = _factory.CreateClient();
        var payload = "{\"email\": \"teste@teste2.com\", \"password\": \"SecurePass!123\"}";
        var response = await httpClient.PostAsync("/api/auth/login", new StringContent(payload, Encoding.UTF8, "application/json"));

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task StudentShouldBeAbleToRegister()
    {
        var httpClient = _factory.CreateClient();
        var document = File.OpenRead("WIN_20210413_15_23_53_Pro.jpg");

        HttpContent fileStreamContent = new StreamContent(document);
        fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
        var requestContent = new MultipartFormDataContent();
        requestContent.Add(fileStreamContent, "UploadedFile", document.Name);
        requestContent.Add(new StringContent("1"), "InstitutionId");
        requestContent.Add(new StringContent("SecurePass!123"), "Password");
        requestContent.Add(new StringContent("newuser@teste.com"), "Email");
        requestContent.Add(new StringContent("1"), "PreferredKnowledgeAreas");
        requestContent.Add(new StringContent("2"), "PreferredKnowledgeAreas");

        // Act
        var response = await httpClient.PostAsync("/api/auth/student/register", requestContent);

        // Assert
        using (var stream = await response.Content.ReadAsStreamAsync())
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var r = await JsonSerializer.DeserializeAsync<IdentityResultFake>(stream, options);

            Assert.True(r.Succeeded);
        }
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task WeakPasswordMustReturnError()
    {
        var client = _factory.CreateClient();
        var document = File.OpenRead("WIN_20210413_15_23_53_Pro.jpg");
        HttpContent fileStreamContent = new StreamContent(document);
        fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
        var requestContent = new MultipartFormDataContent();
        requestContent.Add(fileStreamContent, "UploadedFile", document.Name);
        requestContent.Add(new StringContent("1"), "InstitutionId");
        requestContent.Add(new StringContent("123123"), "Password");
        requestContent.Add(new StringContent("teste@teste1.com"), "Email");

        // Act
        var response = await client.PostAsync("/api/auth/student/register", requestContent);

        // Assert

        using (var stream = await response.Content.ReadAsStreamAsync())
        {
            var r = await JsonSerializer.DeserializeAsync<IdentityResultFake>(stream);

            Assert.True(!r.Succeeded);
        }
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    [Fact]
    public async Task InvalidInstitutionMustReturnException()
    {
        var client = _factory.CreateClient();
        var document = File.OpenRead("WIN_20210413_15_23_53_Pro.jpg");
        HttpContent fileStreamContent = new StreamContent(document);
        fileStreamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
        var requestContent = new MultipartFormDataContent
        {
            { fileStreamContent, "UploadedFile", document.Name },
            { new StringContent("2"), "InstitutionId" },
            { new StringContent("123123"), "Password" },
            { new StringContent("teste@teste1.com"), "Email" }
        };

        // Act
        var response = await client.PostAsync("/api/auth/student/register", requestContent);

        // Assert

        using (var stream = await response.Content.ReadAsStreamAsync())
        {
            var r = await JsonSerializer.DeserializeAsync<IdentityResultFake>(stream);

            Assert.True(!r.Succeeded);
            Assert.True(r.Errors.First().Code == "InstituitionNotFound");
        }

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

    }
}