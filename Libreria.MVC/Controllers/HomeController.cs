using Libreria.LogicaNegocio.Entidades;
using Libreria.LogicaNegocio.ExcepcionesEntidades;
using Libreria.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace Libreria.MVC.Controllers
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
            
            return View();
        }
    
        public IActionResult Privacy()
        {
            return View();
        }
 
    }
}