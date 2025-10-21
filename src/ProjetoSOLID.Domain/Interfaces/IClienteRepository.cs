using ProjetoSOLID.Domain.DTOs;
using ProjetoSOLID.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoSOLID.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> GetByIdAsync(int id);
        Cliente Add(ClienteDto dto);
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task DeleteAsync(int id);
        Task UpdateAsync(Cliente cliente);
        bool GetByEmail(string email);
        ClienteDto GetById(Guid id);
    }
}
