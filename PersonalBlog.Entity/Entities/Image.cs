using PersonalBlog.Core.Entities;

namespace PersonalBlog.Entity.Entities;

public class Image: EntityBase, IEntityBase
{
    public Image()
    {
    }

    public Image(string fileName, string fileType)
    {
        FileName = fileName;
        FileType = fileType;
    }

    public Image(string fileName, string fileType, Guid createdById, string createdBy)
    {
        FileName = fileName;
        FileType = fileType;
        CreatedById = createdById;
        CreatedBy = createdBy;
    }
    public Image(string fileName, string fileType, Guid createdById, string createdBy, Guid imageId)
    {
        FileName = fileName;
        FileType = fileType;
        CreatedById = createdById;
        CreatedBy = createdBy;
        Id = imageId;
    }

    public string FileName { get; set; }
    public string FileType { get; set; }

}
