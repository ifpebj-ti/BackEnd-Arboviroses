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

            var newInfoHome = InfoHomeEntityFactory.CreateInfoHomeEntity(data);

            if (data.File != null && data.TypeFile != null && data.OriginalFileName != null && data.Size != 0)
            {
                var uploadData = InfoHomeEntityFactory.EditUploadDTO(data);
                
                var resultUpload = _uploadService.Delete(data.Id.ToString());

                resultUpload = _uploadService.Upload(uploadData);
                
                if (resultUpload != true) throw new InvalidUploadException();
            }

            InfoHomeEntity? result = null;

            if (existingInfoHome != null)
            {
                result = await _infoHomeRepository.Update(newInfoHome);
            }

            if (result == null) throw new InvalidEditInfoHomeException();

            return result;
        }
    }
}
