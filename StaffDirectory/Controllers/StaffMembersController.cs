using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StaffDirectory.Areas.Identity.Data;
using StaffDirectory.Models;

namespace StaffDirectory.Controllers
{
    public class StaffMembersController : Controller
    {
        private readonly StaffContext _context;

        public StaffMembersController(StaffContext context)
        {
            _context = context;
        }

        // GET: StaffMembers
        public async Task<IActionResult> Index()
        {
              return _context.StaffMembers != null ? 
                          View(await _context.StaffMembers.ToListAsync()) :
                          Problem("Entity set 'StaffContext.StaffMembers'  is null.");
        }

        // GET: StaffMembers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StaffMembers == null)
            {
                return NotFound();
            }

            var staffMembers = await _context.StaffMembers
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staffMembers == null)
            {
                return NotFound();
            }

            return View(staffMembers);
        }

        // GET: StaffMembers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffId,FirstName,LastName,StaffStatus,HomeRoom,TeacherCode,Email,Phone")] StaffMembers staffMembers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffMembers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffMembers);
        }

        // GET: StaffMembers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StaffMembers == null)
            {
                return NotFound();
            }

            var staffMembers = await _context.StaffMembers.FindAsync(id);
            if (staffMembers == null)
            {
                return NotFound();
            }
            return View(staffMembers);
        }

        // POST: StaffMembers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffId,FirstName,LastName,StaffStatus,HomeRoom,TeacherCode,Email,Phone")] StaffMembers staffMembers)
        {
            if (id != staffMembers.StaffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffMembers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffMembersExists(staffMembers.StaffId))
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
            return View(staffMembers);
        }

        // GET: StaffMembers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StaffMembers == null)
            {
                return NotFound();
            }

            var staffMembers = await _context.StaffMembers
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staffMembers == null)
            {
                return NotFound();
            }

            return View(staffMembers);
        }

        // POST: StaffMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StaffMembers == null)
            {
                return Problem("Entity set 'StaffContext.StaffMembers'  is null.");
            }
            var staffMembers = await _context.StaffMembers.FindAsync(id);
            if (staffMembers != null)
            {
                _context.StaffMembers.Remove(staffMembers);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffMembersExists(int id)
        {
          return (_context.StaffMembers?.Any(e => e.StaffId == id)).GetValueOrDefault();
        }
    }
}
