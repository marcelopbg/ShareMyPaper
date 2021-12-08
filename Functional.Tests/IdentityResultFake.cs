using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Auth.Test;
public class IdentityResultFake
{
    [JsonPropertyName("errors")]
    public IEnumerable<ErrorsFake> Errors { get; set; }
    [JsonPropertyName("succeeded")]
    public bool Succeeded { get; set; }

}

public class ErrorsFake
{
    [JsonPropertyName("code")]
    public string Code { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
}