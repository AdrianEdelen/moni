﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using moni.Models;

namespace moni.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ConfirmEmailModel : PageModel
    {
        private readonly UserManager<FPUser> _userManager;
        private readonly SignInManager<FPUser> _signInManager;

        public ConfirmEmailModel(UserManager<FPUser> userManager, SignInManager<FPUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToPage("/Index");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            // Store status message
            TempData["StatusMessage"] = result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";
            //return RedirectToPage("/Account/Login", new { area = "Identity" });
            // Sign user in from link sent to email
            await _signInManager.SignInAsync(user, isPersistent: false);
            // Redirect to home action now accessible since isSignedIn is true
            // Take StatusMessage along to home index to display
            return RedirectToAction("Index", "Home");
        }
    }
}
