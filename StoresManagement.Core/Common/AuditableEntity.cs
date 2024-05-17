namespace StoresManagement.Core.Common;

public abstract class AuditableEntity : Entity
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}