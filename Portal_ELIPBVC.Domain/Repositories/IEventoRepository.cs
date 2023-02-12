using Portal_ELIPBVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_ELIPBVC.Domain.Repositories
{
    public interface IEventoRepository
    {
        Task<List<Evento>> GetAll();
        Task<Evento> GetBy(int id);
    }
}
