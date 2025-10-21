using System;

namespace ProjetoSOLID.Domain.DTOs
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool FlAtivo { get; set; } = true;

        public ClienteDto(string nome, string email, Guid id)
        {
            Nome = nome;
            Email = email;
            Id = id;
        }

        public ClienteDto() { }
    }
}
