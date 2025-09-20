using Backend.Domain.Models.Usuarios;

namespace Backend.Domain.Models.BlocoDeNotas
{
    public class Notas
    {
        public int Id { get; set; }
        public string? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public string? Titulo { get; set; }
        public string? Conteudo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;
    }
}