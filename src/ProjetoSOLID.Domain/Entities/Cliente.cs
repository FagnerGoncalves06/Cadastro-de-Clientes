using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoSOLID.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        public string CPF { get; set; }
        public bool FlAtivo { get; set; } = true;
        public DateTime CreatedAt { get; set; }

        public Cliente(string nome, string email, bool flAtivo, string cpf)
        {
            Nome = nome;
            Email = email;
            FlAtivo = flAtivo;
            CPF = cpf;
            CreatedAt = DateTime.Now;
        }

        public Cliente() { }

        public void AtualizarEmail(string novoEmail)
        {
            if (string.IsNullOrWhiteSpace(novoEmail))
                throw new ArgumentException("Email inválido");
            Email = novoEmail;
        }
    }
}
