using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PearlMVC.Data;
using PearlMVC.Models;

namespace PearlMVC.Controllers
{
    public class NecklacesController : Controller
    {
        private readonly PearlMVCContext _context;
        public NecklacesController(PearlMVCContext context)
        {
            _context = context;
        }

        // GET: Necklaces
        public async Task<IActionResult> Index()
        {
            return View(await _context.Necklace.ToListAsync());
        }

        // GET: Necklaces/ShowSearchForm
        public async Task<IActionResult> ShowSearchForm()
        {
            return View();
        }

        // PoST: Necklaces/ShowSearchResults
        public async Task<IActionResult> ShowSearchResults(String SearchPhrase)
        {
            return View("Index", await _context.Necklace.Where(n => n.Name.Contains(SearchPhrase)).ToListAsync());
        }

        // GET: Necklaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neck = await _context.Necklace
                .FirstOrDefaultAsync(n => n.NecklaceID == id);
            if (neck == null)
            {
                return NotFound();
            }

            return View(neck);
        }

        // GET: Necklaces/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Type,Attack,Stat,StatValue,Description")] Necklace neck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(neck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(neck);
        }

        // GET: Necklaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neck = await _context.Necklace.FindAsync(id);
            if (neck == null)
            {
                return NotFound();
            }
            return View(neck);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Type,Attack,Stat,StatValue,Description")] Necklace neck)
        {
            if (id != neck.NecklaceID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(neck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NecklaceExists(neck.NecklaceID))
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
            return View(neck);
        }

        // GET: Necklaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var neck = await _context.Necklace
                .FirstOrDefaultAsync(n => n.NecklaceID == id);
            if (neck == null)
            {
                return NotFound();
            }

            return View(neck);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var neck = await _context.Necklace.FindAsync(id);
            _context.Necklace.Remove(neck);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NecklaceExists(int id)
        {
            return _context.Necklace.Any(e => e.NecklaceID == id);
        }
    }
}
