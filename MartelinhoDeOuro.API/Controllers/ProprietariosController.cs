using MartelinhoDeOuro.API.Data;
using MartelinhoDeOuro.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MartelinhoDeOuro.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProprietariosController : Controller
    {
        public readonly MartelinhoDbContext _martelinhoDbContext;

        public ProprietariosController(MartelinhoDbContext martelinhoDbContext)
        {
            _martelinhoDbContext = martelinhoDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProprietarios()
        {
            var proprietarios = await _martelinhoDbContext.Proprietarios
                                                          .AsQueryable()
                                                          .Include(e => e.Endereco)
                                                          .OrderByDescending(x => x.Id)
                                                          .ToListAsync();
            return Ok(proprietarios);
        }

        [HttpPost]
        public async Task<IActionResult> AddProprietario(Proprietario proprietarioRequest)
        {
            proprietarioRequest.Id = Guid.NewGuid();
            await _martelinhoDbContext.Proprietarios.AddAsync(proprietarioRequest);
            await _martelinhoDbContext.SaveChangesAsync();

            return Ok(proprietarioRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetProprietario([FromRoute]Guid id)
        {
            var proprietario = await _martelinhoDbContext.Proprietarios
                                                         .AsQueryable()
                                                         .Include(x => x.Endereco)
                                                         .FirstOrDefaultAsync(x => x.Id == id);
            if(proprietario == null) return NotFound();

            return Ok(proprietario);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateProprietario([FromRoute] Guid id, Proprietario updateProprietarioRequest)
        {
            var proprietario = await _martelinhoDbContext.Proprietarios.FindAsync(id);
            if(proprietario == null) return NotFound();

            proprietario.Nome = updateProprietarioRequest.Nome;
            proprietario.Cpf = updateProprietarioRequest.Cpf;
            proprietario.Rg = updateProprietarioRequest.Rg;
            proprietario.Email = updateProprietarioRequest.Email;
            proprietario.Telefone = updateProprietarioRequest.Telefone;
            //for (int i = 0; i < proprietario.Veiculos.Count; i++)
            //{
            //    proprietario.Veiculos[i].Nome = updateProprietarioRequest.Veiculos[i].Nome;
            //    proprietario.Veiculos[i].Modelo = updateProprietarioRequest.Veiculos[i].Modelo;
            //    proprietario.Veiculos[i].Ano = updateProprietarioRequest.Veiculos[i].Ano;
            //    proprietario.Veiculos[i].Cor = updateProprietarioRequest.Veiculos[i].Cor;
            //    proprietario.Veiculos[i].Placa = updateProprietarioRequest.Veiculos[i].Placa;
            //}
            proprietario.Endereco = updateProprietarioRequest.Endereco;

            await _martelinhoDbContext.SaveChangesAsync();

            return Ok(proprietario);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteProprietario([FromRoute] Guid id)
        {
            var proprietario = await _martelinhoDbContext.Proprietarios.FindAsync(id);
            if (proprietario == null) return NotFound();

            _martelinhoDbContext.Proprietarios.Remove(proprietario);
            await _martelinhoDbContext.SaveChangesAsync();

            return Ok(proprietario);
        }
    }
}
