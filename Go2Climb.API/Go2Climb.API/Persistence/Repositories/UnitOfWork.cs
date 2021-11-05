using System.Threading.Tasks;
using Go2Climb.API.Persistence.Contexts;

namespace Go2Climb.API.Persistence.Repositories
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;
        
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}