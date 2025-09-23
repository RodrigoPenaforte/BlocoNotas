using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Application.DTOs.BlocoDeNotasDTOs;
using Backend.Application.Interfaces;
using Backend.Domain.Interfaces;
using Backend.Domain.Models.BlocoDeNotas;

namespace Backend.Application.Services
{
    public class NotaService : INotaService
    {
        private readonly INotaRepository _notaRepository;
        private readonly IMapper _mapper;

        public NotaService(INotaRepository notaRepository, IMapper mapper)
        {
            _notaRepository = notaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NotasOutputDTO>> BuscarNotasPorUsuario(string usuarioId)
        {
            var buscarNotasPorUsuario = await _notaRepository.BuscarNotasPorUsuario(usuarioId);
            return _mapper.Map<IEnumerable<NotasOutputDTO>>(buscarNotasPorUsuario);
        }
        public async Task<NotasOutputDTO> BuscarNotaPorId(int id)
        {
            var buscarNotaPorId = await _notaRepository.BuscarNotasId(id) ?? throw new Exception("Não foi encontrado o id da nota");
            return _mapper.Map<NotasOutputDTO>(buscarNotaPorId);
        }


        public async Task<NotasOutputDTO> CriarNota(NotasInputDTO notaInput)
        {
            var nota = _mapper.Map<Notas>(notaInput);
            var criarNotas = await _notaRepository.CriarNotas(nota) ?? throw new Exception("Não foi possível criar notas");
            return _mapper.Map<NotasOutputDTO>(criarNotas);
        }


        public async Task<NotasOutputDTO> AtualizarNota(int id, NotasInputDTO notaInput, string usuarioId)
        {
            var notaExistente = await _notaRepository.BuscarNotasId(id) ?? throw new Exception("Não foi possível encontrar nota");
            if (notaExistente.UsuarioId != usuarioId)
                throw new Exception("Usuário não tem permissão para atualizar esta nota");

            notaExistente.Titulo = notaInput.Titulo;
            notaExistente.Conteudo = notaInput.Conteudo;
            notaExistente.DataAtualizacao = DateTime.Now;

            var notaAtualizada = await _notaRepository.AtualizarNotas(notaExistente);
            return _mapper.Map<NotasOutputDTO>(notaAtualizada);

        }


        public Task<bool> DeletarNota(int id, string usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}