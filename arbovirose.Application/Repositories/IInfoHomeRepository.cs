using arbovirose.Domain.Entities;

namespace arbovirose.Application.Repositories
{
    public interface IInfoHomeRepository
    {
        Task<InfoHomeEntity> Add(InfoHomeEntity infoHome);
    }
}
