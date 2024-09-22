using System;
using Microsoft.AspNetCore.Http;
using PersonalBlog.Entity.DTOs.Images;

namespace PersonalBlog.Service.Helpers.Images;

public interface IImageHelper
{
    Task<ImageUploadedDto> UploadImageAsync(string name, IFormFile imageFile, string entityFolder, string? folderName = null);

    void Delete(string imageName);
}
