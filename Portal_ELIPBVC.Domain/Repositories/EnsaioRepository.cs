using Microsoft.EntityFrameworkCore;
using Portal_ELIPBVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_ELIPBVC.Domain.Repositories
{
    public class EnsaioRepository : IEnsaioRepository
    {
        private readonly ApplicationDbContext _context;
        public EnsaioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Ensaio>> GetAll()
        {
            IQueryable<Ensaio> ensaios = _context.Ensaios.AsNoTracking();
            if (ensaios == null)
                return null;

            return await ensaios.ToListAsync();
        }

        public async Task<Ensaio> GetBy(int id)
        {
            IQueryable<Ensaio> ensaios = _context.Ensaios.AsNoTracking();
            var result = ensaios.OrderBy(x => x.Id)
                .Where(x => x.Id == id);

            return await result.FirstOrDefaultAsync();
        }
    }
}
