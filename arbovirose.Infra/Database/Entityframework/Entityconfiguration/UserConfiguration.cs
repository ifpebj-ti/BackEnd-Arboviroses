using arbovirose.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace arbovirose.Infra.Database.Entityframework.Entityconfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder) 
        {
            builder.HasKey(x => x.Id);
            builder.Property(u => u.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.ComplexProperty(u => u.Email)
                .IsRequired();
            builder.Property(u => u.Password)
                .HasColumnType("varchar(255)")
                .IsRequired();
            builder.ComplexProperty(u => u.UniqueCode)
                .IsRequired();
            builder.Property(u => u.Active)
                .IsRequired();

        }
    }
}
