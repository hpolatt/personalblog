using System;
using FluentValidation;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Service.Services.FluentValidation;

public class ArticleValidator : AbstractValidator<Article>
{
    public ArticleValidator()
    {
        RuleFor(x => x.Title)
        .NotEmpty()
        .NotNull()
        .MinimumLength(5)
        .WithName("Title");
    
        RuleFor(x => x.Content)
        .NotEmpty()
        .NotNull()
        .MinimumLength(20)
        .WithName("Content");

        RuleFor(x => x.CategoryId)
        .NotEmpty()
        .NotNull();
        
    }
}
