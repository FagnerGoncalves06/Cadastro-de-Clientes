using Xunit;
using Moq;
using ProjetoSOLID.Application.Services;
using ProjetoSOLID.Domain.Interfaces;
using ProjetoSOLID.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoSOLID.Tests
{
    public class ClienteServiceTests
    {
        [Fact]
        public async Task Deve_CriarCliente_ComSucesso()
        {
            var uowMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IClienteRepository>();
            uowMock.SetupGet(u => u.Clientes).Returns(repoMock.Object);
            repoMock.Setup(r => r.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync((Cliente?)null);
            repoMock.Setup(r => r.AddAsync(It.IsAny<Cliente>())).Returns(Task.CompletedTask);
            uowMock.Setup(u => u.CommitAsync()).ReturnsAsync(1);

            var service = new ClienteService(uowMock.Object);
            var cliente = await service.CriarClienteAsync("Teste", "teste@email.com");

            Assert.Equal("Teste", cliente.Nome);
        }

        [Fact]
        public async Task Nao_Deve_CriarCliente_EmailDuplicado()
        {
            var uowMock = new Mock<IUnitOfWork>();
            var repoMock = new Mock<IClienteRepository>();
            uowMock.SetupGet(u => u.Clientes).Returns(repoMock.Object);
            repoMock.Setup(r => r.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync(new Cliente("Existente", "teste@email.com"));

            var service = new ClienteService(uowMock.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.CriarClienteAsync("Novo", "teste@email.com"));
        }
    }
}
