using System;
using System.Linq;
using System.Threading.Tasks;
using DreamCash.Models.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DreamCash.Controllers
{
    [Route("v1/admin")]
    public class AdminController : ControllerBase
    {
        private readonly DataContext _context;
        public AdminController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] AdminLoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var admin = await _context.Admin.Where(x => x.Email == model.Email).AsNoTracking().FirstOrDefaultAsync();
                if (admin == null)
                    return NotFound("Administrador não encontrado!");

                if (admin.Login(model.Password))
                    return Ok("Administrador autenticado com sucesso!");

                return BadRequest("Senha inválida, favor verificar!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao realizar o login do administrador, favor tentar novamente! " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Admin model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            model.EncryptPassword();
            try
            {
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();

                model.HidePassword();
                return Ok(model);
            }
            catch
            {
                return BadRequest("Erro ao criar o usuário, favor tentar novamente!");
            }

        }

        [HttpGet]
        [Route("user")]
        public async Task<IActionResult> GetUserByCpf([FromQuery] string cpf)
        {
            try
            {
                var user = await _context.User.AsNoTracking().Where(x => x.Document == cpf).Include(x => x.Account).FirstOrDefaultAsync();
                if (user == null)
                    return NotFound("Usuário não encontrado");
                user.HidePassword();
                return Ok(user);
            }
            catch
            {
                return BadRequest("Erro ao buscar as informações do usuário!");
            }
        }
    }
}