using arbovirose.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace arbovirose.Infra.Database.Entityframework.Entityconfiguration
{
    public class InfoHomeConfiguration : IEntityTypeConfiguration<InfoHomeEntity>
    {
        public void Configure(EntityTypeBuilder<InfoHomeEntity> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Topic)
                .HasColumnType("varchar(50)");
            builder.Property(i => i.Title)
                .HasColumnType("varchar(50)")
                .IsRequired();
            builder.Property(i => i.TitleLink)
                .HasColumnType("varchar(100)");
            builder.Property(i => i.Link)
                .HasColumnType("varchar(100)")
                .IsRequired();
        }
    }
}
