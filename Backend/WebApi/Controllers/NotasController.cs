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
        public async Task<ActionResult<NotasOutputDTO>> BuscarNotaPorId(int id, NotaDTO notaDTO)
        {
            var buscarId = await _notaService.BuscarNotaPorId(id, notaDTO.UsuarioId);
            return Ok(buscarId);
        }

        [HttpGet("usuario")]
        public async Task<ActionResult<IEnumerable<NotasOutputDTO>>> BuscarNotasPorUsuario(NotaDTO notaDTO)
        {
            var notasUsuario = await _notaService.BuscarNotasPorUsuario(notaDTO.UsuarioId);
            return Ok(notasUsuario);
        }

        [HttpPost]
        public async Task<ActionResult<NotasOutputDTO>> CriarNota(NotasInputDTO notasInput)
        {
            var criarNota = await _notaService.CriarNota(notasInput, notasInput.UsuarioId);
            return Created(criarNota.Id.ToString(), criarNota);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<NotasOutputDTO>> AtualizarNota(int id, NotasInputDTO notasInput)
        {
            var atualizarNota = await _notaService.AtualizarNota(id, notasInput, notasInput.UsuarioId);
            return Ok(atualizarNota);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<NotasOutputDTO>> DeletarNota(int id, NotaDTO notaDTO)
        {
            var deletarNota = await _notaService.DeletarNota(id, notaDTO.UsuarioId);
            return Ok(deletarNota);
        }

    }
}