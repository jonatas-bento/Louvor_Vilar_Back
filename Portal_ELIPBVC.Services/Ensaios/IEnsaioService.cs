using Portal_ELIPBVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_ELIPBVC.Services.Ensaios
{
    public interface IEnsaioService
    {
        Task<Ensaio> AddEnsaio(Ensaio model);
        Task<List<Ensaio>> GetEnsaios();
        Task<Ensaio> GetBy(int EnsaioId);
        Task<Ensaio> UpdateEnsaio(int id, Ensaio model);
        Task<bool> DeleteEnsaio(int id);
    }
}
