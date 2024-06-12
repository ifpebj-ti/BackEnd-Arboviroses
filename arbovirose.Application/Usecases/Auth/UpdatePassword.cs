using arbovirose.Application.Exceptions;
using arbovirose.Application.Repositories;
using arbovirose.Application.Services;
using arbovirose.Domain.Dtos.Auth;
using arbovirose.Domain.Factories;

namespace arbovirose.Application.Usecases.Auth
{
    public class UpdatePassword
    {
        private readonly IUserRepository _userRepository;
        private readonly IBcryptService _bcryptService;
        public UpdatePassword(IUserRepository userRepository, IBcryptService bcryptService)
        {
            _userRepository = userRepository;
            _bcryptService = bcryptService;
        }
        public async Task Execute(UpdatePasswordDTO data)
        {
            var userEmail = UserEntityFactory.CreateUserEmail(data.Email);
            var user = await _userRepository.FindByEmail(userEmail);
            if (user == null) throw new UserNotFoundException();

            user.VerifyUniqueCode(data.UniqueCode);

            var hashPassword = _bcryptService.GenerateHashPassword(data.Password);

            await _userRepository.UpdatePassword(user.Id, hashPassword);
        }
    }
}
