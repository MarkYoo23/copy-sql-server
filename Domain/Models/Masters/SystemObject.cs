using Domain.SeedWorks;

namespace Domain.Models.Masters;

public class SystemObject : ValueObject
{
    public string Name { get; set; } = string.Empty;
    public int ObjectId { get; set; }
    public int? PrincipalId { get; set; }
    public int SchemaId { get; set; }
    public int ParentObjectId { get; set; }
    public string Type { get; set; } = string.Empty;
    public string TypeDescription { get; set; } = string.Empty;
    public DateTime CreateDate { get; set; }
    public DateTime ModifyDate { get; set; }
    public bool IsMsShipped { get; set; }
    public bool IsPublished { get; set; }
    public bool IsSchemaPublished { get; set; }
}
