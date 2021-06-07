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
    public class RewardPackagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRewardPackageServices _rewardpackageService;
        //private readonly IUserVMService _uservmservice;

        public RewardPackagesController(ApplicationDbContext context, IRewardPackageServices rewardpackageService/*, IUserVMService uservmservice */)
        {
            _rewardpackageService = rewardpackageService;
            //_uservmservice = uservmservice;
            _context = context;
        }

        

        // GET: RewardPackages
        public async Task<IActionResult> Index()
        {
            var allRewardPackages = await _rewardpackageService.GetAllRewardPackagesAsync();
            return View(allRewardPackages.Data);
        }

        // GET: RewardPackages/Details/5


        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewardPackage = await _rewardpackageService.GetRewardPackageByIdAsync(id.Value);

            if (rewardPackage == null)
            {
                return NotFound();
            }
            
            return View(rewardPackage);
        }


        // GET: RewardPackages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RewardPackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RewardPackageId,MaxAmountRoGetReward,RewardDescription,RewardPackageName,CreationDate")] RewardPackage rewardPackage)
        {
            if (ModelState.IsValid)
            {
                await _rewardpackageService.CreateRewardPackageAsync(rewardPackage);
                return RedirectToAction(nameof(Index));
            }
            return View(rewardPackage);
        }

        // GET: RewardPackages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rewardPackage = await _context.RewardPackages.FindAsync(id);
            if (rewardPackage == null)
            {
                return NotFound();
            }
            return View(rewardPackage);
        }

        // POST: RewardPackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RewardPackageId,MaxAmountRoGetReward,RewardDescription,RewardPackageName,CreationDate")] RewardPackage rewardPackage)
        {
            if (id != rewardPackage.RewardPackageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rewardPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RewardPackageExists(rewardPackage.RewardPackageId))
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
            return View(rewardPackage);
        }

        // GET: RewardPackages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _rewardpackageService.DeleteRewardPackageByIdAsync(id.Value);

            return RedirectToAction(nameof(Index));
        }

        // POST: RewardPackages/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var rewardPackage = await _context.RewardPackages.FindAsync(id);
        //    _context.RewardPackages.Remove(rewardPackage);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool RewardPackageExists(int id)
        {
            return _context.RewardPackages.Any(e => e.RewardPackageId == id);
        }
    }
}
