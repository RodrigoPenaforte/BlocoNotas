using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Models.BlocoDeNotas;

namespace Backend.Domain.Interfaces
{
    public interface INotaRepository
    {
        Task<IEnumerable<Notas>> BuscarNotasPorUsuario(string usuarioId);
        Task<Notas> BuscarNotasId(int notasId);
        Task<Notas> CriarNotas(Notas notas);
        Task<Notas> AtualizarNotas(Notas notas);
        Task<Notas> DeletarNotas(int notasId);
    }
}