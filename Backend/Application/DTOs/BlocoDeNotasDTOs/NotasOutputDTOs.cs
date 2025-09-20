using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Application.DTOs.BlocoDeNotasDTOs
{
    public class NotasOutputDTOs
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string? Titulo { get; set; }
        public string? Conteudo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime DataAtualizacao { get; set; } = DateTime.UtcNow;
        
    }
}