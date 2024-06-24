using arbovirose.Application.Repositories;
using arbovirose.Application.Services;
using arbovirose.Domain.Exceptions;
using arbovirose.Domain.Factories;
using arbovirose.Domain.Dtos.InfoHome;
using System;
using System.Threading.Tasks;

namespace arbovirose.Application.Usecases.InfoHome
{
    public class DeleteInfoHome
    {
        private readonly IInfoHomeRepository _infoHomeRepository;
        private readonly IUploadService _uploadService;

        public DeleteInfoHome(IInfoHomeRepository infoHomeRepository, IUploadService uploadService)
        {
            _infoHomeRepository = infoHomeRepository;
            _uploadService = uploadService;
        }

        public async Task<bool> Execute(DeleteInfoHomeDTO data)
        {
            var infoHome = await _infoHomeRepository.GetById(data.Id);
            if (infoHome == null) throw new InvalidExistingInfoHome();

            var fileName = $"{infoHome.Id}_{data.OriginalFileName}.{data.TypeFile}";

            var resultDelete = _uploadService.Delete(fileName);
            if (!resultDelete) throw new InvalidDeleteFileException();

            var result = await _infoHomeRepository.Delete(data.Id);
            if (result == null) throw new InvalidDeleteInfoHomeException();

            return true;
        }
    }
}
