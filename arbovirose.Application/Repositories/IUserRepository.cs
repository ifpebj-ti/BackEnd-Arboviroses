using arbovirose.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Application.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> Create(UserEntity user);
    }
}
