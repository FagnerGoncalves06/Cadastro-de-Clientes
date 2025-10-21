using ProjetoSOLID.Infrastructure.Data;
using ProjetoSOLID.Infrastructure.Repositories;
using System.Threading.Tasks;
using ProjetoSOLID.Domain.Interfaces;
using AutoMapper;

namespace ProjetoSOLID.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IClienteRepository Clientes { get; }
        Task<int> CommitAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjetoDbContext _context;
        private readonly IMapper _mapper;
        private IClienteRepository? _clientes;
        public UnitOfWork(ProjetoDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IClienteRepository Clientes => _clientes ??= new ClienteRepository(_context, _mapper);
        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();
    }
}
