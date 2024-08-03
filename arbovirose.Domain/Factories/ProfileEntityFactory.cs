using arbovirose.Domain.Dtos.Profile;
using arbovirose.Domain.Entities;
using arbovirose.Domain.ValueObjects;

namespace arbovirose.Domain.Factories
{
    public class ProfileEntityFactory
    {
        public static ProfileEntity CreateProfileEntity(CreateProfileDTO data) 
        {
            return new ProfileEntity(
                new Office(data.Office)
            );
        } 
    }
}
