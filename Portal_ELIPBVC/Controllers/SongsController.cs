using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal_ELIPBVC.Domain.Entities;
using Portal_ELIPBVC.Services.Songs;

namespace Portal_ELIPBVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            _songService = songService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSongs()
        {
            try
            {
                var song = await _songService.GetSongs();
                if (song == null)
                    return null;

                return Ok(song);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Songs. Erro, {ex.Message}");
                throw;
            }

        }

        // GET api/<SongsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSong(int id)
        {
            try
            {
                var song = await _songService.GetBy(id);
                if (song == null)
                    return null;

                return Ok(song);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Song. Erro, {ex.Message}");
                throw;
            }
        }

        // POST api/<SongsController>
        [HttpPost]
        public async Task<IActionResult> AddSong(Song SongModel)
        {
            try
            {
                var song = await _songService.AddSong(SongModel);
                if (song == null)
                    return BadRequest();

                return Ok(song);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar Songs. Erro, {ex.Message}");
                throw;
            }

        }

        // PUT api/<SongsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSong(int id, Song SongModel)
        {
            try
            {
                var song = await _songService.UpdateSong(id, SongModel);
                if (song == null)
                    return NotFound();

                return Ok(song);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar editar Songs. Erro, {ex.Message}");
                throw;
            }

        }

        // DELETE api/<SongsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            try
            {

                if (await _songService.DeleteSong(id))
                    return Ok("Song deletada com sucesso!");
                else
                    return BadRequest("Song não deletada");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar Songs. Erro, {ex.Message}");
                throw;
            }
        }
    }
}