using System.Text.Json.Serialization;

namespace Functional.Tests;
internal class ApplicationUserOutputDTOFake
{
    [JsonPropertyName("token")]
    public string Token { get; set; }
    [JsonPropertyName("role")]
    public string Role { get; set; }
    [JsonPropertyName("userName")]
    public string UserName { get; set; }
}