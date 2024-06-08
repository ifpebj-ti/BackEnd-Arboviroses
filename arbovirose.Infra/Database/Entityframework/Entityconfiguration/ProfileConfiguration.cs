using arbovirose.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace arbovirose.Infra.Database.Entityframework.Entityconfiguration
{
    public class ProfileConfiguration : IEntityTypeConfiguration<ProfileEntity>
    {
        public void Configure(EntityTypeBuilder<ProfileEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ComplexProperty(x => x.Office)
                .IsRequired();
            builder.HasMany(x => x.Users)
                .WithOne()
                .HasForeignKey(x => x.ProfileId);
        }
    }
}
