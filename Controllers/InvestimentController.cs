using System.Threading.Tasks;
using DreamCash.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DreamCash.Controllers
{
    [Route("v1/investiment")]
    public class InvestimentController : ControllerBase
    {
        private readonly DataContext _context;
        public InvestimentController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Investiment model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _context.Investiment.AddAsync(model);
                await _context.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                return BadRequest("Erro ao criar o investimento, favor tentar novamente!");
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var investiments = await _context.Investiment.AsNoTracking().ToListAsync();
                if (investiments == null)
                    return BadRequest("Nenhum investimento encontrado");
                return Ok(investiments);
            }
            catch
            {
                return BadRequest("Erro ao buscar todos os investimentos!");
            }
        }
    }
}