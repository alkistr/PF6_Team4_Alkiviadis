using Microsoft.AspNetCore.Mvc;
using PF6_Team4_Core.Data;
using PF6_Team4_Core.Interfaces;
using PF6_Team4_Core.Models;
using PF6_Team4_Core.ViewModels;
using System.Linq;

namespace PF6_Team4_Alkiviadis.Controllers
{
    public class UserVMsController : Controller
    {
        private readonly IUserVMService _uservmservice;
        private readonly ApplicationDbContext _context;

        public UserVMsController(ApplicationDbContext context, IUserVMService uservmservice)
        {
            _context = context;
            _uservmservice = uservmservice;
        }

        

        // GET: UserVMs
        public IActionResult Index()
        {
            var userview1 = _uservmservice.CreateUserVM(_context.UsersLoggedIn.OrderByDescending(x => x.UserId).Last().UserId).Data.FirstName;
            UserVM userview = new UserVM()
            {
                FirstName = userview1,
                //backeruserprojectsUserVM = userview1.backeruserprojectsUserVM.ToList(),
                //projectsUserVM = userview1.projectsUserVM.ToList()
            };
            return View(userview);
        }
    }
    //    // GET: UserVMs/Details/5
    //    public async Task<IActionResult> Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var userVM = await _context.UsersVM
    //            .FirstOrDefaultAsync(m => m.UserVMId == id);
    //        if (userVM == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(userVM);
    //    }

    //    // GET: UserVMs/Create
    //    public IActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: UserVMs/Create
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("UserVMId,FirstName")] UserVM userVM)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _context.Add(userVM);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(userVM);
    //    }

    //    // GET: UserVMs/Edit/5
    //    public async Task<IActionResult> Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var userVM = await _context.UsersVM.FindAsync(id);
    //        if (userVM == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(userVM);
    //    }

    //    // POST: UserVMs/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(int id, [Bind("UserVMId,FirstName")] UserVM userVM)
    //    {
    //        if (id != userVM.UserVMId)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(userVM);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!UserVMExists(userVM.UserVMId))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(userVM);
    //    }

    //    // GET: UserVMs/Delete/5
    //    public async Task<IActionResult> Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return NotFound();
    //        }

    //        var userVM = await _context.UsersVM
    //            .FirstOrDefaultAsync(m => m.UserVMId == id);
    //        if (userVM == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(userVM);
    //    }

    //    // POST: UserVMs/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        var userVM = await _context.UsersVM.FindAsync(id);
    //        _context.UsersVM.Remove(userVM);
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool UserVMExists(int id)
    //    {
    //        return _context.UsersVM.Any(e => e.UserVMId == id);
    //    }
    //}
}
