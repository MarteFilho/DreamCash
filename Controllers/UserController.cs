using System;
using System.Linq;
using System.Threading.Tasks;
using DreamCash.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DreamCash.Controllers
{
    [Route("v1/user")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] Guid userId)
        {
            try
            {
                var user = await _context.User.AsNoTracking().Where(x => x.Id == userId).FirstOrDefaultAsync();
                if (user == null)
                    return NotFound("Usuário não encontrado");
                user.HidePassword();
                return Ok(user);
            }
            catch
            {
                return BadRequest("Erro ao buscar o usuário!");
            }
        }

        [HttpGet]
        [Route("dailyreport")]
        public async Task<IActionResult> DailyReport([FromQuery] Guid userId)
        {
            try
            {
                var transactions = await _context.Transaction.AsNoTracking().Where(x => x.UserId == userId && x.InvestimentDate.Date == DateTime.Now.Date).ToListAsync();
                if (transactions == null)
                    return NotFound("Nenhuma transação encontrada!");

                return Ok(transactions);
            }
            catch
            {
                return BadRequest("Erro ao buscar o usuário!");
            }
        }

        [HttpGet]
        [Route("balance")]
        public async Task<IActionResult> GetUserBalance([FromQuery] Guid userId)
        {
            try
            {
                var userBalance = await _context.User.AsNoTracking().Where(x => x.Id == userId).Include(x => x.Account).FirstOrDefaultAsync();
                if (userBalance == null)
                    return NotFound("Usuário não encontrado");
                userBalance.HidePassword();
                return Ok(userBalance);
            }
            catch
            {
                return BadRequest("Erro ao buscar o saldo do usuário!");
            }
        }

        [HttpGet]
        [Route("investments")]
        public async Task<IActionResult> GetUserInvestments([FromQuery] Guid userId)
        {
            try
            {
                var userInvestments = await _context.User.AsNoTracking().Where(x => x.Id == userId).Include(x => x.Investiments).FirstOrDefaultAsync();
                if (userInvestments == null)
                    return NotFound("Usuário não encontrado");
                userInvestments.HidePassword();
                return Ok(userInvestments);
            }
            catch
            {
                return BadRequest("Erro ao buscar os investimentos do usuário!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = new User(model.Name, model.Document, model.Email, model.Password, model.Phone, model.Birthday, model.Sex, model.Address);
                user.EncryptPassword();

                Account userAccount = new Account(user.Id);
                user.AddAccountId(userAccount.Id);

                await _context.User.AddAsync(user);
                await _context.Account.AddAsync(userAccount);
                await _context.SaveChangesAsync();

                user.HidePassword();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao criar o usuário, favor tentar novamente! " + ex.Message);
            }

        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var user = await _context.User.Where(x => x.Document == model.Document).AsNoTracking().FirstOrDefaultAsync();
                if (user == null)
                    return NotFound("Usuário não encontrado!");

                if (user.Login(model.Password))
                {
                    user.HidePassword();
                    return Ok(new { Message = "Usuário autenticado com sucesso!", });
                }

                return Unauthorized("Senha inválida, favor verificar!");
            }
            catch
            {
                return BadRequest("Erro ao realizar o login, favor tentar novamente!");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = await _context.User.Where(x => x.Id == model.UserId).AsNoTracking().FirstOrDefaultAsync();
                if (user == null)
                    return NotFound("Usuário não encontrado!");

                user.Update(model.Phone, model.Address);
                _context.Entry<User>(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(user);
            }
            catch
            {
                return BadRequest("Erro ao atualizar o usuário, favor tentar novamente!");
            }
        }
    }
}