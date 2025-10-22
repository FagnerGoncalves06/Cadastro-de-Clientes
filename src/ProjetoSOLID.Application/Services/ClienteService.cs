using ProjetoSOLID.Application.Utils;
using ProjetoSOLID.Domain.DTOs;
using ProjetoSOLID.Domain.Entities;
using ProjetoSOLID.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSOLID.Application.Services
{
    public interface IClienteService
    {
        Task<ClienteDto> CriarClienteAsync(ClienteDto dto);
        Task<IEnumerable<ClienteDto>> ObterTodosAsync();
        ClienteDto GetById(Guid id);
    }

    public class ClienteService : IClienteService
    {
        private readonly IUnitOfWork _uow;

        public ClienteService(IUnitOfWork uow) => _uow = uow;

        public async Task<ClienteDto> CriarClienteAsync(ClienteDto dto)
        {
            var existente = _uow.Clientes.GetByEmail(dto.Email);
            if (existente)
                throw new InvalidOperationException("Email já cadastrado");

            if (!ValidadorCPF.Validar(dto.CPF))
                throw new InvalidOperationException("CPF inválido.");

            var clienteNovo = _uow.Clientes.Add(dto);
            await _uow.CommitAsync();

            return new ClienteDto(dto.Nome, dto.Email, clienteNovo.Id, clienteNovo.CPF);
        }

        public async Task<IEnumerable<ClienteDto>> ObterTodosAsync()
        {
            var lista = await _uow.Clientes.GetAllAsync();
            return lista.Select(c => new ClienteDto(c.Nome, c.Email, c.Id, c.CPF));
        }

        public ClienteDto GetById(Guid id)
        {
            var cliente = _uow.Clientes.GetById(id);

            if (cliente != null)
                return new ClienteDto(cliente.Nome, cliente.Email, cliente.Id, cliente.CPF);

            return null;
        }
    }
}
