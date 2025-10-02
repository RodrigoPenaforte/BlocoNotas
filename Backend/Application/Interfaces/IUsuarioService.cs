using System.Collections.Generic;
using Backend.Application.DTOs.UsuariosDTOs;

namespace Backend.Application.Interfaces
{
    public interface IUsuarioService
    {
        public Task<IEnumerable<UsuarioOutputDTO>> BuscarUsuarios();
        public Task<UsuarioOutputDTO> BuscarUsuarioPorId(string id);
        public Task<UsuarioOutputDTO> CriarUsuario(UsuarioInputDTO usuarioInput);
        public Task<UsuarioOutputDTO> AtualizarUsuario(string id, UsuarioInputDTO usuarioInput);
        public Task<UsuarioOutputDTO> DeletarUsuario(string id);
    }
}