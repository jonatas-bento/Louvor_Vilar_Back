using Portal_ELIPBVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_ELIPBVC.Domain.Repositories
{
    public interface ISongRepository
    {
        Task<List<Song>> GetAll();
        Task<Song> GetBy(int id);
    }
}
