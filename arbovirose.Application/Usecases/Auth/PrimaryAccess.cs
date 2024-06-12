using arbovirose.Application.Exceptions;
using arbovirose.Application.Repositories;
using arbovirose.Application.Services;
using arbovirose.Domain.Dtos.Auth;
using arbovirose.Domain.Factories;

namespace arbovirose.Application.Usecases.Auth
{
    public class PrimaryAccess
    {
        private readonly IUserRepository _userRepository;
        private readonly IBcryptService _bcryptService;
        public PrimaryAccess(IUserRepository userRepository, IBcryptService bcryptService)
        {
            this._userRepository = userRepository;
            this._bcryptService = bcryptService;
        }
        public async Task Execute(PrimaryAccessDTO data)
        {
            var userEmail = UserEntityFactory.CreateUserEmail(data.Email);
            var user = await _userRepository.FindByEmail(userEmail);
            if (user == null) throw new UserNotFoundException();

            user.VerifyUniqueCode(data.UniqueCode);

            var hashPassword = _bcryptService.GenerateHashPassword(data.Password);

            var result = await _userRepository.UpdatePassword(data.Password);
            if (result == null) throw new InvalidUserUpdatePassword();
        }
    }
}
