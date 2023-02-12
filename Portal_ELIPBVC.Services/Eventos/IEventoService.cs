using Portal_ELIPBVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_ELIPBVC.Services.Eventos
{
    public interface IEventoService
    {
        Task<Evento> AddEvento(Evento model);
        Task<List<Evento>> GetEventos();
        Task<Evento> GetBy(int EventoId);
        Task<Evento> UpdateEvento(int id, Evento model);
        Task<bool> DeleteEvento(int id);
    }
}
