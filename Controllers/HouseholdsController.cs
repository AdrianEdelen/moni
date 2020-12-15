using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using moni.Data;
using moni.Models;
using moni.Models.ViewModels;
using static moni.Data.Data.SeedHelper;

namespace moni.Controllers
{
    public class HouseholdsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<FPUser> _userManager;
        private readonly SignInManager<FPUser> _signInManager;

        public HouseholdsController(ApplicationDbContext context, UserManager<FPUser> userManager, SignInManager<FPUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }



        // GET: Households
        public async Task<IActionResult> Index()
        {
            return View(await _context.Household.ToListAsync());
        }

        // GET: Households/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var household = await _context.Household
                .FirstOrDefaultAsync(m => m.Id == id);
            if (household == null)
            {
                return NotFound();
            }

            DashboardViewModel vm = new DashboardViewModel()
            {
                User = await _userManager.GetUserAsync(User),
                Household = household,
                Category = _context.Category.Where(c => c.HouseholdId == household.Id).ToList()
            };
            return View(vm);
        }

        // GET: Households/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Households/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Greeting")] Household household)
        {
            
            if (ModelState.IsValid)
            {
                household.Established = DateTimeOffset.Now;
                _context.Add(household);
                await _context.SaveChangesAsync();
                var user = await _userManager.GetUserAsync(User);
                user.HouseholdId = household.Id;
                await _userManager.AddToRoleAsync(user, Roles.HeadOfHouseHold.ToString());
                await _signInManager.RefreshSignInAsync(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Households", new { id = household.Id });
            }
            return View(household);
        }

        // GET: Households/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var household = await _context.Household.FindAsync(id);
            if (household == null)
            {
                return NotFound();
            }
            return View(household);
        }

        // POST: Households/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Greeting,Established")] Household household)
        {
            if (id != household.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(household);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseholdExists(household.Id))
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
            return View(household);
        }

        // GET: Households/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var household = await _context.Household
                .FirstOrDefaultAsync(m => m.Id == id);
            if (household == null)
            {
                return NotFound();
            }

            return View(household);
        }

        // POST: Households/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var household = await _context.Household.FindAsync(id);
            _context.Household.Remove(household);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseholdExists(int id)
        {
            return _context.Household.Any(e => e.Id == id);
        }
    }
}
