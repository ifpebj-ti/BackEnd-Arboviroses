using arbovirose.Domain.ValueObjects;

namespace arbovirose.Domain.Entities
{
    public class ProfileEntity
    {
        public ProfileEntity() { }
        public ProfileEntity(Office office)
        {
            this.Office = office;
        }
        public Guid Id { get; set; }
        public Office Office { get; set; } = null!;
        public ICollection<UserEntity> Users { get; set; } = null!;
    }
}
