using arbovirose.Application.Repositories;
using arbovirose.Domain.Entities;
using arbovirose.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Infra.Database.Entityframework.Repositories
{
    public class ProfileRepository: IProfileRepository
    {
        private readonly ArboviroseContext _context;
        public ProfileRepository(ArboviroseContext context)
        {
            this._context = context;
        }
        public async Task<ProfileEntity> Create(ProfileEntity profile)
        {
            this._context.Add(profile);
            await this._context.SaveChangesAsync();
            return profile;
        }

        public async Task<ProfileEntity?> FindByOffice(Office office)
        {
            var profile = await this._context.Profiles.Where(p => p.Office == office).FirstOrDefaultAsync();
            return profile;
        }
    }
}
