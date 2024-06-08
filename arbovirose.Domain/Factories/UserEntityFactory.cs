using arbovirose.Domain.Dtos.User;
using arbovirose.Domain.Entities;
using arbovirose.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Domain.Factories
{
    public class UserEntityFactory
    {
        public static UserEntity CreateUserEntity(CreateUserDTO data) 
        {
            return new UserEntity(
                data.Name,
                new Email(data.Email),
                data.Password,
                data.ProfileId
            );
        }
    }
}
