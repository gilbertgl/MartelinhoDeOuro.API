using MartelinhoDeOuro.API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MartelinhoDeOuro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiçosController : ControllerBase
    {
        private readonly MartelinhoDbContext _martelinhoDbContext;

        public ServiçosController(MartelinhoDbContext martelinhoDbContext)
        {
            _martelinhoDbContext = martelinhoDbContext;
        }

        [HttpGet]
        [Route("{proprietarioId:Guid}")]
        public async Task<IActionResult> GetServicos([FromRoute]Guid proprietarioId)
        {
            var servicos = await _martelinhoDbContext.Servicos
                                                     .Where(x => x.ProprietarioId == proprietarioId)
                                                     .ToListAsync();
            return Ok(servicos);
        }
    }
}
