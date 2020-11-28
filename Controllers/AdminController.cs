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
                    return Ok(new { Message = "Administrador autenticado com sucesso!", admin });

                return BadRequest("Senha inválida, favor verificar!");
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao realizar o login do administrador, favor tentar novamente! " + ex.Message);
            }
        }
    }
}