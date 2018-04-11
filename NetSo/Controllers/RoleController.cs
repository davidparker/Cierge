namespace NetSo.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using NetSo.Data;
    using NetSo.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;

    [Authorize(Roles = "Administrator")]
    public class RoleController : Controller
    {
        
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager )
        {
            _roleManager = roleManager;
        }

        // GET: Client
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        // GET: Client/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // GET: Client/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                await _roleManager.CreateAsync(role);
                return RedirectToAction(nameof(Index));
            }
            
            return View(role);
        }

        // GET: Client/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name")] IdentityRole role)
        {
            if(id != role.Id) return NotFound();

            var existing = (await _roleManager.FindByIdAsync(id));

            if (ModelState.IsValid)
            {
                existing.Name = role.Name;
                
                await _roleManager.UpdateAsync(existing);
                return RedirectToAction(nameof(Index));
            }
            
            return View(role);
        }

        // GET: Client/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if(role != null){
                await _roleManager.DeleteAsync(role);
            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> RoleExists(string id)
        {
            return await _roleManager.RoleExistsAsync(id);
        }
    }
}