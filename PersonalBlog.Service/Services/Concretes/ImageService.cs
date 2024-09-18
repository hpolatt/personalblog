using System;
using AutoMapper;
using PersonalBlog.Data.UnitOfWorks;
using PersonalBlog.Entity.DTOs.Images;
using PersonalBlog.Entity.Entities;
using PersonalBlog.Service.Services.Abstractions;

namespace PersonalBlog.Service.Services.Concretes;

public class ImageService : IImageService
{
    public readonly IUnitofWork unitofWork;
    private readonly IMapper mapper;

    public ImageService(IUnitofWork unitofWork, IMapper mapper)
    {
        this.unitofWork = unitofWork;
        this.mapper = mapper;
    }

    public async Task<List<ImageDto>> GetAllImagesAsync()
    {
        var images = await unitofWork.GetRepository<Image>().GetAllAsync();
        return mapper.Map<List<ImageDto>>(images);
    }
}
