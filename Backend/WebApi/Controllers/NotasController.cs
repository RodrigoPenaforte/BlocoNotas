using Backend.Application.DTOs.BlocoDeNotasDTOs;
using Backend.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        private readonly INotaService _notaService;

        public NotasController(INotaService notaService)
        {
            _notaService = notaService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NotasOutputDTO>> BuscarNotaPorId(int id, [FromQuery] string usuarioId)
        {
            var buscarId = await _notaService.BuscarNotaPorId(id, usuarioId);
            return Ok(buscarId);
        }

        [HttpGet("usuario")]
        public async Task<ActionResult<IEnumerable<NotasOutputDTO>>> BuscarNotasPorUsuario([FromQuery] string usuarioId)
        {
            var notasUsuario = await _notaService.BuscarNotasPorUsuario(usuarioId);
            return Ok(notasUsuario);
        }

        [HttpPost]
        public async Task<ActionResult<NotasOutputDTO>> CriarNota([FromBody] NotasInputDTO notasInput)
        {
            var criarNota = await _notaService.CriarNota(notasInput, notasInput.UsuarioId);
            return CreatedAtAction(nameof(BuscarNotaPorId), new { id = criarNota.Id, usuarioId = notasInput.UsuarioId }, criarNota);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<NotasOutputDTO>> AtualizarNota(int id, [FromBody] NotasInputDTO notasInput)
        {
            var atualizarNota = await _notaService.AtualizarNota(id, notasInput, notasInput.UsuarioId);
            return Ok(atualizarNota);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<NotasOutputDTO>> DeletarNota(int id, [FromQuery] string usuarioId)
        {
            var deletarNota = await _notaService.DeletarNota(id, usuarioId);
            return Ok(deletarNota);
        }
    }
}
