using arbovirose.Application.Repositories;
using arbovirose.Domain.Entities;

namespace arbovirose.Infra.Database.Entityframework.Repositories
{
    public class InfoHomeRepository : IInfoHomeRepository
    {
        private readonly ArboviroseContext _context;
        public InfoHomeRepository(ArboviroseContext context)
        {
            _context = context;
        }
        public async Task<InfoHomeEntity> Add(InfoHomeEntity data)
        {
            this._context.Add(data);
            await this._context.SaveChangesAsync();
            return data;
        }
    }
}
