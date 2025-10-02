using Microsoft.AspNetCore.Mvc;
using Backend.Application.Interfaces;
using Backend.Application.DTOs.UsuariosDTOs;

namespace Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioOutputDTO>>> BuscarUsuarios()
        {
            var usuarios = await _usuarioService.BuscarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioOutputDTO>> BuscarUsuarioPorId(string id)
        {
            var usuario = await _usuarioService.BuscarUsuarioPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioOutputDTO>> CriarUsuario(UsuarioInputDTO usuarioInput)
        {
            var usuario = await _usuarioService.CriarUsuario(usuarioInput);
            return Created(usuario.Id, usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioOutputDTO>> AtualizarUsuario(string id, UsuarioInputDTO usuarioInput)
        {
            var usuario = await _usuarioService.AtualizarUsuario(id, usuarioInput);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioOutputDTO>> DeletarUsuario(string id)
        {
            var usuario = await _usuarioService.DeletarUsuario(id);
            return Ok(usuario);
        }


    }
}