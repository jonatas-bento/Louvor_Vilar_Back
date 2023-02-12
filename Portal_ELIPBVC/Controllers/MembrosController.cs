using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal_ELIPBVC.Domain.Entities;
using Portal_ELIPBVC.Services.Membros;

namespace Portal_ELIPBVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembrosController : ControllerBase
    {
        private readonly IMembroService _membroService;

        public MembrosController(IMembroService membroService)
        {
            _membroService = membroService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMembros()
        {
            try
            {
                var membro = await _membroService.GetMembros();
                if (membro == null)
                    return null;

                return Ok(membro);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Membros. Erro, {ex.Message}");
                throw;
            }

        }

        // GET api/<MembrosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMembro(int id)
        {
            try
            {
                var membro = await _membroService.GetBy(id);
                if (membro == null)
                    return null;

                return Ok(membro);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Membro. Erro, {ex.Message}");
                throw;
            }
        }

        // POST api/<MembrosController>
        [HttpPost]
        public async Task<IActionResult> AddMembro(Membro MembroModel)
        {
            try
            {
                var membro = await _membroService.AddMembro(MembroModel);
                if (membro == null)
                    return BadRequest();

                return Ok(membro);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar Membros. Erro, {ex.Message}");
                throw;
            }

        }

        // PUT api/<MembrosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMembro(int id, Membro MembroModel)
        {
            try
            {
                var membro = await _membroService.UpdateMembro(id, MembroModel);
                if (membro == null)
                    return NotFound();

                return Ok(membro);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar editar Membros. Erro, {ex.Message}");
                throw;
            }

        }

        // DELETE api/<MembrosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembro(int id)
        {
            try
            {

                if (await _membroService.DeleteMembro(id))
                    return Ok("Membro deletada com sucesso!");
                else
                    return BadRequest("Membro não deletada");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar Membros. Erro, {ex.Message}");
                throw;
            }
        }
    }
}