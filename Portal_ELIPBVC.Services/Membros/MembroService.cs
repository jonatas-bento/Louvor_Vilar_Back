using Portal_ELIPBVC.Domain.Entities;
using Portal_ELIPBVC.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_ELIPBVC.Services.Membros
{
    public class MembroService : IMembroService
    {
        private readonly IRepository _repository;
        private readonly IMembroRepository _membroRepository;

        public MembroService(IRepository repository, IMembroRepository membroRepository)
        {
            _repository = repository;
            _membroRepository = membroRepository;
        }
        public async Task<Membro> AddMembro(Membro model)
        {
            try
            {
                _repository.Add<Membro>(model);
                if (await _repository.SaveChangesAsync())
                {
                    return await _membroRepository.GetBy(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteMembro(int id)
        {
            try
            {
                var membro = _membroRepository.GetBy(id);
                if (membro == null)
                    throw new Exception("O dado não pôde ser encontrado ou não existe");

                _repository.Delete(membro);
                return await _repository.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Membro> GetBy(int MembroId)
        {
            try
            {
                var membro = await _membroRepository.GetBy(MembroId);
                if (membro == null)
                    return null;

                return membro;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Membro>> GetMembros()
        {
            try
            {
                var membros = await _membroRepository.GetAll();
                if (membros == null)
                    return null;

                return membros;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Membro> UpdateMembro(int id, Membro model)
        {
            try
            {
                var membro = await _membroRepository.GetBy(id);
                if (membro == null)
                    return null;

                model.Id = membro.Id;

                _repository.Update<Membro>(model);

                if (await _repository.SaveChangesAsync())
                {
                    return await _membroRepository.GetBy(model.Id);
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