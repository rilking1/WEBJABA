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
    public class InventoriesController : Controller
    {
        private readonly WEBJABAContext _context;

        public InventoriesController(WEBJABAContext context)
        {
            _context = context;
        }

        // GET: Inventories
        public async Task<IActionResult> Index()
        {
            var wEBJABAContext = _context.Inventorys.Include(i => i.Photo).Include(i => i.Skin);
            return View(await wEBJABAContext.ToListAsync());
        }

        // GET: Inventories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventorys
                .Include(i => i.Photo)
                .Include(i => i.Skin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // GET: Inventories/Create
        public IActionResult Create()
        {
            ViewData["PhotoId"] = new SelectList(_context.Photos, "Id", "Id");
            ViewData["Skinid"] = new SelectList(_context.Skins, "Id", "Id");
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Skinid,PhotoId")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PhotoId"] = new SelectList(_context.Photos, "Id", "Id", inventory.PhotoId);
            ViewData["Skinid"] = new SelectList(_context.Skins, "Id", "Id", inventory.Skinid);
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventorys.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }
            ViewData["PhotoId"] = new SelectList(_context.Photos, "Id", "Id", inventory.PhotoId);
            ViewData["Skinid"] = new SelectList(_context.Skins, "Id", "Id", inventory.Skinid);
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Skinid,PhotoId")] Inventory inventory)
        {
            if (id != inventory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventoryExists(inventory.Id))
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
            ViewData["PhotoId"] = new SelectList(_context.Photos, "Id", "Id", inventory.PhotoId);
            ViewData["Skinid"] = new SelectList(_context.Skins, "Id", "Id", inventory.Skinid);
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventory = await _context.Inventorys
                .Include(i => i.Photo)
                .Include(i => i.Skin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventory == null)
            {
                return NotFound();
            }

            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventory = await _context.Inventorys.FindAsync(id);
            if (inventory != null)
            {
                _context.Inventorys.Remove(inventory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventorys.Any(e => e.Id == id);
        }
    }
}
