using Microsoft.AspNetCore.Mvc;
using ProjetoSOLID.Application.Services;
using ProjetoSOLID.Domain.DTOs;
using ProjetoSOLID.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace ProjetoSOLID.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClientesController(IClienteService clienteService) => _clienteService = clienteService;

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var novoCliente = await _clienteService.CriarClienteAsync(dto);

            return Ok(novoCliente);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _clienteService.ObterTodosAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cliente = _clienteService.GetById(id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }
    }
}
