using arbovirose.Domain.Entities;
using arbovirose.Domain.ValueObjects;


namespace arbovirose.Application.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> Create(UserEntity user);
        Task<UserEntity?> Deactivate(Guid id);
        Task<UserEntity?> FindByEmail(Email email);
        Task<UserEntity?> FindById(Guid id);
    }
}
