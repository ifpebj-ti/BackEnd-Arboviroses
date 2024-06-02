using arbovirose.Application.Repositories;
using arbovirose.Domain.Entities;
using arbovirose.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

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

        public async Task<UserEntity?> FindByEmail(Email email)
        {
            var user = await this._context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            return user;
        }

        public async Task<UserEntity?> FindById(Guid id)
        {
            var user = await this._context.Users.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }
    }
}
