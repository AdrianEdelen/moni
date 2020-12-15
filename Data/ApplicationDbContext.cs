using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using moni.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace moni.Data
{
    public class ApplicationDbContext : IdentityDbContext<FPUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<moni.Models.BankAccount> BankAccount { get; set; }
        public DbSet<moni.Models.Category> Category { get; set; }
        public DbSet<moni.Models.CategoryItem> CategoryItem { get; set; }
        public DbSet<moni.Models.Household> Household { get; set; }
        public DbSet<moni.Models.Invitation> Invitation { get; set; }
        public DbSet<moni.Models.Notification> Notification { get; set; }
        public DbSet<moni.Models.Transaction> Transaction { get; set; }
    }
}
