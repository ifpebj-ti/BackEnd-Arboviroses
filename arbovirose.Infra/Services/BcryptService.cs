using arbovirose.Application.Services;
using arbovirose.Domain.Entities;
using static BCrypt.Net.BCrypt;

namespace arbovirose.Infra.Services
{
    public class BcryptService : IBcryptService
    {
        private const int WorkFactor = 12;

        public string GenerateHashPassword(string password)
        {
            var hashedPassword = HashPassword(password, WorkFactor);
            return hashedPassword;
        }

        public bool VerifyUserPassword(UserEntity user, string password)
        {
            var passwordMatch = Verify(password, user.Password);
            return passwordMatch;
        }
    }
}
