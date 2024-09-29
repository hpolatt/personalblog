using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text.Json;
using PersonalBlog.Entity.DTOs.GitHub;
using PersonalBlog.Entity.Entities;
using PersonalBlog.Service.Services.Abstractions;

namespace PersonalBlog.Service.Services.Concretes;

public class GitHubService : IGitHubService
{
     private readonly HttpClient _httpClient;

        public GitHubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.github.com/");
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Mozilla", "5.0"));
        }
    public async Task<List<GitHubProjectDto>> GetGithubProjects()
        {
            var response = await _httpClient.GetAsync("users/hpolatt/repos");
            response.EnsureSuccessStatusCode();

            var responseStream = await response.Content.ReadAsStreamAsync();
            var projects = await JsonSerializer.DeserializeAsync<List<GitHubProjectDto>>(responseStream);

            return projects.Where(project => project.Name != "hpolatt").ToList();
        }
}
