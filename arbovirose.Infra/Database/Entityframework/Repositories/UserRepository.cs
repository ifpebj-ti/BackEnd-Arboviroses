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

        public async Task<UserEntity?> Deactivate(Guid id)
        {
            var user = await this._context.Users.FindAsync(id);
            if (user == null) return null;
            user.Active = false;
            await this._context.SaveChangesAsync();
            return user;
        }


    }
}
