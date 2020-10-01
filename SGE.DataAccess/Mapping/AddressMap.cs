using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGE.DataAccess.Entities;
using SGE.DataAccess.Mapping.Base;
using SGE.DataAccess.Mapping.DbTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGE.DataAccess.Mapping
{
    public class AddressMap : BaseMap<Address>
    {
        public AddressMap(EntityTypeBuilder<Address> builder) : base(builder)
        {
            builder.ToTable("address");
            builder.Property(prop => prop.Cep).HasColumnName("cep").HasColumnType(DbType.Varchar);

            #region Relationships
            builder.HasMany(entities => entities.Schools).WithOne(entity => entity.Address).HasForeignKey(key => key.AddressId);
            #endregion
        }
    }
}
