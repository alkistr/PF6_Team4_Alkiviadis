using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team4_Alkiviadis.Controllers
{
    public class User : Controller
    {
       
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: User
        public async Task<ActionResult> Index()
        {
           
            return View(await _context.User.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
             var User = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);

            if (User == null)
            {
                return NotFound();
            }

            return View(User);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create ([Bind("UserId,FirstName,LastName,Email,CreationDate,Adress")] User user) 
        {
            if(ModelState.IsValid)
            {
                 _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            return View(user);
            
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("UserId,FirstName,LastName,Email,CreationDate,Adress") User user)]
        {
         if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserId))
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
            return View(user);    
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if( id== null)
        {
            return NotFound();
        }
              
        var user = await _context.User
                .FirstOrDefaultAsync(m => m.UserId == id);

         if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        // POST: RewardPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.UserId == id);
        }
    }
    
        
    
        }
