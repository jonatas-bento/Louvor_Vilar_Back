using Microsoft.EntityFrameworkCore;
using Portal_ELIPBVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_ELIPBVC.Domain.Repositories
{
    public class MembroRepository : IMembroRepository
    {
        private readonly ApplicationDbContext _context;

        public MembroRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Membro>> GetAll()
        {
            IQueryable<Membro> membros = _context.Membros.AsNoTracking();
            if (membros == null)
                return null;

            return await membros.ToListAsync();
        }

        public async Task<Membro> GetBy(int id)
        {
            IQueryable<Membro> membros = _context.Membros.AsNoTracking();
            var result = membros.OrderBy(x => x.Id)
                .Where(x => x.Id == id);

            return await result.FirstOrDefaultAsync();
        }
    }
}
