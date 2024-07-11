using arbovirose.Application.Repositories;
using arbovirose.Application.Services;
using arbovirose.Domain.Dtos.InfoHome;
using arbovirose.Domain.Entities;
using arbovirose.Domain.Exceptions;
using arbovirose.Domain.Factories;

namespace arbovirose.Application.Usecases.InfoHome
{
    public class EditInfoHome
    {
        private readonly IInfoHomeRepository _infoHomeRepository;
        private readonly IUploadService _uploadService;
        public EditInfoHome(IInfoHomeRepository infoHomeRepository, IUploadService uploadService)
        {
            _infoHomeRepository = infoHomeRepository;
            _uploadService = uploadService;
        }

        public async Task<InfoHomeEntity> Execute(EditInfoHomeDTO data)
        {
            var existingInfoHome = await _infoHomeRepository.GetById(data.Id);
            if (existingInfoHome == null) throw new InvalidExistingInfoHome();

            existingInfoHome.Topic = data.Topic;
            existingInfoHome.Title = data.Title;
            existingInfoHome.TitleLink = data.TitleLink;
            existingInfoHome.Link = data.Link;

            if (data.File != null && data.TypeFile != null && data.OriginalFileName != null && data.Size != null)
            {
                var uploadData = InfoHomeEntityFactory.CreateUploadDTO(existingInfoHome, data);

                var resultUpload = _uploadService.Upload(uploadData);
                if (resultUpload != true) throw new InvalidUploadException();
            }

            var result = await _infoHomeRepository.Update(existingInfoHome);
            if (result == null) throw new InvalidEditInfoHomeException();

            return result;
        }
    }
}
