using System;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PersonalBlog.Service.Services;

public static class FluentValidationExtension
{
    public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState) 
  {
    foreach (var error in result.Errors) 
    {
      modelState.AddModelError(error.PropertyName, error.ErrorMessage);
    }
  }
}
