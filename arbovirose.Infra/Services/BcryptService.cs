using arbovirose.Application.Services;
using arbovirose.Domain.Entities;
using BCrypt.Net;
using static BCrypt.Net.BCrypt;

namespace arbovirose.Infra.Services
{
    public class BcryptService : IBcryptService
    {
        private const int WorkFactor = 12;
        public bool VerifyUserPassword(UserEntity user, string password)
        {
            var passwordMatch = Verify(password, user.Password);
            return passwordMatch;
        }
    }
}
