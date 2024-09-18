
namespace PersonalBlog.Core.Entities;

public interface IEntityBase
{
    Guid Id { get; set; }
    string CreatedBy { get; set; }
    string? ModifiedBy { get; set; }
    string? DeletedBy { get; set; }
    DateTime CreatedTime { get; set; }
    DateTime? ModifiedTime { get; set; }
    DateTime? DeletedTime { get; set; }
    bool IsDeleted { get; set; }
    bool IsActive { get; set; }
}
