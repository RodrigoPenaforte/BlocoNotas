using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Application.DTOs.BlocoDeNotasDTOs;
using Backend.Domain.Models.BlocoDeNotas;

namespace Backend.Application.Interfaces
{
    public interface INotaService
    {
        Task<IEnumerable<NotasOutputDTO>> BuscarNotasPorUsuario(string usuarioId);
        Task<NotasOutputDTO> BuscarNotaPorId(int id, string usuarioId);
        Task<NotasOutputDTO> CriarNota(NotasInputDTO notaInput, string usuarioId);
        Task<NotasOutputDTO> AtualizarNota(int id, NotasInputDTO notaInput, string usuarioId);
        Task<NotasOutputDTO> DeletarNota(int id, string usuarioId);
    }
}