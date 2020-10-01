using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGE.DataAccess.Entities;
using SGE.DataAccess.Mapping.Base;
using SGE.DataAccess.Mapping.DbTypes;
using SGE.DataAccess.Types;

namespace SGE.DataAccess.Mapping
{
    public class UserMap : BaseMap<User>
    {
        protected UserMap(EntityTypeBuilder<User> builder) : base(builder)
        {
            builder.ToTable("user");

            builder.Property(prop => prop.Name).HasColumnName("name").HasColumnType(DbType.Varchar).IsRequired();
            builder.Property(prop => prop.Surname).HasColumnName("surname").HasColumnType(DbType.Varchar).IsRequired();
            builder.Property(prop => prop.Cpf).HasColumnName("cpf").HasColumnType(DbType.Varchar).HasMaxLength(11).IsRequired();
            builder.Property(prop => prop.Email).HasColumnName("email").HasColumnType(DbType.Varchar).HasMaxLength(50).IsRequired();
            builder.Property(prop => prop.AddressId).HasColumnName("address_id").IsRequired();

            #region Relashionship
            builder.HasOne(entity => entity.Address).WithMany(entities => entities.Users).HasForeignKey(fk => fk.AddressId);
            #endregion
    }
}
}
