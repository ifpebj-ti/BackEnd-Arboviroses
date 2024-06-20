using arbovirose.Application.Repositories;
using arbovirose.Application.Services;
using arbovirose.Domain.Dtos.InfoHome;
using arbovirose.Domain.Entities;
using arbovirose.Domain.Exceptions;
using arbovirose.Domain.Factories;

namespace arbovirose.Application.Usecases.InfoHome
{
    public class AddInfoHome
    {
        private readonly IInfoHomeRepository _infoHomeRepository;
        private readonly IUploadService _uploadService;
        public AddInfoHome(IInfoHomeRepository infoHomeRepository, IUploadService uploadService)
        {
            _infoHomeRepository = infoHomeRepository;
            _uploadService = uploadService;
        }
        public async Task<InfoHomeEntity> Execute(AddInfoHomeDTO data)
        {
            var newInfoHome = InfoHomeEntityFactory.CreateInfoHomeEntity(data);
            var uploadData = InfoHomeEntityFactory.CreateUploadDTO(newInfoHome, data);

            var resultUpload = _uploadService.Upload(uploadData);
            if (resultUpload != true) throw new InvalidUploadException();

            var result = await _infoHomeRepository.Add(newInfoHome);
            if (result == null) throw new InvalidAddInfoHomeException();

            return result;
        }
    }
}
