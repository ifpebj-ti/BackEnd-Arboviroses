using arbovirose.Application.Repositories;
using arbovirose.Domain.Entities;
using arbovirose.Domain.Exceptions;

namespace arbovirose.Application.Usecases.InfoHome
{
    public class GetAllInfoHome
    {
        private readonly IInfoHomeRepository _infoHomeRepository;

        public GetAllInfoHome(IInfoHomeRepository infoHomeRepository)
        {
            _infoHomeRepository = infoHomeRepository;
        }

        public async Task<IEnumerable<InfoHomeEntity>> Execute()
        {
            var result = await _infoHomeRepository.GetAll();

            if (result == null) throw new InvalidGetAllInfoHomeException();

            return result;
        }
    }
}
