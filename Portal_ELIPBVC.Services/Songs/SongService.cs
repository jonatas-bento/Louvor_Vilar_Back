using Portal_ELIPBVC.Domain.Entities;
using Portal_ELIPBVC.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_ELIPBVC.Services.Songs
{
    public class SongService : ISongService
    {
        private readonly IRepository _repository;
        private readonly ISongRepository _songRepository;

        public SongService(IRepository repository, ISongRepository songRepository)
        {
            _repository = repository;
            _songRepository = songRepository;
        }

        public async Task<Song> AddSong(Song model)
        {
            try
            {
                _repository.Add<Song>(model);
                if (await _repository.SaveChangesAsync())
                {
                    return await _songRepository.GetBy(model.Id);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteSong(int id)
        {
            try
            {
                var song = _songRepository.GetBy(id);
                if (song == null)
                    throw new Exception("O dado não pôde ser encontrado ou não existe");

                _repository.Delete(song);
                return await _repository.SaveChangesAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Song> GetBy(int songId)
        {
            try
            {
                var song = await _songRepository.GetBy(songId);
                if (song == null)
                    return null;

                return song;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Song>> GetSongs()
        {
            try
            {
                var song = await _songRepository.GetAll();
                if (song == null)
                    return null;

                return song;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Song> UpdateSong(int id, Song model)
        {
            try
            {
                var song = await _songRepository.GetBy(id);
                if (song == null)
                    return null;

                model.Id = song.Id;

                _repository.Update<Song>(model);

                if (await _repository.SaveChangesAsync())
                {
                    return await _songRepository.GetBy(model.Id);
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
