using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace moni.Data.Data
{
    public class SeedHelper
    {

        public enum Roles
        {
            Admin,
            HeadOfHouseHold,
            Member
        }
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.HeadOfHouseHold.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Member.ToString()));
        }

    }
}

