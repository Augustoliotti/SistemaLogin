using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaLogin.Data;
using SistemaLogin.Models;
using System.Linq;

namespace SistemaLogin.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var usuario = _context.Usuarios
                .AsNoTracking()
                .FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuario != null)
                return RedirectToAction("Index", "Home");

            ViewBag.Erro = "Email ou senha inválidos";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }
    }
}
