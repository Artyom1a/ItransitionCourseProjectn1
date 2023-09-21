using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserRegController : Controller
    {
        private readonly WebApplication1Context _context;

        public UserRegController(WebApplication1Context context)
        {
            _context = context;
        }

        // GET: UserReg
        public async Task<IActionResult> Index()
        {
              return _context.UserReg != null ? 
                          View(await _context.UserReg.ToListAsync()) :
                          Problem("Entity set 'WebApplication1Context.UserReg'  is null.");
        }

        // GET: UserReg/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.UserReg == null)
            {
                return NotFound();
            }

            var userReg = await _context.UserReg
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userReg == null)
            {
                return NotFound();
            }

            return View(userReg);
        }

        // GET: UserReg/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserReg/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,Email,Status,Roles,IsSelected")] UserReg userReg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userReg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userReg);
        }

        // GET: UserReg/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.UserReg == null)
            {
                return NotFound();
            }

            var userReg = await _context.UserReg.FindAsync(id);
            if (userReg == null)
            {
                return NotFound();
            }
            return View(userReg);
        }

        // POST: UserReg/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,UserName,Email,Status,Roles,IsSelected")] UserReg userReg)
        {
            if (id != userReg.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userReg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserRegExists(userReg.Id))
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
            return View(userReg);
        }

        // GET: UserReg/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.UserReg == null)
            {
                return NotFound();
            }

            var userReg = await _context.UserReg
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userReg == null)
            {
                return NotFound();
            }

            return View(userReg);
        }

        // POST: UserReg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.UserReg == null)
            {
                return Problem("Entity set 'WebApplication1Context.UserReg'  is null.");
            }
            var userReg = await _context.UserReg.FindAsync(id);
            if (userReg != null)
            {
                _context.UserReg.Remove(userReg);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserRegExists(string id)
        {
          return (_context.UserReg?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
