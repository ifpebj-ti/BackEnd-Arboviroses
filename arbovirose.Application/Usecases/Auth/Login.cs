using arbovirose.Application.Exceptions;
using arbovirose.Application.Repositories;
using arbovirose.Application.Services;
using arbovirose.Domain.Dtos.Auth;
using arbovirose.Domain.Factories;

namespace arbovirose.Application.Usecases.Auth
{
    public class Login
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IBcryptService _bcryptService;
        public Login(IUserRepository userRepository, ITokenService tokenService, IBcryptService bcryptService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _bcryptService = bcryptService;
        }
        public async Task<string> Execute(LoginDTO data)
        {
            var userEmail = UserEntityFactory.CreateUserEmail(data.Email);
            var user = await _userRepository.FindByEmail(userEmail);
            if (user == null) throw new UserNotFoundException();

            if (user.PrimaryAccess)
            {
                var result = _bcryptService.VerifyUserPassword(user, data.Password);
                if (!result) throw new InvalidUserPassword();
            }
            else
            {
                user.VerifyGenericPassword(user.Password);
            }

            var token = _tokenService.CreateToken(user);
            if (token == null) throw new TokenNotGeneratedException();

            return token;
        }
    }
}
