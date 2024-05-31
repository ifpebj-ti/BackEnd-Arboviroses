using arbovirose.Application.Repositories;
using arbovirose.Domain.Entities;

namespace arbovirose.Infra.Database.Entityframework.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ArboviroseContext _context;
        public UserRepository(ArboviroseContext context) 
        {
            this._context = context;
        }
        public async Task<UserEntity> Create(UserEntity user)
        {
            this._context.Add(user);
            await this._context.SaveChangesAsync();
            return user;
        }
    }
}
