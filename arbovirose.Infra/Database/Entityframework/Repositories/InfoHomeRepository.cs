using arbovirose.Application.Repositories;
using arbovirose.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<InfoHomeEntity>> GetAll()
        {
            return await this._context.InfoHome.ToListAsync();
        }

        public async Task<InfoHomeEntity?> GetById(Guid id)
        {
            return await this._context.InfoHome.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<InfoHomeEntity> Update(InfoHomeEntity data)
        {
            this._context.Update(data);
            await this._context.SaveChangesAsync();
            return data;
        }

        public async Task<InfoHomeEntity?> Delete(Guid id)
        {
            var data = await this._context.InfoHome.FirstOrDefaultAsync(x => x.Id == id);
            if (data != null) this._context.Remove(data);
            await this._context.SaveChangesAsync();
            return data;
        }
    }
}
