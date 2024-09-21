using System;
using FluentValidation;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Service.Services.FluentValidation;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Name).MaximumLength(50);

        RuleFor(x => x.Description).MaximumLength(200);
    }

}
