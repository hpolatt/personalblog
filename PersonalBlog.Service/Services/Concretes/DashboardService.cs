using System;
using PersonalBlog.Data.UnitOfWorks;
using PersonalBlog.Entity.Entities;
using PersonalBlog.Service.Services.Abstractions;

namespace PersonalBlog.Service.Services.Concretes;

public class DashboardService : IDashboardService
{
    private readonly IUnitofWork unitofWork;

    public DashboardService(IUnitofWork unitofWork)
    {
        this.unitofWork = unitofWork;
    }

    public async Task<List<int>> GetYearlyArticleCount()
    {
        var articles = await unitofWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted);
        // startdate is start of this year
        DateTime startDate = new DateTime(DateTime.Now.Year, 1, 1);
        
        List<int> articleCounts = new();

        for (int i = 1; i <= 12; i++)
        {
            DateTime endDate = startDate.AddMonths(1);
            articleCounts.Add(articles.Count(x => x.CreatedTime >= startDate && x.CreatedTime < endDate));
            startDate = endDate; 
        }
        
        return articleCounts;        
    }
}
