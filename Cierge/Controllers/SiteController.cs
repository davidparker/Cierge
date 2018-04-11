using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cierge.Data;
using Cierge.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cierge.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class SiteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SiteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Site
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sites.Include(i=> i.Clients).ToListAsync());
        }

        // GET: Site/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Sites.Include(i => i.Clients)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // GET: Site/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Site/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Url")] Site site)
        {
            if (ModelState.IsValid)
            {
                _context.Add(site);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(site);
        }

        // GET: Site/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Sites.FirstOrDefaultAsync(m => m.Id == id);
            if (site == null)
            {
                return NotFound();
            }
            return View(site);
        }

        // POST: Site/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Url")] Site site)
        {
            if (id != site.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(site);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteExists(site.Id))
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
            return View(site);
        }

        // GET: Site/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var site = await _context.Sites
                .FirstOrDefaultAsync(m => m.Id == id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // POST: Site/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var site = await _context.Sites.FirstOrDefaultAsync(m => m.Id == id);
            _context.Sites.Remove(site);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteExists(string id)
        {
            return _context.Sites.Any(e => e.Id == id);
        }
    }
}
