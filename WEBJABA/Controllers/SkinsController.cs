using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBJABA.Models;

namespace WEBJABA.Controllers
{
    public class SkinsController : Controller
    {
        private readonly WEBJABAContext _context;

        public SkinsController(WEBJABAContext context)
        {
            _context = context;
        }

        // GET: Skins
        public async Task<IActionResult> Index()
        {
            var wEBJABAContext = _context.Skins.Include(s => s.Photo);
            return View(await wEBJABAContext.ToListAsync());
        }

        // GET: Skins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skin = await _context.Skins
                .Include(s => s.Photo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skin == null)
            {
                return NotFound();
            }

            return View(skin);
        }

        // GET: Skins/Create
        public IActionResult Create()
        {
            ViewData["PhotoId"] = new SelectList(_context.Photos, "Id", "Id");
            return View();
        }

        // POST: Skins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,PhotoId")] Skin skin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhotoId"] = new SelectList(_context.Photos, "Id", "Id", skin.PhotoId);
            return View(skin);
        }

        // GET: Skins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skin = await _context.Skins.FindAsync(id);
            if (skin == null)
            {
                return NotFound();
            }
            ViewData["PhotoId"] = new SelectList(_context.Photos, "Id", "Id", skin.PhotoId);
            return View(skin);
        }

        // POST: Skins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,PhotoId")] Skin skin)
        {
            if (id != skin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkinExists(skin.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhotoId"] = new SelectList(_context.Photos, "Id", "Id", skin.PhotoId);
            return View(skin);
        }

        // GET: Skins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skin = await _context.Skins
                .Include(s => s.Photo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skin == null)
            {
                return NotFound();
            }

            return View(skin);
        }

        // POST: Skins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skin = await _context.Skins.FindAsync(id);
            if (skin != null)
            {
                _context.Skins.Remove(skin);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkinExists(int id)
        {
            return _context.Skins.Any(e => e.Id == id);
        }
    }
}
