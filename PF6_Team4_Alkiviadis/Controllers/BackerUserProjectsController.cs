using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PF6_Team4_Core.Data;
using PF6_Team4_Core.Interfaces;
using PF6_Team4_Core.Models;

namespace PF6_Team4_Alkiviadis.Controllers
{
    public class BackerUserProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBackerUserProjectService _backerUserProjectService;

        public BackerUserProjectsController(ApplicationDbContext context, IBackerUserProjectService backerUserProjectService)
        {
            _context = context;
            _backerUserProjectService = backerUserProjectService;
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
                backerUserProject.UserId = _context.UsersLoggedIn.OrderByDescending(x => x.UserId).First().UserId;

                await _backerUserProjectService.DonateAmount(backerUserProject);
                //_context.Add(backerUserProject);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return View(backerUserProject);
        }

             

        private bool BackerUserProjectExists(int id)
        {
            return _context.BackerUserProjects.Any(e => e.BackerUserProjectId == id);
        }
    }
}
