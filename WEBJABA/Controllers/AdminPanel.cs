using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEBJABA.Models;

namespace WEBJABA.Controllers
{
    [Authorize(Roles="admin")]
    public class AdminPanel : Controller
    {
        private readonly ILogger<AdminPanel> _logger;

        public AdminPanel(ILogger<AdminPanel> logger)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
