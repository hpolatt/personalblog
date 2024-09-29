using System;
using System.Text.Json.Serialization;

namespace PersonalBlog.Entity.DTOs.GitHub;

public class GitHubProjectDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("description")]
    public string Description { get; set; }
    
    [JsonPropertyName("html_url")]
    public string HtmlUrl { get; set; }
    
    [JsonPropertyName("topics")]
    public List<string>? Topics { get; set; }
    
    [JsonPropertyName("language")]
    public string Language { get; set; }

}
