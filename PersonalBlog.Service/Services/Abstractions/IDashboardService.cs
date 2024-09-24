using System;

namespace PersonalBlog.Service.Services.Abstractions;

public interface IDashboardService
{
    Task<List<int>> GetYearlyArticleCount();
}
