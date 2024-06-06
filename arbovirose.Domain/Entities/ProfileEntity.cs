using arbovirose.Domain.ValueObjects;

namespace arbovirose.Domain.Entities
{
    public class ProfileEntity
    {
        public ProfileEntity() { }
        public Guid Id { get; set; }
        public Office Office { get; set; } = null!;
        public ICollection<UserEntity> Users { get; set; } = null!;
    }
}
