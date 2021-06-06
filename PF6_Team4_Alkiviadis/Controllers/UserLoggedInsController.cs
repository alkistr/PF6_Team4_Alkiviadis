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
using PF6_Team4_Core.Models.Options;

namespace PF6_Team4_Alkiviadis.Controllers
{
    public class UserLoggedInsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserLoginService _userLoginService;

        public UserLoggedInsController(ApplicationDbContext context, IUserLoginService userLoginService)
        {
            _context = context;
            _userLoginService = userLoginService;
        }

        // GET: UserLoggedIns
        public async Task<IActionResult> Index()
        {
            return View(await _context.UsersLoggedIn.ToListAsync());
        }

        // GET: UserLoggedIns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userLoggedIn = await _context.UsersLoggedIn
                .FirstOrDefaultAsync(m => m.UserLoggedInId == id);
            if (userLoggedIn == null)
            {
                return NotFound();
            }

            return View(userLoggedIn);
        }

        // GET: UserLoggedIns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserLoggedIns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserLoggedInId,UserId,Email")] UserOptions userLoggedIn)
        {
            if (ModelState.IsValid)
            {
                await _userLoginService.GetUserLoggedInByEmailAsync(userLoggedIn.Email);
                userLoggedIn = _userLoginService.LoggedInUserInfoVM().Data;
            }
            return View(userLoggedIn);
        }

        //// GET: UserLoggedIns/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var userLoggedIn = await _context.UsersLoggedIn.FindAsync(id);
        //    if (userLoggedIn == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(userLoggedIn);
        //}

        //// POST: UserLoggedIns/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("UserLoggedInId,UserId,Email")] UserLoggedIn userLoggedIn)
        //{
        //    if (id != userLoggedIn.UserLoggedInId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(userLoggedIn);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserLoggedInExists(userLoggedIn.UserLoggedInId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(userLoggedIn);
        //}

        //// GET: UserLoggedIns/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var userLoggedIn = await _context.UsersLoggedIn
        //        .FirstOrDefaultAsync(m => m.UserLoggedInId == id);
        //    if (userLoggedIn == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(userLoggedIn);
        //}

        //// POST: UserLoggedIns/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var userLoggedIn = await _context.UsersLoggedIn.FindAsync(id);
        //    _context.UsersLoggedIn.Remove(userLoggedIn);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UserLoggedInExists(int id)
        //{
        //    return _context.UsersLoggedIn.Any(e => e.UserLoggedInId == id);
        //}
    }
}
