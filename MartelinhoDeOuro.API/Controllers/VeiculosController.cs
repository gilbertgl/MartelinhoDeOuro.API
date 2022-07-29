using MartelinhoDeOuro.API.Data;
using MartelinhoDeOuro.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MartelinhoDeOuro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly MartelinhoDbContext _martelinhoDbContext;

        public VeiculosController(MartelinhoDbContext martelinhoDbContext)
        {
            _martelinhoDbContext = martelinhoDbContext;
        }

        [HttpGet]
        [Route("{proprietarioId:Guid}")]
        public async Task<IActionResult> GetVeiculosByProprietarioId([FromRoute]Guid proprietarioId)
        {
            var veiculos = await _martelinhoDbContext.Veiculos
                                                .Where(x => x.ProprietarioId == proprietarioId)
                                                .ToListAsync();  
            return Ok(veiculos);
        }

        [HttpGet]
        [Route("veiculo/{veiculoId:Guid}")]
        public async Task<IActionResult> GetVeiculo([FromRoute] Guid veiculoId)
        {
            var veiculo = await _martelinhoDbContext.Veiculos
                                                     .FirstOrDefaultAsync(x => x.Id == veiculoId);
            if (veiculo == null) return NotFound();

            return Ok(veiculo);
        }

        [HttpPost]
        [Route("{proprietarioId:Guid}")]
        public async Task<IActionResult> AddVeiculo([FromRoute] Guid proprietarioId, Veiculo veiculoRequest)
        {
            veiculoRequest.Id = Guid.NewGuid();
            veiculoRequest.ProprietarioId = proprietarioId;
            await _martelinhoDbContext.Veiculos.AddAsync(veiculoRequest);
            await _martelinhoDbContext.SaveChangesAsync();

            return Ok(veiculoRequest);
        }

        [HttpPut]
        [Route("{veiculoId:Guid}")]
        public async Task<IActionResult> UpdateVeiculo([FromRoute] Guid veiculoId, Veiculo updateVeiculoRequest)
        {
            var veiculo = await _martelinhoDbContext.Veiculos
                                                       .FindAsync(veiculoId);
            if (veiculo == null) return NotFound();

            veiculo.Nome = updateVeiculoRequest.Nome;
            veiculo.Modelo = updateVeiculoRequest.Modelo;
            veiculo.Placa = updateVeiculoRequest.Placa;
            veiculo.Cor = updateVeiculoRequest.Cor;
            veiculo.Ano = updateVeiculoRequest.Ano;

            await _martelinhoDbContext.SaveChangesAsync();

            return Ok(veiculo);
        }

        [HttpDelete]
        [Route("{veiculoId:Guid}")]
        public async Task<IActionResult> DeleteVeiculo([FromRoute] Guid veiculoId)
        {
            var veiculo = await _martelinhoDbContext.Veiculos.FindAsync(veiculoId);
            if (veiculo == null) return NotFound();

            _martelinhoDbContext.Veiculos.Remove(veiculo);
            await _martelinhoDbContext.SaveChangesAsync();

            return Ok(veiculo);
        }
    }
}
