using arbovirose.Application.Exceptions;
using arbovirose.Application.Repositories;
using arbovirose.Domain.Entities;

namespace arbovirose.Application.Usecases.User
{
    public class DeactivateUser
    {
        private readonly IUserRepository _userRepository;
        public DeactivateUser(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task<UserEntity> Execute(Guid id)
        {
            var result = await _userRepository.Deactivate(id);

            if (result == null) throw new UserNotFoundException();

            return result;
        }
    }
}
