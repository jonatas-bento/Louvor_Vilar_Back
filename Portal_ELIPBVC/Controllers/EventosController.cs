using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portal_ELIPBVC.Domain.Entities;
using Portal_ELIPBVC.Services.Eventos;

namespace Portal_ELIPBVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;

        public EventosController(IEventoService eventoService)
        {
            _eventoService = eventoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEventos()
        {
            try
            {
                var evento = await _eventoService.GetEventos();
                if (evento == null)
                    return null;

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Eventos. Erro, {ex.Message}");
                throw;
            }

        }

        // GET api/<EventosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvento(int id)
        {
            try
            {
                var evento = await _eventoService.GetBy(id);
                if (evento == null)
                    return null;

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Evento. Erro, {ex.Message}");
                throw;
            }
        }

        // POST api/<EventosController>
        [HttpPost]
        public async Task<IActionResult> AddEvento(Evento EventoModel)
        {
            try
            {
                var evento = await _eventoService.AddEvento(EventoModel);
                if (evento == null)
                    return BadRequest();

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar adicionar Eventos. Erro, {ex.Message}");
                throw;
            }

        }

        // PUT api/<EventosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvento(int id, Evento EventoModel)
        {
            try
            {
                var evento = await _eventoService.UpdateEvento(id, EventoModel);
                if (evento == null)
                    return NotFound();

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar editar Eventos. Erro, {ex.Message}");
                throw;
            }

        }

        // DELETE api/<EventosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            try
            {

                if (await _eventoService.DeleteEvento(id))
                    return Ok("Evento deletada com sucesso!");
                else
                    return BadRequest("Evento não deletada");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar deletar Eventos. Erro, {ex.Message}");
                throw;
            }
        }
    }
}
