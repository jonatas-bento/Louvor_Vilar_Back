using Microsoft.EntityFrameworkCore;
using Portal_ELIPBVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_ELIPBVC.Domain.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly ApplicationDbContext _context;

        public EventoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Evento>> GetAll()
        {
            IQueryable<Evento> eventos = _context.Eventos.AsNoTracking();
            if (eventos == null)
                return null;

            return await eventos.ToListAsync();
        }

        public async Task<Evento> GetBy(int id)
        {
            IQueryable<Evento> eventos = _context.Eventos.AsNoTracking();
            var result = eventos.OrderBy(x => x.Id)
                .Where(x => x.Id == id);

            return await result.FirstOrDefaultAsync();
        }
    }
}
