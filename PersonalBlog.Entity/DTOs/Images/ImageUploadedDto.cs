using System;

namespace PersonalBlog.Entity.DTOs.Images;

public class ImageUploadedDto
{
    public ImageUploadedDto()
    {
    }

    public ImageUploadedDto(string fileName)
    {
        FileName = fileName;
    }
    public string FileName { get; set; }
}
