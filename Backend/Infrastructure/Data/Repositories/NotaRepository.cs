using Backend.Domain.Interfaces;
using Backend.Domain.Models.BlocoDeNotas;
using Microsoft.EntityFrameworkCore;
using Backend.Infrastructure.Data;

namespace Backend.Infrastructure.Data.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly AppDbContext _context;

        public NotaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Notas>> BuscarNotasPorUsuario(string usuarioId)
        {
            return await _context.Notas.Where(n => n.UsuarioId == usuarioId).ToListAsync();
        }
        public async Task<Notas> BuscarNotasId(int notasId)
        {
            return await _context.Notas.FirstOrDefaultAsync(n => n.Id == notasId);
        }

        public async Task<Notas> CriarNotas(Notas notas)
        {
            _context.Notas.Add(notas);
            await _context.SaveChangesAsync();
            return notas;
        }
        public async Task<Notas> AtualizarNotas(Notas notas)
        {
            _context.Notas.Update(notas);
            await _context.SaveChangesAsync();
            return notas;
        }

        public async Task<Notas> DeletarNotas(int notasId)
        {
            var nota = await _context.Notas.FindAsync(notasId);
            if (nota != null)
            {
                _context.Notas.Remove(nota);
                await _context.SaveChangesAsync();
            }
            return nota;

        }
    }
}