using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Application.DTOs.UsuariosDTOs
{
    public class UsuarioOutputDTO
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string? Nome { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}