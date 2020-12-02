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
        public async Task<IActionResult> Create([FromBody] CreateInvestmentViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var investment = new Investment(model.Type, model.Description, model.MinimumValue);

                await _context.Investment.AddAsync(investment);
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
                var investiments = await _context.Investment.AsNoTracking().ToListAsync();
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