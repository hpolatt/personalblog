using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PersonalBlog.Entity.DTOs.Images;

namespace PersonalBlog.Service.Helpers.Images;

public class ImageHelper : IImageHelper
{
    private readonly IWebHostEnvironment env;
    private readonly string wwwwroot;
    private const string imageFolder = "images";

    public ImageHelper(IWebHostEnvironment env)
    {
        this.env = env;
        wwwwroot = env.WebRootPath;
    }

    private string ReplaceInvlidChars(string name)
    {
        return name.Replace(" ", "-").Replace("ç", "c").Replace("ğ", "g").Replace("ı", "i").Replace("ö", "o").Replace("ş", "s").Replace("ü", "u").Replace("Ç", "C").Replace("Ğ", "G").Replace("İ", "I").Replace("Ö", "O").Replace("Ş", "S").Replace("Ü", "U");
    }

    public async Task<ImageUploadedDto> UploadImageAsync(string name, IFormFile imageFile, string entityFolder, string? folderName = null)
    {
        var imageName = ReplaceInvlidChars($"{name}-{Guid.NewGuid().ToString()}");
        var extension = Path.GetExtension(imageFile.FileName);
        var imageNameWithExtension = $"{imageName}{extension}";
        var folder = Path.Combine(wwwwroot, imageFolder, entityFolder, folderName ?? string.Empty);
        var path = Path.Combine(folder, imageNameWithExtension);
        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
        using (var stream = new FileStream(path, FileMode.Create))
        {
            await imageFile.CopyToAsync(stream);
        }
        return new ImageUploadedDto(Path.Combine(imageFolder, entityFolder, folderName ?? string.Empty, imageNameWithExtension));
    }
    public Task Delete(string imageName)
    {
        var path = Path.Combine(wwwwroot, imageName);
        if (File.Exists(path)) File.Delete(path);
        return Task.CompletedTask;
    }
}
