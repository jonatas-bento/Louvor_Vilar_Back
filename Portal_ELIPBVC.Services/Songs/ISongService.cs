using Portal_ELIPBVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_ELIPBVC.Services.Songs
{
    public interface ISongService
    {
        Task<Song> AddSong(Song model);
        Task<List<Song>> GetSongs();
        Task<Song> GetBy(int SongId);
        Task<Song> UpdateSong(int id, Song model);
        Task<bool> DeleteSong(int id);
    }
}
