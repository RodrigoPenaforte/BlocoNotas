using Backend.Domain.Models.Usuarios;
using Backend.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Backend.Application.DTOs.UsuariosDTOs;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly IMapper _mapper;

        public UsuarioService(UserManager<Usuario> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioOutputDTO>> BuscarUsuarios()
        {
            var usuarios = await _userManager.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UsuarioOutputDTO>>(usuarios);
        }

        public async Task<UsuarioOutputDTO> BuscarUsuarioPorId(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            return _mapper.Map<UsuarioOutputDTO>(usuario);
        }
        public async Task<UsuarioOutputDTO> CriarUsuario(UsuarioInputDTO usuarioInput)
        {
            var usuario = _mapper.Map<Usuario>(usuarioInput);
            usuario.UserName = usuarioInput.Email;
            usuario.DataCriacao = DateTime.Now;
            usuario.DataAtualizacao = DateTime.Now;
            var resultado = await _userManager.CreateAsync(usuario, usuarioInput.Password);
            if (resultado.Succeeded)
                return _mapper.Map<UsuarioOutputDTO>(usuario);

            throw new Exception("Erro ao criar usuário");
        }
        public async Task<UsuarioOutputDTO> AtualizarUsuario(string id, UsuarioInputDTO usuarioInput)
        {
            var usuario = await _userManager.FindByIdAsync(id) ?? throw new Exception("Usuário não encontrado");

            _mapper.Map(usuarioInput, usuario);
            await _userManager.UpdateAsync(usuario);
            return _mapper.Map<UsuarioOutputDTO>(usuario);
        }
        public async Task<UsuarioOutputDTO> DeletarUsuario(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id) ?? throw new Exception("Usuário não encontrado");
            var usuarioDto = _mapper.Map<UsuarioOutputDTO>(usuario);
            await _userManager.DeleteAsync(usuario);
            return usuarioDto;
        }
    }
};