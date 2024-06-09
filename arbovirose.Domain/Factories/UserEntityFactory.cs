using arbovirose.Domain.Dtos.User;
using arbovirose.Domain.Entities;
using arbovirose.Domain.ValueObjects;

namespace arbovirose.Domain.Factories
{
    public class UserEntityFactory
    {
        public static UserEntity CreateUserEntity(CreateUserDTO data) 
        {
            return new UserEntity(
                data.Name,
                new Email(data.Email),
                data.ProfileId
            );
        }
        public static Email CreateUserEmail(string email)
        {
            return new Email(email);
        }
    }
}
