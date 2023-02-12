using Portal_ELIPBVC.Domain.Entities;
using Portal_ELIPBVC.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_ELIPBVC.Services.Eventos
{
    public class EventoService : IEventoService
    {
        private readonly IRepository _repository;
        private readonly IEventoRepository _eventoRepository;

        public EventoService(IRepository repository, IEventoRepository eventoRepository)
        {
            _repository = repository;
            _eventoRepository = eventoRepository;
        }
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _repository.Add<Evento>(model);
                if (await _repository.SaveChangesAsync())
                {
                    return await _eventoRepository.GetBy(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int id)
        {
            try
            {
                var evento = _eventoRepository.GetBy(id);
                if (evento == null)
                    throw new Exception("O dado não pôde ser encontrado ou não existe");

                _repository.Delete(evento);
                return await _repository.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetBy(int EventoId)
        {
            try
            {
                var evento = await _eventoRepository.GetBy(EventoId);
                if (evento == null)
                    return null;

                return evento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Evento>> GetEventos()
        {
            try
            {
                var eventos = await _eventoRepository.GetAll();
                if (eventos == null)
                    return null;

                return eventos;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> UpdateEvento(int id, Evento model)
        {
            try
            {
                var evento = await _eventoRepository.GetBy(id);
                if (evento == null)
                    return null;

                model.Id = evento.Id;

                _repository.Update<Evento>(model);

                if (await _repository.SaveChangesAsync())
                {
                    return await _eventoRepository.GetBy(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

