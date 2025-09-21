using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Application.DTOs.BlocoDeNotasDTOs;
using Backend.Application.Interfaces;
using Backend.Domain.Interfaces;

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
        public Task<NotasOutputDTO> BuscarNotaPorId(int id, string usuarioId)
        {
            throw new NotImplementedException();
        }


        public Task<NotasOutputDTO> CriarNota(NotasInputDTO notaInput, string usuarioId)
        {
            throw new NotImplementedException();
        }
        public Task<NotasOutputDTO> AtualizarNota(int id, NotasInputDTO notaInput, string usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletarNota(int id, string usuarioId)
        {
            throw new NotImplementedException();
        }
    }
}