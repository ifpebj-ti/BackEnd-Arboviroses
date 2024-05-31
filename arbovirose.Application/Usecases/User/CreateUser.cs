using arbovirose.Application.Exceptions;
using arbovirose.Application.Repositories;
using arbovirose.Domain.Dtos.User;
using arbovirose.Domain.Entities;
using arbovirose.Domain.Factories;

namespace arbovirose.Application.Usecases.User
{
    public class CreateUser
    {
        private readonly IUserRepository _userRepository;
        public CreateUser(IUserRepository userRepository) 
        {
            this._userRepository = userRepository;
        }
        public async Task<UserEntity> Execute(CreateUserDTO data) 
        {
            var newUser = UserEntityFactory.CreateUserEntity(data);

            //var user = await _userRepository.FindByEmail(newUser.Email);
            //if (user) throw new UserAlreadyExistException();

            var result = await _userRepository.Create(newUser);

            if (result == null) throw new InvalidCreateUserException();

            return result;
        }
    }
}
