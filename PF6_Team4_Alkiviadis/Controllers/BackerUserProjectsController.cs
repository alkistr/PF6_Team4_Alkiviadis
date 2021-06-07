using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PF6_Team4_Core.Data;
using PF6_Team4_Core.Models;

namespace PF6_Team4_Alkiviadis.Controllers
{
    public class BackerUserProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BackerUserProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BackerUserProjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.BackerUserProjects.ToListAsync());
        }

        // GET: BackerUserProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var backerUserProject = await _context.BackerUserProjects
                .FirstOrDefaultAsync(m => m.BackerUserProjectId == id);
            if (backerUserProject == null)
            {
                return NotFound();
            }

            return View(backerUserProject);
        }

        // GET: BackerUserProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BackerUserProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BackerUserProjectId,UserId,ProjectId,AmountDonated")] BackerUserProject backerUserProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(backerUserProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(backerUserProject);
        }

        // GET: BackerUserProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var backerUserProject = await _context.BackerUserProjects.FindAsync(id);
            if (backerUserProject == null)
            {
                return NotFound();
            }
            return View(backerUserProject);
        }

        // POST: BackerUserProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BackerUserProjectId,UserId,ProjectId,AmountDonated")] BackerUserProject backerUserProject)
        {
            if (id != backerUserProject.BackerUserProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(backerUserProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BackerUserProjectExists(backerUserProject.BackerUserProjectId))
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
            return View(backerUserProject);
        }

        // GET: BackerUserProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var backerUserProject = await _context.BackerUserProjects
                .FirstOrDefaultAsync(m => m.BackerUserProjectId == id);
            if (backerUserProject == null)
            {
                return NotFound();
            }

            return View(backerUserProject);
        }

        // POST: BackerUserProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var backerUserProject = await _context.BackerUserProjects.FindAsync(id);
            _context.BackerUserProjects.Remove(backerUserProject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BackerUserProjectExists(int id)
        {
            return _context.BackerUserProjects.Any(e => e.BackerUserProjectId == id);
        }
    }
}
