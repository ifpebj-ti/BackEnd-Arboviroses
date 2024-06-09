using arbovirose.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Application.Services
{
    public interface IBcryptService
    {
        bool VerifyUserPassword(UserEntity user, string password);
    }
}
