using System;

namespace PersonalBlog.Entity.DTOs.Images;

public class ImageDto
{
    public Guid Id { get; set; }
    public string FileName { get; set; }
    public string FileType { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedTime { get; set; }
}
