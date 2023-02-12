using Microsoft.EntityFrameworkCore;
using Portal_ELIPBVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_ELIPBVC.Domain.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly ApplicationDbContext _context;

        public SongRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Song>> GetAll()
        {
            IQueryable<Song> songs = _context.Songs.AsNoTracking();
            if (songs == null)
                return null;

            return await songs.ToListAsync();
        }

        public async Task<Song> GetBy(int id)
        {
            IQueryable<Song> song = _context.Songs.AsNoTracking();
            var result = song.OrderBy(x => x.Id)
                .Where(x => x.Id == id);

            return await result.FirstOrDefaultAsync();
        }
    }
}
