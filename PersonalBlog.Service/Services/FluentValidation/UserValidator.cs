using System;
using FluentValidation;
using PersonalBlog.Entity.Entities;

namespace PersonalBlog.Service.Services.FluentValidation;

public class UserValidator : AbstractValidator<AppUser>
{
    public UserValidator()
    {
        RuleFor(x => x.FirstName)
        .NotEmpty();

        RuleFor(x => x.LastName)
        .NotEmpty();
    }
}
