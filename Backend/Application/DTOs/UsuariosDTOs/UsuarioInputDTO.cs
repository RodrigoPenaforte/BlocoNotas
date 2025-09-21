using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Application.DTOs.UsuariosDTOs
{
    public class UsuarioInputDTO
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        
    }
}