using Domain.Models.Masters;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.Masters;

public class SystemObjectViewConfig : IEntityTypeConfiguration<SystemObject>
{
    public void Configure(EntityTypeBuilder<SystemObject> builder)
    {
        builder.ToView("objects", SchemaNames.SystemSchema);
        ConfigureColumns(builder);
    }

    private static void ConfigureColumns(EntityTypeBuilder<SystemObject> builder)
    {
        builder.HasKey(col => col.ObjectId);

        builder.Property(col => col.Name).HasColumnName("name");
        builder.Property(col => col.ObjectId).HasColumnName("object_id");
        builder.Property(col => col.PrincipalId).HasColumnName("principal_id");
        builder.Property(col => col.SchemaId).HasColumnName("schema_id");
        builder.Property(col => col.ParentObjectId).HasColumnName("parent_object_id");
        builder.Property(col => col.Type).HasColumnName("type");
        builder.Property(col => col.TypeDescription).HasColumnName("type_desc");
        builder.Property(col => col.CreateDate).HasColumnName("create_date");
        builder.Property(col => col.ModifyDate).HasColumnName("modify_date");
        builder.Property(col => col.IsMsShipped).HasColumnName("is_ms_shipped");
        builder.Property(col => col.IsPublished).HasColumnName("is_published");
        builder.Property(col => col.IsSchemaPublished).HasColumnName("is_schema_published");
    }
}
