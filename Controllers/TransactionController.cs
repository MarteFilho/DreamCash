using System;
using System.Threading.Tasks;
using DreamCash.Models;
using Microsoft.AspNetCore.Mvc;

namespace DreamCash.Controllers
{
    [Route("v1/transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly DataContext _context;
        public TransactionController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransactionViewModel model)
        {
            try
            {
                var transaction = new Transaction(model.Name, model.UserId, model.AccountId, model.InvestimentId, model.Value, DateTime.Now);

                await _context.Transaction.AddAsync(transaction);
                await _context.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                return BadRequest("Erro ao criar a transação, favor tentar novamente!");
            }

        }
    }
}