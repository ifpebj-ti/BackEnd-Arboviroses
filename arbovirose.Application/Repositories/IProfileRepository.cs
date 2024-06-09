using arbovirose.Domain.Entities;
using arbovirose.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Application.Repositories
{
    public interface IProfileRepository
    {
        Task<ProfileEntity> Create(ProfileEntity profile);
        Task<ProfileEntity?> FindByOffice(Office office);
    }
}
