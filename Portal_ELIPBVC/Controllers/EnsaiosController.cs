using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal_ELIPBVC.Domain.Entities;
using Portal_ELIPBVC.Services.Ensaios;

namespace Portal_ELIPBVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnsaiosController : ControllerBase
    {
        private readonly IEnsaioService _ensaioService;

        public EnsaiosController(IEnsaioService ensaioService)
        {
            _ensaioService = ensaioService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEnsaios()
        {
            try
            {
                var ensaio = await _ensaioService.GetEnsaios();
                if (ensaio == null)
                    return null;

                return Ok(ensaio);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Ensaios. Erro, {ex.Message}");
                throw;
            }

        }

        // GET api/<EnsaiosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnsaio(int id)
        {
            try
            {
                var ensaio = await _ensaioService.GetBy(id);
                if (ensaio == null)
                    return null;

                return Ok(ensaio);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Ensaio. Erro, {ex.Message}");
                throw;
            }
        }

        // POST api/<EnsaiosController>
        [HttpPost]
        public async Task<IActionResult> AddEnsaio(Ensaio EnsaioModel)
        {
            try
            {
                var ensaio = await _ensaioService.AddEnsaio(EnsaioModel);
                if (ensaio == null)
                    return BadRequest();

                return Ok(ensaio);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar Ensaios. Erro, {ex.Message}");
                throw;
            }

        }

        // PUT api/<EnsaiosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEnsaio(int id, Ensaio EnsaioModel)
        {
            try
            {
                var ensaio = await _ensaioService.UpdateEnsaio(id, EnsaioModel);
                if (ensaio == null)
                    return NotFound();

                return Ok(ensaio);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar editar Ensaios. Erro, {ex.Message}");
                throw;
            }

        }

        // DELETE api/<EnsaiosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnsaio(int id)
        {
            try
            {

                if (await _ensaioService.DeleteEnsaio(id))
                    return Ok("Ensaio deletada com sucesso!");
                else
                    return BadRequest("Ensaio não deletada");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar Ensaios. Erro, {ex.Message}");
                throw;
            }
        }
    }
}
