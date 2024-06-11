using arbovirose.Application.Exceptions;
using arbovirose.Application.Repositories;
using arbovirose.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbovirose.Application.Usecases.User
{
    public class GetAllUser
    {
        private readonly IUserRepository _userRepository;
        public GetAllUser(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task<IEnumerable<UserEntity>> Execute()
        {
            var users = await _userRepository.GetAll();
            if (users == null) throw new UserNotFoundException();
            return users;
        }
    }
}
