using arbovirose.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace arbovirose.Infra.Database.Entityframework
{
    public class ArboviroseContext : DbContext
    {
        public ArboviroseContext(DbContextOptions<ArboviroseContext> options) : base(options)
        {

        }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProfileEntity> Profiles { get; set; }
        public DbSet<InfoHomeEntity> InfoHome { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArboviroseContext).Assembly);
        }

    }
}
