using arbovirose.Domain.Dtos.InfoHome;
using arbovirose.Domain.Entities;

namespace arbovirose.Application.Repositories
{
    public interface IInfoHomeRepository
    {
        Task<InfoHomeEntity> Add(InfoHomeEntity infoHome);
        Task<IEnumerable<InfoHomeEntity>> GetAll();
        Task<InfoHomeEntity> Update(InfoHomeEntity infoHome);
        Task<InfoHomeEntity?> GetById(Guid id);
        Task<InfoHomeEntity?> Delete(Guid id);
    }
}
