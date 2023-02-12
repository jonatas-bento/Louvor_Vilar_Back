using Portal_ELIPBVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_ELIPBVC.Services.Membros
{
    public interface IMembroService
    {
        Task<Membro> AddMembro(Membro model);
        Task<List<Membro>> GetMembros();
        Task<Membro> GetBy(int MembroId);
        Task<Membro> UpdateMembro(int id, Membro model);
        Task<bool> DeleteMembro(int id);
    }
}
