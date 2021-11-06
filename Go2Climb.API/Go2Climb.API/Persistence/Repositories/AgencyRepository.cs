using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Repositories;
using Go2Climb.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Go2Climb.API.Persistence.Repositories
{
    public class AgencyRepository : BaseRepository, IAgencyRepository
    {
        public AgencyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Agency>> ListAsync()
        {
            return await _context.Agencies.ToListAsync();
        }

        public async Task<IEnumerable<Agency>> ListById(int id)
        {
            return await _context.Agencies.Where(p => p.Id == id).ToListAsync();
        }

        public async Task<IEnumerable<Agency>> ListByName(string name)
        {
            return await _context.Agencies.Where(p => p.Name == name).ToListAsync();
        }

        public async Task<Agency> FindById(int id)
        {
            return await _context.Agencies.FindAsync(id);
        }

        public async Task AddAsync(Agency agency)
        {
            await _context.Agencies.AddAsync(agency);
        }

        public void Update(Agency agency)
        {
            _context.Agencies.Update(agency);
        }

        public void Remove(Agency agency)
        {
            _context.Agencies.Update(agency);
        }
    }
}