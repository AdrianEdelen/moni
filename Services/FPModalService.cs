using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using moni.Data;
using moni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace moni.Services
{
    public class FPModalService : IFPModalService
    {
        private readonly ApplicationDbContext _context;
        

        public FPModalService(ApplicationDbContext context, UserManager<FPUser> userManager)
        {
            _context = context;
            
        }
        public SelectList CategoryDropDown(FPUser user)
        {
            return new SelectList(_context.Category.Where(c => c.HouseholdId == user.HouseholdId), "Id", "Name");
        }

        public SelectList CategoryItemDropDown(Category category)
        {
            return new SelectList(_context.CategoryItem.Where(c => c.CategoryId == category.Id), "Id", "Name");
        }
    }
}
