using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Console.WriteLine("Teste");
            Autenticacao.CheckLogin(this);
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string senha)
        {
            if (login == "admin" || senha == "123")
            {
                HttpContext.Session.SetString("user", "admin");
                HttpContext.Session.SetString("Login", "true");
                HttpContext.Session.SetInt32("tipo", 0);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Erro"] = "Senha inválida";
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
