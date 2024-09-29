using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEBJABA.Models;

namespace WEBJABA.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly WEBJABAContext _context;

        public UserProfileController(UserManager<User> userManager, WEBJABAContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        //[HttpGet]
        //public async Task<IActionResult> Profile()
        //{
        //    // Отримуємо поточного користувача
        //    var user = await _userManager.GetUserAsync(User);

        //    if (user == null)
        //    {
        //        return NotFound($"Користувач з ID '{_userManager.GetUserId(User)}' не знайдений.");
        //    }
        //    var photoUrlId = user.PhotoId;

            // Здійснюємо запит до бази даних, щоб отримати PhotoUrl за вказаним PhotoUrlId
            //var photoUrl = await _context.Photos
            //    .Where(p => p.Id == photoUrlId)
            //    .Select(p => p.Photos)
                //.FirstOrDefaultAsync();

            // Отримуємо роль користувача
            //var userRole = await _userManager.GetRolesAsync(user);
            //var role = userRole.FirstOrDefault();

            // Передаємо дані користувача та PhotoUrl у представлення для відображення
            //ViewData["PhotoUrl"] = photoUrl;

            //ViewData["Role"] = role;
            //return View(user);
        //}
        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
