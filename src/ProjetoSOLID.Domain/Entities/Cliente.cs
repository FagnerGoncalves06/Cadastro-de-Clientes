using System;

namespace ProjetoSOLID.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool FlAtivo { get; set; } = true;
        public DateTime CreatedAt { get; set; }

        public Cliente(string nome, string email, bool flAtivo)
        {
            Nome = nome;
            Email = email;
            FlAtivo = flAtivo;
            CreatedAt = DateTime.Now;
        }

        public void AtualizarEmail(string novoEmail)
        {
            if (string.IsNullOrWhiteSpace(novoEmail))
                throw new ArgumentException("Email inválido");
            Email = novoEmail;
        }
    }
}
