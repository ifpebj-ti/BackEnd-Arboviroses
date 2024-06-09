using arbovirose.Domain.Entities;

namespace arbovirose.Application.Services
{
    public interface ITokenService
    {
        string? CreateToken(UserEntity user);
    }
}
