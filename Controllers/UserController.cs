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
        public async Task<IActionResult> Get([FromQuery] int userId)
        {
            try
            {
                var user = await _context.User.AsNoTracking().Where(x => x.Id == userId).FirstOrDefaultAsync();
                if (user == null)
                    return BadRequest("Usuário não encontrado");
                user.HidePassword();
                return Ok(user);
            }
            catch
            {
                return BadRequest("Erro ao buscar o usuário!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] User model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                model.EncryptPassword();
                await _context.User.AddAsync(model);
                await _context.SaveChangesAsync();

                model.HidePassword();
                return Ok(model);
            }
            catch
            {
                return BadRequest("Erro ao criar o usuário, favor tentar novamente!");
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
                    return Ok(new { Message = "Usuário autenticado com sucesso!", user });

                return BadRequest("Senha inválida, favor verificar!");
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