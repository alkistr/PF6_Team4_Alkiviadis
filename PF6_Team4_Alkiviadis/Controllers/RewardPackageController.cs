using Microsoft.AspNetCore.Mvc;
using PF6_Team4_Alkiviadis.Interfaces;
using PF6_Team4_Alkiviadis.Models.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PF6_Team4_Alkiviadis.Controllers
{
    public class RewardPackageController : Controller
    {
        private readonly IRewardPackageServices _rewardpackageService;

        public RewardPackageController(IRewardPackageServices rewardpackageService)
        {
            _rewardpackageService = rewardpackageService;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var allRewardPackagesResult = await _rewardpackageService.GetAllRewardPackagesAsync();

            return View(allRewardPackagesResult.Data);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _rewardpackageService.GetRewardPackageByIdAsync(id.Value);

            if (customer.Error != null || customer.Data == null)
            {
                return NotFound();
            }

            return View(customer.Data);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RewardPackageName,MaxAmountRoGetReward,RewardDescription,CreationDate")] RewardPackageOptions rewardpackageoptions)
        {
            if (ModelState.IsValid)
            {
                await _rewardpackageService.CreateRewardPackageAsync(new RewardPackageOptions
                {
                    RewardPackageName = rewardpackageoptions.RewardPackageName,
                    MaxAmountRoGetReward = rewardpackageoptions.MaxAmountRoGetReward,
                    RewardDescription = rewardpackageoptions.RewardDescription,
                    CreationDate = DateTime.Now
                });

                return RedirectToAction(nameof(Index));
            }

            return View(rewardpackageoptions);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _rewardpackageService.GetRewardPackageByIdAsync(id.Value);

            if (customer.Error != null || customer.Data == null)
            {
                return NotFound();
            }

            return View(customer.Data);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _rewardpackageService.DeleteRewardPackageByIdAsync(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var allCustomersResult = await _rewardpackageService.GetAllRewardPackagesAsync();

            return Ok(allCustomersResult.Data);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _rewardpackageService.DeleteRewardPackageByIdAsync(id);

            return NoContent();
        }
    }
}
