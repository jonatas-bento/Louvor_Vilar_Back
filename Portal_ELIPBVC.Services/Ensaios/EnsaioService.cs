using Portal_ELIPBVC.Domain.Entities;
using Portal_ELIPBVC.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_ELIPBVC.Services.Ensaios
{
    public class EnsaioService : IEnsaioService
    {
        private readonly IRepository _repository;
        private readonly IEnsaioRepository _ensaioRepository;

        public EnsaioService(IRepository repository, IEnsaioRepository ensaioRepository)
        {
            _repository = repository;
            _ensaioRepository = ensaioRepository;
        }
        public async Task<Ensaio> AddEnsaio(Ensaio model)
        {
            try
            {
                _repository.Add<Ensaio>(model);
                if (await _repository.SaveChangesAsync())
                {
                    return await _ensaioRepository.GetBy(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEnsaio(int id)
        {
            try
            {
                var ensaio = _ensaioRepository.GetBy(id);
                if (ensaio == null)
                    throw new Exception("O dado não pôde ser encontrado ou não existe");

                _repository.Delete(ensaio);
                return await _repository.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Ensaio> GetBy(int EnsaioId)
        {
            try
            {
                var ensaio = await _ensaioRepository.GetBy(EnsaioId);
                if (ensaio == null)
                    return null;

                return ensaio;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Ensaio>> GetEnsaios()
        {
            try
            {
                var ensaios = await _ensaioRepository.GetAll();
                if (ensaios == null)
                    return null;

                return ensaios;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Ensaio> UpdateEnsaio(int id, Ensaio model)
        {
            try
            {
                var ensaio = await _ensaioRepository.GetBy(id);
                if (ensaio == null)
                    return null;

                model.Id = ensaio.Id;

                _repository.Update<Ensaio>(model);

                if (await _repository.SaveChangesAsync())
                {
                    return await _ensaioRepository.GetBy(model.Id);
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
