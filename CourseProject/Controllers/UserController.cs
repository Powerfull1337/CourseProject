﻿using CourseProject.Data;
using CourseProject.Models;
using Microsoft.AspNetCore.Mvc;
using CourseProject.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using CourseProject.Models.ViewModel;

namespace CourseProject.Controllers
{
    public class UserController : Controller
    {
        private readonly CRUDContext crudContext;
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(CRUDContext crudContext, UserManager<ApplicationUser> userManager)
        {
            this.crudContext = crudContext;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> UserAccounts(Guid id)
        {
            var user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == id.ToString());

            if (user != null)
            {
                var viewModel = new UpdateUserViewModel
                {
                    Id = Guid.Parse(user.Id),
                    Name = user.Name,
                    Email = user.Email,
                    Username = user.UserName,
                    Role = "user"
                };
                return View("UserAccounts", viewModel);
            }

            return RedirectToAction("UserAccounts");
        }

        [HttpPost]
        public async Task<IActionResult> UserAccounts(UpdateUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id.ToString());

            if (user != null)
            {
                user.Name = model.Name;
                user.Email = model.Email;
                user.UserName = model.Username;
                user.PasswordHash = userManager.PasswordHasher.HashPassword(user, model.Password);
                model.Role = "user";
                await userManager.UpdateAsync(user);

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("UserAccounts");
        }

        [HttpGet]
        public async Task<IActionResult> UserAppointments()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var appointments = await crudContext.Appointements
                .Where(a => a.UserId == userId)
                .OrderBy(a => a.DateOfBook)
                .ThenBy(a => a.TimeOfBook)
                .ToListAsync();

            return View(appointments);
        }

    }
}