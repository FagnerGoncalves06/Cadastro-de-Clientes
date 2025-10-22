using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjetoSOLID.Domain.DTOs;
using ProjetoSOLID.Domain.Entities;
using ProjetoSOLID.Domain.Interfaces;
using ProjetoSOLID.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoSOLID.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ProjetoDbContext _context;
        private readonly IMapper _mapper;
        public ClienteRepository(ProjetoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Cliente> GetByIdAsync(Guid id) => await _context.Cliente.FindAsync(id);
        public void Remove(Cliente entity) => _context.Cliente.Remove(entity);

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Cliente.AsNoTracking().ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _context.Cliente.FindAsync(id);
        }

        public bool GetByEmail(string email)
        {
            return _context.Cliente
                    .Any(c => c.Email == email);
        }

        public ClienteDto GetById(Guid id)
        {
            return _context.Cliente.Where(c => c.Id == id)
                .Select(c => new ClienteDto()
                {
                    Id = c.Id,
                    Nome = c.Nome
                }).FirstOrDefault();
        }

        public Cliente Add(ClienteDto dto)
        {
            var cliente = Map(dto);
            _context.Cliente.Add(cliente);
            _context.SaveChanges();

            return cliente;
        }

        public Cliente Map(ClienteDto dto)
        {
            return new Cliente(dto.Nome, dto.Email, dto.FlAtivo, dto.CPF);
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Cliente.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
