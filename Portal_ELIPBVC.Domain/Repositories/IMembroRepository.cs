using Portal_ELIPBVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_ELIPBVC.Domain.Repositories
{
    public interface IMembroRepository
    {
        Task<List<Membro>> GetAll();
        Task<Membro> GetBy(int id);
    }
}
