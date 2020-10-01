using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGE.DataAccess.Mapping.Base;
using SGE.DataAccess.Mapping.DbTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.DataAccess.Entities
{
    public class SchoolMap : BaseMap<School>
    {
        public SchoolMap(EntityTypeBuilder<School> builder) : base(builder)
        {
            builder.ToTable("school");

            builder.Property(prop => prop.Name).HasColumnName("name").HasColumnType(DbType.Varchar).IsRequired();
            builder.Property(prop => prop.Cnpj).HasColumnName("cnpj").HasMaxLength(14).IsFixedLength().IsRequired();
            builder.Property(prop => prop.AddressId).HasColumnName("address_id").IsRequired();
        }
    }
}
