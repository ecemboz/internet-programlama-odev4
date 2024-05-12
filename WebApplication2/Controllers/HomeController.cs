using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbUruntakipContext _db_uruntakipContext;
        public HomeController(ILogger<HomeController> logger,
        DbUruntakipContext db_uruntakipContext)
        {
            _logger = logger;
            this._db_uruntakipContext = _db_uruntakipContext;
        }
        public IActionResult Index()
        {

            return View();

        }
    }
}
