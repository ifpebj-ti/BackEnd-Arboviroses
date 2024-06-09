using arbovirose.Application.Exceptions;
using arbovirose.Application.Repositories;
using arbovirose.Domain.Dtos.Profile;
using arbovirose.Domain.Entities;
using arbovirose.Domain.Factories;

namespace arbovirose.Application.Usecases.Profile
{
    public class CreateProfile
    {
        private readonly IProfileRepository _profileRepository;
        public CreateProfile(IProfileRepository profileRepository)
        {
            this._profileRepository = profileRepository;
        }
        public async Task<ProfileEntity> Execute(CreateProfileDTO data)
        {
            var newProfile = ProfileEntityFactory.CreateProfileEntity(data);
            var profile = await _profileRepository.FindByOffice(newProfile.Office);
            if (profile != null) throw new ProfileAlreadyExistException();

            var result = await _profileRepository.Create(newProfile);
            if (result == null) throw new InvalidCreateProfileException();

            return result;
        }
    }
}
