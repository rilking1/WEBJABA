using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEBJABA.Models;

namespace WEBJABA.Controllers
{
    public class RewardsController : Controller
    {
        private readonly ILogger<RewardsController> _logger;

        public RewardsController(ILogger<RewardsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Rewards()
        {
            return View();
        }

        public IActionResult UserProfile()
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
