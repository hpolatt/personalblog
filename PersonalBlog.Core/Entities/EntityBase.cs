namespace PersonalBlog.Core.Entities;

public class EntityBase : IEntityBase
{
    public virtual Guid Id { get; set; } = Guid.NewGuid();
    public Guid CreatedById { get; set; }
    public Guid? ModifiedById { get; set; }
    public Guid? DeletedById { get; set; }
    public string CreatedBy { get; set; } = String.Empty;
    public string? ModifiedBy { get; set; }
    public string? DeletedBy { get; set; }
    public virtual DateTime CreatedTime { get; set; } = DateTime.Now;
    public virtual DateTime? ModifiedTime { get; set; }
    public virtual DateTime? DeletedTime { get; set; }
    public virtual bool IsDeleted { get; set; } = false;
    public virtual bool IsActive { get; set; } = true;
}
