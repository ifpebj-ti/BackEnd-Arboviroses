using Microsoft.EntityFrameworkCore;

namespace arbovirose.Infra.Database.Entityframework
{
    public class ArboviroseContext : DbContext
    {
        public ArboviroseContext(DbContextOptions<ArboviroseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArboviroseContext).Assembly);
        }

    }
}
