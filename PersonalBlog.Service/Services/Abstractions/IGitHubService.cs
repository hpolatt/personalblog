using System;
using PersonalBlog.Entity.DTOs.GitHub;

namespace PersonalBlog.Service.Services.Abstractions;

public interface IGitHubService
{
    Task<List<GitHubProjectDto>> GetGithubProjects();
}
