using Backend.Domain.Models.BlocoDeNotas;
using Microsoft.AspNetCore.Identity;

namespace Backend.Domain.Models.Usuarios
{
    public class Usuario : IdentityUser
    {
        public string? Nome { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;
        public ICollection<Notas>? Notas { get; set; }
    }
}