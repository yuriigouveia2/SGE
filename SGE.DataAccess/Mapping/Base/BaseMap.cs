using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGE.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.DataAccess.Mapping.Base
{
    public class BaseMap<T> where T : BaseEntity
    {
        protected BaseMap(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(key => key.Id);
            builder.Property(prop => prop.Id).HasColumnName("id").IsRequired().ValueGeneratedNever();
            builder.Property(prop => prop.CreatedAt).HasColumnName("created_at").HasDefaultValue(DateTime.Now).IsRequired();
            builder.Property(prop => prop.UpdatedAt).HasColumnName("updated_at");
            builder.Property(prop => prop.Deleted).HasColumnName("deleted").HasDefaultValue(false).IsRequired();

            builder.Ignore(prop => prop.IsValid);
        }
    }
}
