using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Go2Climb.API.Domain.Models;
using Go2Climb.API.Domain.Repositories;
using Go2Climb.API.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Go2Climb.API.Persistence.Repositories
{
    public class ServiceRepository : BaseRepository, IServiceRepository
    {
        public ServiceRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Service>> ListAsync()
        {
            return await _context.Services.ToListAsync();
        }

        public async Task<IEnumerable<Service>> ListByAgencyId(int agencyId)
        {
            return await _context.Services.Where(b => b.AgencyId == agencyId).Include(b => b.Agency).ToListAsync();
        }

        public async Task<IEnumerable<Service>> ListByName(string name)
        {
            return await _context.Services.Where(b => b.Name == name).ToListAsync();
        }

        public async Task<IEnumerable<Service>> ListById(int id)
        {
            return await _context.Services.Where(p => p.Id == id).ToListAsync();
        }

        public async Task<Service> FindById(int id)
        {
            return await _context.Services.FindAsync(id);
        }

        public async Task AddAsync(Service service)
        {
            await _context.Services.AddAsync(service);
        }

        public void Update(Service service)
        {
            _context.Services.Update(service);
        }

        public void Remove(Service service)
        {
            _context.Services.Remove(service);
        }
    }
}