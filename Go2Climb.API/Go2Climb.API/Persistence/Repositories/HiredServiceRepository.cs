using System.Collections.Generic;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Repositories;
using Go2Climb.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Go2Climb.API.Persistence.Repositories
{
    public class HiredServiceRepository : BaseRepository, IHiredServiceRepository
    {
        public HiredServiceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<HiredService>> ListAsync()
        {
            return await _context.HideServices.ToListAsync();
        }

        public async Task AddAsync(HiredService service)
        {
            await _context.AddAsync(service);
        }

        public async Task<HiredService> FindByIdAsync(int id)
        {
            return await _context.HideServices.FindAsync(id);
        }

        public void Update(HiredService service)
        {
            _context.HideServices.Update(service);
        }

        public void Remove(HiredService service)
        {
            _context.HideServices.Remove(service);
        }
    }
}