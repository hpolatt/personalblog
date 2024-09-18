using PersonalBlog.Entity.DTOs.Images;

namespace PersonalBlog.Service.Services.Abstractions;

public interface IImageService
{
    Task<List<ImageDto>> GetAllImagesAsync();
}
